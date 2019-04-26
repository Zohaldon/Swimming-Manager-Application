using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SwimApplicationLibrary
{
    public class ClubsManager : IClubsRepository
    {
        /*properties*/
        public int Number { set; get; }
        public List<Club> Clubs { set; get; }
        public SwimmersManager SwimmerManager { set; get; }

        /*Constructor*/
        public ClubsManager()
        {
            Clubs = new List<Club>(100);
            SwimmerManager = new SwimmersManager(this);
        }

        /*GetByRegNum Method*/
        public Club GetByRegNum(int regNo)
        {
            Club newClub = null;
            for (int i = 0; i < Number; i++)
            {
                if (Clubs[i].UniqueId == regNo)
                    newClub = Clubs[i];
            }
            return newClub;
        }

        /*Add Method to add club*/
        public void Add(Club newClub)
        {
            Clubs.Add(newClub);
            Number++;
        }

        /* Load Method to load the club from file*/
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

                    Club newClub = new Club();

                    CheckUniqueId(fields[0]);
                    CheckName(fields[1]);
                    CheckPhoneNo(fields[6]);

                    newClub.UniqueId = Int32.Parse(fields[0]);
                    newClub.Name = fields[1];
                    newClub.Address = new Address(fields[2], fields[3], fields[4], fields[5]);
                    newClub.PhoneNumber = long.Parse(fields[6]);

                    Add(newClub);
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

        /*Checking the UniqueId*/
        private void CheckUniqueId(string testElement)
        {
            int ID;
            try
            {
                if (testElement == "")
                    throw new Exception(string.Format("Invalid club record. Registration number is missing: "));
                try
                {
                    ID = Int32.Parse(testElement);
                }
                catch (Exception)
                {
                    throw new Exception(string.Format("Invalid club record Club number is not valid:"));
                }
                ID = Int32.Parse(testElement);
                for (int i = 0; i < Number; i++)
                {
                    if (ID == Clubs[i].UniqueId)
                    {
                        throw new Exception("Invalid club record. Club with the registration number already exists: ");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /*Checking Name*/
        private void CheckName(string testElement)
        {
            if (testElement == "")
            {
                throw new Exception(string.Format("Invalid club record. Club name is missing: "));
            }
        }
        /*Checking the phone number*/
        private void CheckPhoneNo(string testElement)
        {
            long ID;
            try
            {
                if (testElement == "")
                {
                    throw new Exception(string.Format("Invalid club record. Phone number is missing: "));
                }

                try
                {
                    ID = long.Parse(testElement);
                }
                catch
                {
                    throw new Exception(string.Format("Invalid club record. Phone number wrong format:"));
                }
            }
            catch
            {
                throw;
            }
        }

        /*Save Method to Save record in txt file*/
        public void Save(string fileName, string delimeter)
        {
            FileStream outFile = null;
            StreamWriter writer = null;
            try
            {
                outFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(outFile);

                foreach (var field in Clubs)
                {
                    writer.WriteLine(field.UniqueId + delimeter + field.Name + delimeter + field.Address.street + delimeter 
                        + field.Address.city + delimeter + field.Address.province + delimeter
                        + field.Address.postalCode + delimeter + field.PhoneNumber);
                }
            }
            catch
            {
                throw new Exception("Cannot Write the ClubsOut");
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
