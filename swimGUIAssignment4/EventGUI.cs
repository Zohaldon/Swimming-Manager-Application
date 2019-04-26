using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwimApplicationLibrary;
using System.Media;

namespace swimGUIAssignment4
{
    public partial class EventGUI : Form
    {
        Home home;
        SoundforGUI sog = new SoundforGUI();

        /*fields*/
        private List<Event> swimEvents;
        private List<Swimmer> swimmers;

        /*Properties*/
        public List<Event> SwimEvents
        {
            set
            {
                swimEvents = value;
            }
            get
            {
                return swimEvents;
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

        public EventGUI()
        {
            InitializeComponent();
        }

        /* Loading Swimmer and Events as forms open.*/
        private void EventGUI_Load(object sender, EventArgs e)
        {
            foreach (var Swimmer in Swimmers)
            {
                lbSwimmers.Items.Add(Swimmer.Name);
            }
            foreach (var aEvent in SwimEvents)
            {
                lbEvents.Items.Add(aEvent.Distance.ToString() + " " + aEvent.Stroke.ToString());
            }
            //Distance
            Array distanceArray = typeof(EventDistance).GetEnumValues();
            foreach(object obj in distanceArray)
            {
                lbDistance.Items.Add(obj);
            }
            //Stroke
            Array strokeArray = typeof(Stroke).GetEnumValues();
            foreach (object obj in strokeArray)
            {
                lbStroke.Items.Add(obj);
            }
        }

        /*Adding the Event*/
        private void btnAddEvent_Click_1(object sender, EventArgs e)
        {
            sog.AddAssign();
            try
            {
                //Getting Distance from user
                EventDistance distanceEvent;
                switch (lbDistance.SelectedIndex)
                {
                    case 0:
                        distanceEvent = EventDistance._50;
                        break;
                    case 1:
                        distanceEvent = EventDistance._100;
                        break;
                    case 2:
                        distanceEvent = EventDistance._200;
                        break;
                    case 3:
                        distanceEvent = EventDistance._400;
                        break;
                    case 4:
                        distanceEvent = EventDistance._800;
                        break;
                    case 5:
                        distanceEvent = EventDistance._1500;
                        break;
                    default:
                        distanceEvent = EventDistance._50;
                        break;
                }

                // Getting Stroke from User
                Stroke strokeEvent;
                switch (lbStroke.SelectedIndex)
                {
                    case 0:
                        strokeEvent = Stroke.Butterfly;
                        break;
                    case 1:
                        strokeEvent = Stroke.Backstroke;
                        break;
                    case 2:
                        strokeEvent = Stroke.Breaststroke;
                        break;
                    case 3:
                        strokeEvent = Stroke.Freestyle;
                        break;
                    case 4:
                        strokeEvent = Stroke.Individualmedley;
                        break;
                    default:
                        strokeEvent = Stroke.Butterfly;
                        break;
                }

                //Creating New Event and Adding it to List
                Event newEvent = new Event();
                newEvent.Distance = distanceEvent;
                newEvent.Stroke = strokeEvent;
                SwimEvents.Add(newEvent);
                home = new Home();
                home.SwimEvents = SwimEvents;
                lbEvents.Items.Add(newEvent.Distance.ToString() + " "
                    + newEvent.Stroke.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show("Cannot add the Event \n" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*Adding Swimmer to the Event*/
        private void btnAddSwimmer_Click(object sender, EventArgs e)
        {
            sog.AddAssign();
            try
            {
                //Passing the Swimmers Index number to AddSwimmer method of selected Event
                SwimEvents[lbEvents.SelectedIndex].AddSwimmer(Swimmers[lbSwimmers.SelectedIndex]);
                //Adding the info of Swimmer in event
                lblInfo.Text = SwimEvents[lbEvents.SelectedIndex].ToString();
                lblInfo.Text = SwimEvents[lbEvents.SelectedIndex].ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cannot add Swimmer to the Event\n" + exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*Changing the inof as the Event is changed form the list*/
        private void lbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Printing info of Selected event based on the index selected
                lblInfo.Text = SwimEvents[lbEvents.SelectedIndex].ToString();
            }
            catch
            {

            }
        }

        /*When User Add time for the Swimmer*/
        private void btnAddTime_Click(object sender, EventArgs e)
        {
            sog.AddAssign();
            try
            {
                SwimEvents[lbEvents.SelectedIndex].EnterSwimmersTime(Swimmers[lbSwimmers.SelectedIndex],
                    txtMin.Text + ":" + txtSec.Text + "." + txtMilliSec.Text);

                txtMin.Clear();
                txtSec.Clear();
                txtMilliSec.Clear();
                //Updating the Event Info
                lblInfo.Text = SwimEvents[lbEvents.SelectedIndex].ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Make Sure Your Events are seeded\nCannot Add the Time for the Swimmer\n" 
                    + exception.Message, "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Deleting the event from te list and listbox as well
        private void btnDelete_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();
            try
            {
                SwimEvents.RemoveAt(lbEvents.SelectedIndex);
                lbEvents.Items.Remove(lbEvents.SelectedItem);
                lblInfo.Text = "";
                lbEvents.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        //Update the Swimm event Button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();
            try
            {
                //Setting the Event value usinf the List selected by the User
                SwimEvents[lbEvents.SelectedIndex].Distance = (EventDistance)lbDistance.SelectedItem;
                SwimEvents[lbEvents.SelectedIndex].Stroke = (Stroke)lbStroke.SelectedItem;
                
                //Refreshing the list
                lbEvents.Items.Clear();
                lbEvents.Update();

                foreach (var swimEvent in this.SwimEvents)
                {
                    lbEvents.Items.Add(swimEvent.Distance.ToString() + " "
                        + swimEvent.Stroke.ToString());
                }

                lblInfo.Text = "";
            }
            catch
            {
                MessageBox.Show("Error in Upadting the info", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            
        }
    }
}
