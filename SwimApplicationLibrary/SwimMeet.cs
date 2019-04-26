using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApplicationLibrary
{
    public enum PoolType
    {
        SCM,
        SCY,
        LCM
    };

    public class SwimMeet
    {
        /*Properties*/
        private PoolType course;
        private DateTime startDate;
        private DateTime endDate;
        private string name;
        private int noOfLanes;
        private int noOfEvents;
        private List<Event> events;

        /*Properties*/
        public PoolType Course
        {
            set
            {
                course = value;
            }
            get
            {
                return course;
            }
        }
        public DateTime StartDate
        {
            set
            {
                startDate = value;
            }
            get
            {
                return startDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                endDate = value;
            }
            get
            {
                return endDate;
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
        public int NoOfLanes
        {
            set
            {
                noOfLanes = value;
            }
            get
            {
                return noOfLanes;
            }
        }
        public int NoOfEvents
        {
            set
            {
                noOfEvents = value;
            }
            get
            {
                return noOfEvents;
            }
        }
        public List<Event> Events
        {
            set
            {
                events = value;
            }

            get
            {
                return events;
            }
        }


        /*Constructor*/
        public SwimMeet(string Meet, DateTime startDate, DateTime endDate, PoolType course, int noOfLanes)
        {
            StartDate = startDate;
            EndDate = endDate;
            Name = Meet;
            NoOfLanes = noOfLanes;
            Course = course;
            Events = new List<Event>(50);

        }
        public SwimMeet()
        {
            NoOfLanes = 8;
            Events = new List<Event>(50);
        }

        /*Add Event Method*/
        public void AddEvent(Event newEvent)
        {
            Events.Add(newEvent);
            NoOfEvents++;
            newEvent.SwimMeets = this;
        }

        /*Seed Method*/
        public void Seed()
        {
            for (int h = 0; h < NoOfEvents; h++)
            {
                int l = 0;
                int heat = 1;
                int lane = 1;
                foreach (var item in Events[h].Swimmers)
                {
                    Events[h].AddSwim();
                    if (lane <= NoOfLanes)
                    {
                        Events[h].Swims[l].Lane = lane;
                        Events[h].Swims[l].Heat = heat;
                        lane++;
                    }
                    else
                    {
                        lane = 1;
                        heat++;
                        Events[h].Swims[l].Lane = lane;
                        Events[h].Swims[l].Heat = heat;
                    }
                    l++;
                }
            }
        }

        /*ToString*/
        public override string ToString()
        {
            string info;
            info = string.Format($"Swim Meet: {Name} \nFrom-to:{StartDate.ToShortDateString()} to {EndDate.ToShortDateString()} \n" +
                $"Pool type: {Course} \nNo lanes: {NoOfLanes}");
            info += "\t\nEvents: ";
            foreach (var fields in Events)
            {
                info += "\n---------------------------";
                info += string.Format(fields.ToString());
            }
            return info;
        }
    }
}
