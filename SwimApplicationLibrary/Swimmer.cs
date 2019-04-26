using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApplicationLibrary
{
    public class Swimmer : Registrant
    {
        /*fields*/
        private Coach coach;
        private List<TimeSpan> bestTimeTimeSpan;
        private List<Event> bestTimeEvent;

        /*properties*/
        public Coach Coach
        {
            set
            {
                if (Club == value.Club && !value.Swimmers.Contains(this))
                {
                    coach = value;
                    coach.AddSwimmer(this);
                }
                else if (value.Club != Club && value.Club != null)
                {
                    throw new Exception("Coach and swimmer are not in the same club");
                }
                else
                {
                    throw new Exception("Coach is not assigned to the club");
                }
            }

            get
            {
                return coach;
            }
        }
        public List<TimeSpan> BestTimeTimeSpan
        {
            set
            {
                bestTimeTimeSpan = value;
            }

            get
            {
                return bestTimeTimeSpan;
            }
        }
        public List<Event> BestTimeEvent
        {
            set
            {
                bestTimeEvent = value;
            }
            get
            {
                return bestTimeEvent;
            }
        }

        /*Constructor*/
        public Swimmer(string name, DateTime DOB, Address location, long regPhoneNo) : base(name, DOB, location, regPhoneNo)
        {
            BestTimeTimeSpan = new List<TimeSpan>();
            BestTimeEvent = new List<Event>();
        }
        public Swimmer()
        {
            BestTimeTimeSpan = new List<TimeSpan>();
            BestTimeEvent = new List<Event>();
        }

        /*Best Time method Method*/
        public TimeSpan GetBestTime(PoolType course,Stroke stroke, EventDistance distance)
        {
            TimeSpan time = TimeSpan.Zero;
            for (int i = 0; i < BestTimeEvent.Count; i++)
            {
                if (BestTimeEvent[i].Stroke == stroke && BestTimeEvent[i].Distance == distance && 
                    BestTimeEvent[i].SwimMeets.Course == course)
                {
                    time = BestTimeTimeSpan[i];
                }
            }
            return time;
        }

        /*Method Add as Best Time */
        public void AddAsBestTime(PoolType course,Stroke stroke, EventDistance distance, TimeSpan time)
        {
            for (int i = 0; i < BestTimeEvent.Count; i++)
            {
                if (BestTimeEvent[i].Stroke == stroke && 
                    BestTimeEvent[i].Distance == distance && 
                    BestTimeEvent[i].SwimMeets.Course == course)
                {
                    if (TimeSpan.Compare(BestTimeTimeSpan[i], time) == 1)
                    {
                        BestTimeTimeSpan[i] = time;
                    }
                }
            }
        }
        
        /*ToString*/
        public override string ToString()
        {
            string info;
            string result = string.Format("{0}", Coach != null ? Coach.Name : "not assigned");
            info = base.ToString() + string.Format($"\nCoach: {result}");
            return info;
        }

    }
}
