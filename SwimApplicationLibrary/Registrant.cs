using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApplicationLibrary
{
    public class Registrant
    {
        /*fields*/
        private static int registrantNo;
        private int uniqueId;
        private string name;
        private DateTime dateOfBirth;
        public Address Address;
        private long phoneNumber;
        private Event addToEvent;
        private Club club;

        /*Properties*/
        public virtual Club Club
        {
            set
            {
                if (club == null)
                {
                    club = value;
                    Club.AddSwimmer(this);
                }
                else
                {
                    throw new Exception(string.Format("Swimmer is registered with a different club"));
                }
            }
            get
            {
                return club;
            }

        }
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
        public DateTime DateOfBirth
        {
            set
            {
                dateOfBirth = value;
            }
            get
            {
                return dateOfBirth;
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
        public Event AddToEvent
        {
            set
            {
                addToEvent = value;
            }

            get
            {
                return addToEvent;
            }
        }

        /*Assigning Unique Id*/
        public Registrant()
        {
            UniqueId = registrantNo++;
        }
        static Registrant()
        {
            registrantNo = 1;
        }

        /*Constructor*/
        public Registrant(string regName, DateTime DOB, Address location, long PhoneNo)
        {
            Name = regName;
            DateOfBirth = DOB;
            Address = location;
            PhoneNumber = PhoneNo;
            UniqueId = registrantNo++;
        }
        /*ToString Method*/
        public override string ToString()
        {
            string result = string.Format("{0}", Club != null ? Club.Name : "not assigned");
            return string.Format($"Name: {Name} \nAdress: {Address.ToString()} \nPhone: {Club.FormatPhoneNo(PhoneNumber)}" +
                $" \nDateOfBirth: {DateOfBirth} \nReg number: {UniqueId} \nClub: {result}");
        }
    }
}
