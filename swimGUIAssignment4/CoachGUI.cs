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
    public partial class CoachGUI : Form
    {
        Home home;
        SoundforGUI sog = new SoundforGUI();

        /*fields*/
        private List<Coach> coaches;
        private List<Swimmer> swimmers;

        /*Properties*/
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

        public CoachGUI()
        {
            InitializeComponent();
        }

        /*Add Coach to the list*/
        private void btnAddCoach_Click(object sender, EventArgs e)
        {
            sog.AddAssign();
            //Checking the Name 
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter your Name", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Checking the Credential
            if (string.IsNullOrEmpty(txtCredential.Text))
            {
                MessageBox.Show("Please Enter your Credentials", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Checking Province
            if (string.IsNullOrEmpty(txtPro.Text))
            {
                MessageBox.Show("Please Enter your Province", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Checking the postal Code 
            if (string.IsNullOrEmpty(txtPostCode.Text))
            {
                MessageBox.Show("Please Enter your Postcode", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Checking the Street
            if (string.IsNullOrEmpty(txtStreet.Text))
            {
                MessageBox.Show("Please Enter your Street", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Checking City
            if (string.IsNullOrEmpty(txtCity.Text))
            {
                MessageBox.Show("Please Enter your City", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*Checking All fields for the Swimmers*/
            long phoneNo;
            try
            {
                phoneNo = long.Parse(txtPhNo.Text);
            }
            catch
            {
                MessageBox.Show("Please Check your Phone number", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //Creating New Caoch
                Coach newCoach = new Coach(txtName.Text, new DateTime(dtpDOB.Value.Year, dtpDOB.Value.Month, dtpDOB.Value.Day), 
                    new Address(txtStreet.Text,txtCity.Text, txtPro.Text, txtPostCode.Text), phoneNo);
                newCoach.Credentials = txtCredential.Text;

                //Checkign whether all fields are filled if filled then add the coach to the list
                //Adding Swimmer to the List
                if (!string.IsNullOrEmpty(txtName.Text) || (!string.IsNullOrEmpty(txtCredential.Text)) || !string.IsNullOrEmpty(txtCity.Text)
                    || !string.IsNullOrEmpty(txtPro.Text) || !string.IsNullOrEmpty(txtPostCode.Text)
                    || !string.IsNullOrEmpty(txtStreet.Text))
                {
                    Coaches.Add(newCoach);
                    home = new Home();
                    home.Coaches = Coaches;
                    lbCoaches.Items.Add(newCoach.Name);
                    //Displaying Message
                    MessageBox.Show($"Caoch {newCoach.Name} is Added Sucessfully", "SUCCESS",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Make Sure that you have entered all of the fields", "WAIT...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cannot Add the Coach\n" + exception.Message,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*adding all of the objects as the form loads*/
        private void CoachGUI_Load(object sender, EventArgs e)
        {
            foreach (var coach in this.Coaches)
            {
                lbCoaches.Items.Add(coach.Name);
            }
            foreach (var item in Swimmers)
            {
                lbAllSwimmer.Items.Add(item.Name);
            }
        }

        /*Displaing the Coach info based on the index Selected*/
        private void lbCoachs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var coach in Coaches)
                {
                    if (coach.Name == lbCoaches.SelectedItem.ToString())
                    {
                        lblInfo.Text = coach.ToStringGUI();
                        break;
                    }
                }
            }
            catch
            {  
            }
            try
            {
                if (Coaches[lbCoaches.SelectedIndex].Credentials == null)
                {
                    Coaches[lbCoaches.SelectedIndex].Credentials = "N/A";
                    txtCredential.Text = Coaches[lbCoaches.SelectedIndex].Credentials;
                }
                else
                {
                    txtCredential.Text = Coaches[lbCoaches.SelectedIndex].Credentials;
                }
                txtRegNo.Text = Coaches[lbCoaches.SelectedIndex].UniqueId.ToString();
                txtName.Text = Coaches[lbCoaches.SelectedIndex].Name;
                txtPhNo.Text = Coaches[lbCoaches.SelectedIndex].PhoneNumber.ToString();
                txtStreet.Text = Coaches[lbCoaches.SelectedIndex].Address.street;
                txtCity.Text = Coaches[lbCoaches.SelectedIndex].Address.city;
                txtPro.Text = Coaches[lbCoaches.SelectedIndex].Address.province;
                txtPostCode.Text = Coaches[lbCoaches.SelectedIndex].Address.postalCode;
                dtpDOB.Value = Coaches[lbCoaches.SelectedIndex].DateOfBirth;
            }
            catch
            {
            }
            //Showing the Swimmers that are Assigned to Selected Coach
            DisplayAssignedSwimmers();
        }

        /*ASsign Swimmer to the Coach*/
        private void btnAssignSwimmer_Click(object sender, EventArgs e)
        {
            sog.AddAssign();
            try
            {
                //Adding Swimmer to the Coach
                Coaches[lbCoaches.SelectedIndex].AddSwimmer(Swimmers[lbAllSwimmer.SelectedIndex]);
                DisplayAssignedSwimmers();
            }
            catch
            {
            }
        }

        //Updating Coach when uSer clicks the Button 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();
            try
            {
                Coaches[lbCoaches.SelectedIndex].Name = txtName.Text;
                Coaches[lbCoaches.SelectedIndex].Credentials = txtCredential.Text;
                Coaches[lbCoaches.SelectedIndex].DateOfBirth = dtpDOB.Value;
                Coaches[lbCoaches.SelectedIndex].PhoneNumber = long.Parse(txtPhNo.Text);
                Coaches[lbCoaches.SelectedIndex].Address.street = txtStreet.Text;
                Coaches[lbCoaches.SelectedIndex].Address.city = txtCity.Text;
                Coaches[lbCoaches.SelectedIndex].Address.province = txtPro.Text;
                Coaches[lbCoaches.SelectedIndex].Address.postalCode = txtPostCode.Text;
                lbCoaches.Items.Clear();
                lbCoaches.Update();

                foreach (var coach in this.Coaches)
                {
                    lbCoaches.Items.Add(coach.Name);
                }

                lblInfo.Text = "";
            }
            catch 
            {
                MessageBox.Show("Error in Upadting the info", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        //Removing coach form list and Listbox
        private void btnRemove_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();
            try
            {
                Coaches.RemoveAt(lbCoaches.SelectedIndex);
                lbCoaches.Items.Remove(lbCoaches.SelectedItem);
                lbCoaches.SelectedIndex = 0;
                lblInfo.Text = "";
                DefaultValues();
            }
            catch
            {
            }
        }

        /*Method to only show the Swimmer that Are asiigned to slecetd Coach*/
        private void DisplayAssignedSwimmers()
        {
            try
            {
                //Removing List of all /deafult Swimmer
                lbCoachSwimmers.Items.Clear();
                foreach (var item in RemoveUnssignedSwimmer(lbCoaches, Coaches).Swimmers)
                {
                    //Adding the Assigned Swimmer to the List
                    lbCoachSwimmers.Items.Add(item.Name);
                }
            }
            catch
            {
            }
        }

        /*Refining the Swimmer that Are not Assigned to the Coach*/
        private Coach RemoveUnssignedSwimmer(ListBox lsb, List<Coach> coaches)
        {
            Coach CoachWithSwimmer = null;
            try
            {
                foreach (var item in coaches)
                {
                    if (item.Name == lsb.SelectedItem.ToString())
                        return item;
                }
            }
            catch
            {
            }
            return CoachWithSwimmer;
        }

        /*Making Sure that User can Enter Text Only*/
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

        /*Making Sure That User can enter Number Only*/
        private void txtPhNo_KeyPress(object sender, KeyPressEventArgs e)
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

        //default value
        private void DefaultValues()
        {
            try
            {
                txtCredential.Text = "";
                txtName.Text = "";
                txtPhNo.Text = "";
                txtStreet.Text = "";
                txtCity.Text = "";
                txtPro.Text = "";
                txtPostCode.Text = "";
                dtpDOB.Value = DateTime.Now;
            }
            catch
            {
            }
            }

    }
}
