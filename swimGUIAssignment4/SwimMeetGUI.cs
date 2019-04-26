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
    public partial class SwimMeetGUI : Form
    {
        Home home;
        SoundforGUI sog = new SoundforGUI();

        /*Fields*/
        private List<SwimMeet> swimMeets;
        private List<Event> swimEvents;

        /*Properties*/
        public List<SwimMeet> SwimMeets
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

        public SwimMeetGUI()
        {
            InitializeComponent();
        }

        /*Loading the objects as the Forms Load*/
        private void SwimMeetGUI_Load(object sender, EventArgs e)
        {
            //Adding SwimMeet to the List
            foreach (var swimMeet in SwimMeets)
            {
                lbSwimMeets.Items.Add(swimMeet.Name);
            }
            //Adding Events to the list
            foreach (var events in SwimEvents)
            {
                lbEvents.Items.Add(events.Distance.ToString() + events.Stroke.ToString());
            }
            //Adding the Course
            Array courseArray = typeof(PoolType).GetEnumValues();
            foreach (object obj in courseArray)
            {
                lbCourse.Items.Add(obj);
            }
        }

        /*Seeding the Meets when User Clicks the Seed Button*/
        private void btnSeed_Click(object sender, EventArgs e)
        {
            sog.SoundSeed();
            try
            {
                SwimMeets[lbSwimMeets.SelectedIndex].Seed();
                //lblInfo.Text = SwimMeets[lbSwimMeets.SelectedIndex].ToString();
                rtb.Text = SwimMeets[lbSwimMeets.SelectedIndex].ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Meets Could not be Seeded" + exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*Adding New Swim Meet*/
        private void btnAddSwimMeet_Click(object sender, EventArgs e)
        {
            sog.AddAssign();
            //Checking the Name 
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter Swim Name", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Checking Number of Lanes
            if (string.IsNullOrEmpty(txtNoOfLane.Text))
            {
                MessageBox.Show("Please Enter Number of Lane", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Checking if End date is past of Start Dates
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date is earlier compared to start date", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //getting the cousrse value form the user
                PoolType courseSwimMeet;

                switch (lbCourse.SelectedIndex)
                {
                    case 0:
                        courseSwimMeet = PoolType.SCM;
                        break;
                    case 1:
                        courseSwimMeet = PoolType.SCY;
                        break;
                    case 2:
                        courseSwimMeet = PoolType.LCM;
                        break;
                    default:
                        courseSwimMeet = PoolType.SCM;
                        break;
                }

                int noOfLanes = 0;
                //Converting the sring NO of Lanes ot int type
                try
                {
                    noOfLanes = Int32.Parse(txtNoOfLane.Text);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Cannot enter the Number of Lanes\n" + exception.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Creating New Swim Meet
                SwimMeet newSwimMeet = new SwimMeet(txtName.Text, dtpStartDate.Value.Date, dtpEndDate.Value.Date, courseSwimMeet, noOfLanes);

                //Making Sure that all textbox are filled
                if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtNoOfLane.Text))
                {
                    //adding the SwimMeet 
                    SwimMeets.Add(newSwimMeet);
                    home = new Home();
                    home.SwimMeets = SwimMeets;
                    //Displaying Swim Meet in the list
                    lbSwimMeets.Items.Add(newSwimMeet.Name);
                }
                else
                {
                    MessageBox.Show("Make sure that All fields are filled", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                DefaultValues();

            }
            catch
            {
                MessageBox.Show("Unable to Add the new Swim Meet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*Default Values for the Swimm Meet*/
        public void DefaultValues()
        {
            txtName.Clear();
            txtNoOfLane.Clear();
        }

        /*Adding Event to the SwimmMeet*/
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            sog.AddAssign();
            try
            {
                SwimMeets[lbSwimMeets.SelectedIndex].AddEvent(SwimEvents[lbEvents.SelectedIndex]);
                //lblInfo.Text = SwimMeets[lbSwimMeets.SelectedIndex].ToString();
                rtb.Text = SwimMeets[lbSwimMeets.SelectedIndex].ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Event not entered in Swim Meet" + exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*Updating The Info of the Swimm Meet as the Meet index is changed*/
        private void lbSwimMeets_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtName.Text = SwimMeets[lbSwimMeets.SelectedIndex].Name;
                txtNoOfLane.Text = SwimMeets[lbSwimMeets.SelectedIndex].NoOfLanes.ToString();
                dtpStartDate.Value = SwimMeets[lbSwimMeets.SelectedIndex].StartDate;
                dtpEndDate.Value = SwimMeets[lbSwimMeets.SelectedIndex].EndDate;
                rtb.Text = SwimMeets[lbSwimMeets.SelectedIndex].ToString();
            }
            catch
            {

            }
        }

        /*restricting User Input to Numbers*/
        private void txtNoOfLane_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        /*Restticting User Input to Letters*/
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                return;
            }
            else if (Char.IsWhiteSpace(e.KeyChar))
            {
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        /*Deleting the Swim Meet from list and the textbox*/
        private void btnDeleteSwimMeet_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();
            try
            {
                SwimMeets.RemoveAt(lbSwimMeets.SelectedIndex);
                lbSwimMeets.Items.Remove(lbSwimMeets.SelectedItem);
                rtb.Text = "";
                lbSwimMeets.SelectedIndex = 0;
                DefaultValues();
            }
            catch
            {
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();
            try
            {
                //Setting the user defined value
                SwimMeets[lbSwimMeets.SelectedIndex].Name = txtName.Text;
                SwimMeets[lbSwimMeets.SelectedIndex].NoOfLanes = Int32.Parse(txtNoOfLane.Text);
                SwimMeets[lbSwimMeets.SelectedIndex].StartDate = dtpStartDate.Value;
                SwimMeets[lbSwimMeets.SelectedIndex].EndDate = dtpEndDate.Value;
                SwimMeets[lbSwimMeets.SelectedIndex].Course = (PoolType)lbCourse.SelectedItem;

                //Refreshing the list
                lbSwimMeets.Items.Clear();
                lbSwimMeets.Update();

                foreach (var swimMeet in this.SwimMeets)
                {
                    lbSwimMeets.Items.Add(swimMeet.Name);
                }

                rtb.Text = "";
            }
            catch
            {

            }
        }
    }
}
