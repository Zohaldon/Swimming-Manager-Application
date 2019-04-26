using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SwimApplicationLibrary
{
    public class SwimmersManager : ISwimmersRepository
    {
        /*Properties*/
        public int Number { get; set; }
        public List<Registrant> Swimmers { get; set; }
        public ClubsManager ClubManager { get; set; }

        /*Constructor*/
        public SwimmersManager(ClubsManager clubManager)
        {
            ClubManager = clubManager;
            Swimmers = new List<Registrant>(100);
        }

        /*Add Method*/
        public void Add(Registrant newSwimmer)
        {
            Swimmers.Add(newSwimmer);
            Number++;

            bool isAssigned = false;
            foreach (Club club in ClubManager.Clubs)
            {
                if (newSwimmer.Club == club)
                    isAssigned = true;
            }
            if (!isAssigned && newSwimmer.Club != null)
            {
                ClubManager.Add(newSwimmer.Club);
            }
        }

        /*Get Registratnt GetByRegNum Method*/
        public Registrant GetByRegNum(int regNo)
        {
            Registrant returnValue = null;

            for (int i = 0; i < Number; i++)
            {
                if (Swimmers[i].UniqueId == regNo)
                {
                    returnValue = Swimmers[i];
                }
            }
            return returnValue;
        }

        /*Load Method to load the Swimmers*/
        public void Load(string fileName, string delimeter)
        {
            FileStream inFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            string recordIn;
            string[] fields;
            recordIn = reader.ReadLine();

            while (recordIn != null)
            {
                try
                {
                    fields = recordIn.Split(delimeter[0]);
                    Registrant newSwimmer = new Registrant();

                    // Check the fields
                    CheckUniqueId(fields[0]);
                    CheckName(fields[1]);
                    CheckDOB(fields[2]);
                    CheckPhoneNo(fields[7]);
                        
                    newSwimmer.UniqueId = Int32.Parse(fields[0]);
                    newSwimmer.Name = fields[1];
                    newSwimmer.DateOfBirth = DateTime.Parse(fields[2]);
                    newSwimmer.Address = new Address(fields[3], fields[4], fields[5], fields[6]);
                    newSwimmer.PhoneNumber = long.Parse(fields[7]);

                    if (fields[8] != "")
                    {
                        int clubNumber = Int32.Parse(fields[8]);

                        if (clubNumber != 0)
                        {
                            for (int i = 0; i < ClubManager.Number; i++)
                            {
                                if (ClubManager.Clubs[i].UniqueId == clubNumber)
                                {
                                    ClubManager.Clubs[i].AddSwimmer(newSwimmer);
                                    break;
                                }
                            }
                        }
                    }

                    Add(newSwimmer);
                }

                catch (Exception exception)
                {
                    Console.WriteLine($"{exception.Message} \n\t{recordIn}");
                }

                recordIn = reader.ReadLine();
            }

            if (reader != null)
            {
                reader.Close();
            }
            if (inFile != null)
            {
                inFile.Close();
            }
        }
        
        /*Checking for fields and  Necessary Exception */
        /*Checking Uniqueness*/
        private void CheckUniqueId(string testElement)
        {
            int ID;
            try
            {
                if (testElement == "")
                    throw new Exception(string.Format("Invalid swimmer record. Registration number is missing: "));
                try
                {
                    ID = Int32.Parse(testElement);
                }
                catch (Exception)
                {
                    throw new Exception(string.Format("Invalid swimmer record. Invalid registration number: "));
                }
                ID = Int32.Parse(testElement);
                for (int i = 0; i < Number; i++)
                {
                    if (ID == Swimmers[i].UniqueId)
                    {
                        throw new Exception(string.Format("Invalid swimmer record. Swimmer with the registration number already exists: "));
                    }
                }
            }
            catch
            {
                throw;
            }
        }


        /*Checking for Swimmer Name*/

        private void CheckName(string testElement)
        {
            if (testElement == "")
            {
                throw new Exception(string.Format("Invalid swimmer record. Invalid swimmer name:   "));
            }
        }

        /*checking the Date of birth */
        private void CheckDOB(string testElement)
        {
            DateTime dateBirth;
            try
            {
                if (testElement == "")
                    throw new Exception(string.Format("Invalid swimmer record. Date of birth is missing: "));

                try
                {
                    dateBirth = DateTime.Parse(testElement);
                }
                catch
                {
                    throw new Exception(string.Format("Invalid swimmer record. Birth date is invalid:  "));
                }
            }
            catch
            {
                throw;
            }
        }

        /*Checking Phone Number*/
        private void CheckPhoneNo(string testElement)
        {
            long ID;
            try
            {
                if (testElement == "")
                    throw new Exception(string.Format("Invalid swimmer record. Phone number is missing: "));

                try
                {
                    ID = Int64.Parse(testElement);
                }
                catch
                {
                    throw new Exception(string.Format("Invalid swimmer record. Phone number wrong format:"));
                }
            }
            catch
            {
                throw;
            }
        }

        /*Save Method To save txt file as SwimmerOut*/
        public void Save(string fileName, string delimeter)
        {
            FileStream outFile = null;
            StreamWriter writer = null;
            try
            {
                outFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(outFile);

                foreach (var field in Swimmers)
                {
                    string clubId;
                    if (field.Club == null)
                    {
                        clubId = "";
                    }
                    else
                    {
                        clubId = field.Club.UniqueId.ToString();
                    }
                    //Writing the file
                    writer.WriteLine(field.UniqueId + delimeter + field.Name + delimeter +
                        field.DateOfBirth + delimeter + field.Address.street + delimeter +
                        field.Address.city + delimeter + field.Address.province + delimeter +
                        field.Address.postalCode + delimeter + field.PhoneNumber + delimeter + clubId);
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                if (outFile != null)
                {
                    outFile.Close();
                } 
            }
        }

    }
}
