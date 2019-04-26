using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApplicationLibrary
{
    public enum EventDistance
    {
        _50 = 50,
        _100 = 100,
        _200 = 200,
        _400 = 400,
        _800 = 800,
        _1500 = 1500
    };
    public enum Stroke
    {
        Butterfly, Backstroke, Breaststroke, Freestyle, Individualmedley
    };

    public class Event
    {
        /*Private Fields*/
        private EventDistance distance;
        private Stroke stroke;
        private int noOfSwims;
        private SwimMeet swimMeets;
        private List<Swim> swims;
        private int noOfSwimmers;
        private List<Registrant> swimmers;

        /*fileds*/
        public EventDistance Distance
        {
            set
            {
                distance = value;
            }
            get
            {
                return distance;
            }
        }
        public Stroke Stroke
        {
            set
            {
                stroke = value;
            }

            get
            {
                return stroke;
            }
        }
        public int NoOfSwims
        {
            set
            {
                noOfSwims = value;
            }
            get
            {
                return noOfSwims;
            }
        }
        public SwimMeet SwimMeets
        {
            set
            {
                swimMeets = value;
            }
            get
            {
                return swimMeets;
            }
        }
        public List<Swim> Swims
        {
            set
            {
                swims = value;
            }

            get
            {
                return swims;
            }
        }
        public int NoOfSwimmers
        {
            set
            {
                noOfSwimmers = value;
            }

            get
            {
                return noOfSwimmers;
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

        /*Constructor*/
        public Event(EventDistance distance, Stroke value)
        {
            Swimmers = new List<Registrant>(100);
            Swims = new List<Swim>(20);
            Distance = distance;
            Stroke = value;
        }
        public Event()
        {
            Swimmers = new List<Registrant>(100);
            Swims = new List<Swim>(20);
        }

        /*Method Add Swimmer And Add SWim*/
        public void AddSwim()
        {
            Swim swim = new Swim();
            Swims.Add(swim);
            noOfSwims++;
            swim.AddToEvent = this;
        }
        public void AddSwimmer(Registrant swimmer)
        {
            bool isEntered = true;
            foreach (Registrant newSwimmer in Swimmers)
            {
                if (newSwimmer == swimmer)
                {
                    isEntered = false;
                }
            }
            if (isEntered == true)
            {
                Swimmers.Add(swimmer);
                swimmer.AddToEvent = this;
            }
            else
            {
                throw new Exception($"Swimmer {swimmer.Name}, Id No: {swimmer.UniqueId} is already entered");
            }
        }

        /*Enters Swimmers Time*/
        public void EnterSwimmersTime(Registrant registrant, string timeSwam)
        {
            try
            {
                int index = Swimmers.IndexOf(registrant);
                Swims[index].TimeSwam = timeSwam;
            }
            catch
            {
                throw new Exception(string.Format("Seed meets before entering time"));
            }

            Swimmer newSwimmer = registrant as Swimmer;
            if (newSwimmer != null)
            {
                int min = Int32.Parse(timeSwam.Substring(0, 2));
                int sec = Int32.Parse(timeSwam.Substring(3, 2));
                int miliSec = Int32.Parse(timeSwam.Substring(6, 2)) * 10;
                TimeSpan currentTime = new TimeSpan(0, 0, min, sec, miliSec);
                if (newSwimmer.BestTimeEvent.Count == 0)
                {
                    newSwimmer.BestTimeEvent.Add(this);
                    newSwimmer.BestTimeTimeSpan.Add(currentTime);
                }
                bool isAssigned = false;
                for (int i = 0; i < newSwimmer.BestTimeEvent.Count; i++)
                {
                    if (newSwimmer.BestTimeEvent[i].Stroke == this.Stroke &&
                        newSwimmer.BestTimeEvent[i].Distance == this.Distance &&
                        newSwimmer.BestTimeEvent[i].SwimMeets.Course == this.SwimMeets.Course)
                    {
                        if (TimeSpan.Compare(newSwimmer.BestTimeTimeSpan[i], currentTime) == 1)
                        {
                            newSwimmer.BestTimeTimeSpan[i] = currentTime;
                        }
                        isAssigned = false;
                        break;
                    }
                    else if (!isAssigned)
                    {
                        isAssigned = true;
                    }
                }
                if (isAssigned)
                {
                    newSwimmer.BestTimeEvent.Add(this);
                    newSwimmer.BestTimeTimeSpan.Add(currentTime);
                }
            }
        }

        /*ToString*/
        public override string ToString()
        {
            string info;
            info = string.Format($"\n{Distance} {Stroke}");
            info += string.Format("\nSwimmers: ");
            int i = 0;
            foreach (var swimmers in Swimmers)
            {
                info += string.Format($"\n{swimmers.Name}");
                if (noOfSwims > 0)
                {
                    string result = string.Format("{0}", Swims[i].TimeSwam != null ? Swims[i].TimeSwam : "no time");
                    info += string.Format($"\nH: {Swims[i].Heat} L: {Swims[i].Lane}  Time: {result}");
                }
                else
                {
                    info += string.Format(" Not seeded/no swim");
                }
                i++;
            }
            return info;
        }
    }
}
