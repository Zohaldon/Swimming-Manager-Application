using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApplicationLibrary
{
    public class Swim
    {
        /*fields*/
        private int heat;
        private int lane;
        private string timeSwam;
        private Event addToEvent;

        /*properties*/
        public int Heat
        {
            set
            {
                heat = value;
            }

            get
            {
                return heat;
            }
        }
        public int Lane
        {
            set
            {
                lane = value;
            }

            get
            {
                return lane;
            }
        }
        public string TimeSwam
        {
            set
            {
                timeSwam = value;
            }

            get
            {
                return timeSwam;
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

        /*Constructor*/
        public Swim(int lane, int heat, string timeSwam)
        {
            Lane = lane;
            Heat = heat;
            TimeSwam = timeSwam;
        }
        public Swim()
        {
        }

        /*ToString*/
        public override string ToString()
        {
            return string.Format($"\n\tLane: {Lane}\n\tHeat: {Heat}\n\tTime {TimeSwam}\n");
        }

    }
}
