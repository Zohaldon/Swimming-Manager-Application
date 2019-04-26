using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApplicationLibrary
{
    public class Coach : Registrant
    {
        /*fields*/
        private string credentials;
        private List<Swimmer> swimmers;
        /*properties*/
        public string Credentials
        {
            set
            {
                credentials = value;
            }

            get
            {
                return credentials;
            }
        }
        public List<Swimmer> Swimmers
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
        public override Club Club
        {
            set;
            get;
        }

        /*Constructor*/
        public Coach(string Name, DateTime DOB, Address location, long regPhoneNo) : base(Name, DOB, location, regPhoneNo)
        {
            Swimmers = new List<Swimmer>(20);
        }
        public Coach()
        {
            Swimmers = new List<Swimmer>(20);
        }

        /*Add Swimemr Method*/
        public void AddSwimmer(Swimmer newSwimmer)
        {

            if (Club == newSwimmer.Club && !Swimmers.Contains(newSwimmer))
            {
                if (newSwimmer.Coach != this)
                    newSwimmer.Coach = this;
                if (!Swimmers.Contains(newSwimmer))
                    Swimmers.Add(newSwimmer);
            }
            else if (Club != newSwimmer.Club && Club != null)
            {
                throw new Exception("Coach and swimmer are in different club");
            }
            else if (Club == null)
            {
                throw new Exception("Coach is unassigned");
            }
        }

        /*ToString for Coach*/
        public override string ToString()
        {
            string info = base.ToString() + string.Format($"\nCredentials: { Credentials}\nSwimmers: ");
            // looop to pront the Swimmmers
            foreach (var field in Swimmers)
            {
                info += string.Format($"\n\t{field.Name}");
            }
            return info;
        }
        public string ToStringGUI()
        {
            string info = base.ToString() + string.Format($"\nCredentials: { Credentials}");
            return info;
        }
    }
}
