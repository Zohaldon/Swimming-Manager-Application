using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApplicationLibrary
{
    public class Club
    {
        /*fields*/
        private static int clubNo;
        private int uniqueId;
        private string name;
        public Address Address;
        private long phoneNumber;
        private List<Registrant> swimmers;
        private int numberOfSwimmers;
        private List<Coach> coaches;

        /*Properties*/
        public int UniqueId
        {
            set
            {
                uniqueId = value;
            }

            get
            {
                return uniqueId;
            }
        }
        public string Name
        {
            set
            {
                name = value;
            }

            get
            {
                return name;
            }
        }
        public long PhoneNumber
        {
            set
            {
                phoneNumber = value;
            }

            get
            {
                return phoneNumber;
            }
        }
        public List<Registrant> Swimmers
        {
            set
            {
                swimmers = value;
            }

            get
            {
                return swimmers;
            }
        }
        public int NumberOfSwimmers
        {
            set
            {
                numberOfSwimmers = value;
            }

            get
            {
                return numberOfSwimmers;
            }
        }
        public List<Coach> Coaches
        {
            set
            {
                coaches = value;
            }

            get
            {
                return coaches;
            }
        }

        /*Unique id*/
        public Club()
        {
            Coaches = new List<Coach>(20);
            Swimmers = new List<Registrant>(20);
            UniqueId = clubNo++;
        }
        static Club()
        {
            clubNo = 1;
        }

        /*Constructor*/
        public Club(string clubName, Address location, long PhoneNo)
        {
            Name = clubName;
            PhoneNumber = PhoneNo;
            Address = location;
            UniqueId = clubNo++;
            Swimmers = new List<Registrant>(20);
            Coaches = new List<Coach>(20);
        }

        /*Phone number formatter*/
        public static string FormatPhoneNo(long phNo)
        {
            string format = phNo.ToString();
            if (format == "0")
            {
                format = "";
            }
            else if (format.Length < 10)
            {
                format = "Invalid number";
            }
            else
            {
                format = phNo.ToString();
            }
            return format;
        }

        /*Add Swimmer and Add coach method*/
        public void AddCoach(Coach coach)
        {
            Coaches.Add(coach);
            coach.Club = this;
        }
        public void AddSwimmer(Registrant newSwimmer)
        {
            //Making the ndex start from one
            if (NumberOfSwimmers == 0 || Swimmers[NumberOfSwimmers - 1] != newSwimmer)
            {
                if (newSwimmer.Club == null || newSwimmer.Club == this)
                {
                    Swimmers.Add(newSwimmer);
                    NumberOfSwimmers++;

                    // Only Assigning the unassigned Swimmers
                    if (newSwimmer.Club == null)
                    {
                        newSwimmer.Club = this;
                    }
                }
                else
                {
                    throw new Exception(string.Format($"Swimmer already assigned to { newSwimmer.Club.Name} club"));
                }
            }
        }

        /*ToString*/
        public override string ToString()
        {
            string info;
            info = string.Format($"\nName: {Name} \nAdress: {Address.ToString()} \nPhone number: {FormatPhoneNo(PhoneNumber)} \nReg number: {UniqueId}");
            // loop to print the swimmers
            info += string.Format("\nSwimmers:");
            foreach (var swimmer in Swimmers)
            {
                info += string.Format($"\n\t  {swimmer.Name}");
            }
            //loop to print the coaches
            info += string.Format("\nCoaches: ");
            foreach (var coach in Coaches)
            {
                info += string.Format($"\n\t  {coach.Name}");
            }

            return info;
        }
        public string ToStringGUI()
        {
            string info;
            info = string.Format($"Name: {Name} \nAdress: {Address.ToString()} \nPhone number: \n{FormatPhoneNo(PhoneNumber)}");
            return info;
        }
    }
}
