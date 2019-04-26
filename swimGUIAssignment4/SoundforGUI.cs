using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace swimGUIAssignment4
{
    class SoundforGUI
    {
        public void SaveLoad()
        {
            try
            {
                SoundPlayer sp = new SoundPlayer("sl.wav");
                sp.Play();
            }
            catch
            {
            }
        }

        public void AddAssign()
        {
            try
            {
                SoundPlayer sp = new SoundPlayer("aa.wav");
                sp.Play();
            }
            catch
            {
            }
        }

        public void SoundSeed()
        {
            try
            {
                SoundPlayer sp = new SoundPlayer("s.wav");
                sp.Play();
            }
            catch
            {
            }
        }

        public void UpdateDelete()
        {
            try
            {
                SoundPlayer sp = new SoundPlayer("ud.wav");
                sp.Play();
            }
            catch
            {
            }
        }

        public void SoundButton()
        {
            try
            {
                SoundPlayer sp = new SoundPlayer("btn.wav");
                sp.Play();
            }
            catch
            {
            }
        }
    }
}
