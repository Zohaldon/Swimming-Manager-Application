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
    public partial class SwimmerGUI : Form
    {
        Home home;
        SwimmersManager swmMngr;
        ClubsManager clbMngr;
        List<Registrant> registrants;
        SoundforGUI sog = new SoundforGUI();

        /*fileds*/
        private List<Swimmer> swimmers;

        /*properties*/
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
        
        public SwimmerGUI()
        {
            InitializeComponent();
        }

        /*Loading all obeject as the forms load*/
        private void SwimmerGUI_Load(object sender, EventArgs e)
        {
            foreach (var swimmer in this.Swimmers)
            {
                lbSwimmers.Items.Add(swimmer.Name);
            }
        }

        /*Adding Swimmer to the Form*/
        private void btnAddSwimmer_Click(object sender, EventArgs e)
        {
            //Sound
            sog.AddAssign();

            /*Checking All fields for the Swimmers*/
            //Checking the Name 
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter your Name", "ERROR",
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
            //Checcking City
            if (string.IsNullOrEmpty(txtCity.Text))
            {
                MessageBox.Show("Please Enter your City", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Chacking the Phone
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
                //Adding Swimmer to the List
                if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtCity.Text)
                    || !string.IsNullOrEmpty(txtPro.Text) || !string.IsNullOrEmpty(txtPostCode.Text)
                    || !string.IsNullOrEmpty(txtStreet.Text))
                {
                    Swimmer newSwimmer = new Swimmer(txtName.Text, new DateTime(dtpDOB.Value.Year, dtpDOB.Value.Month, dtpDOB.Value.Day),
                        new Address(txtStreet.Text, txtCity.Text, txtPro.Text, txtPostCode.Text), phoneNo);

                    Swimmers.Add(newSwimmer);

                    home = new Home();
                    home.Swimmers = Swimmers;
                    lbSwimmers.Items.Add(newSwimmer.Name);
                    //Displaying Message
                    MessageBox.Show($"Swimmer {newSwimmer.Name} Added Sucessfully", "SUCCESS",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Make Sure that you have entered all of the fields","WAIT...",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }

                //set default value
                DefaultValues();

            }
            catch (Exception exception)
            {
                MessageBox.Show("Cannot Add the Swimmer\n" + exception.Message,
                    "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //Setting the Values to Default After Adding the Swimmer
        private void DefaultValues()
        {
            try
            {
                txtName.Text = "";
                txtPhNo.Text = "";
                txtStreet.Text = "";
                txtCity.Text = "";
                txtPro.Text = "";
                txtPostCode.Text = "";
                txtRegNo.Text = "";
                dtpDOB.Value = DateTime.Now;
            }
            catch
            {
            }
        }

        /*Updating the Simmers info as the index is changed*/
        private void lbSwimmers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var swimmer in Swimmers)
                {
                    if (swimmer.Name == lbSwimmers.SelectedItem.ToString())
                    {
                        lblInfo.Text = swimmer.ToString();
                        break;
                    }
                }
            }
            catch
            {   
            }

            try
            {
                txtRegNo.Text = Swimmers[lbSwimmers.SelectedIndex].UniqueId.ToString();
                txtName.Text = Swimmers[lbSwimmers.SelectedIndex].Name;
                txtPhNo.Text = Swimmers[lbSwimmers.SelectedIndex].PhoneNumber.ToString();
                txtStreet.Text = Swimmers[lbSwimmers.SelectedIndex].Address.street;
                txtCity.Text = Swimmers[lbSwimmers.SelectedIndex].Address.city;
                txtPro.Text = Swimmers[lbSwimmers.SelectedIndex].Address.province;
                txtPostCode.Text = Swimmers[lbSwimmers.SelectedIndex].Address.postalCode;
                dtpDOB.Value = Swimmers[lbSwimmers.SelectedIndex].DateOfBirth;
            }
            catch
            {
                
            }
        }

        /*Loading the Swimmer from the file*/
        private void btnLoadSwimmer_Click(object sender, EventArgs e)
        {
            //Sound
            sog.SaveLoad();
            if (txtLoadSwimmer.Text == "Double click me! or Enter the file path")
            {
                MessageBox.Show("Please provide the file path");
            }
            else
            {

                clbMngr = new ClubsManager();
                swmMngr = new SwimmersManager(clbMngr);
                try
                {
                    swmMngr.Load(txtLoadSwimmer.Text, ",");
                }

                catch (Exception exception)
                {
                    MessageBox.Show("Cannot load the club\n" + exception.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                foreach (var item in swmMngr.Swimmers)
                {
                    Swimmer newSwimmer;
                    newSwimmer = new Swimmer(item.Name, item.DateOfBirth, item.Address, item.PhoneNumber);
                    //Adding Swimmer to the list
                    Swimmers.Add(newSwimmer);
                    //adding Swimmer to the list
                    lbSwimmers.Items.Add(newSwimmer.Name);
                }
            }
        }

        //Updating the Swimmer when user Clicks the Update button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();

            try
            {
                Swimmers[lbSwimmers.SelectedIndex].Name = txtName.Text;
                Swimmers[lbSwimmers.SelectedIndex].DateOfBirth = dtpDOB.Value;
                Swimmers[lbSwimmers.SelectedIndex].PhoneNumber = long.Parse(txtPhNo.Text);
                Swimmers[lbSwimmers.SelectedIndex].Address.street = txtStreet.Text;
                Swimmers[lbSwimmers.SelectedIndex].Address.city = txtCity.Text;
                Swimmers[lbSwimmers.SelectedIndex].Address.province = txtPro.Text;
                Swimmers[lbSwimmers.SelectedIndex].Address.postalCode = txtPostCode.Text;
                lbSwimmers.Items.Clear();
                lbSwimmers.Update();

                foreach (var swimmer in this.Swimmers)
                {
                    lbSwimmers.Items.Add(swimmer.Name);
                }

                lblInfo.Text = "";
                MessageBox.Show("Selected Swimmer updated Sucessfully", "SUCESS",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Error in Upadting the info", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        //Removing the Event From  the list and listbox 
        private void btnRemoveSwimmer_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();
            try
            {
                Swimmers.RemoveAt(lbSwimmers.SelectedIndex);
                lbSwimmers.Items.Remove(lbSwimmers.SelectedItem);
                lbSwimmers.SelectedIndex = 0;
                lblInfo.Text = "";
                DefaultValues();
                MessageBox.Show("Selected Swimmer deleted Sucessfully","SUCESS",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch
            {

            }
        }

        /*Saving the Swimmer from the file*/
        private void btnSaveSwimmer_Click(object sender, EventArgs e)
        {
            sog.SaveLoad();
            if (txtLoadSwimmer.Text == "Double click me! or Enter the file path")
            {
                MessageBox.Show("Please provide the file path");
            }
            else
            {
                try
                {
                    clbMngr = new ClubsManager();
                    swmMngr = new SwimmersManager(clbMngr);
                    swmMngr.Swimmers.Clear();

                    //Adding the Swimmer to regsitratnt
                    registrants = new List<Registrant>();

                    /*Adding Swimmer to the list of registrant as well*/
                    foreach (var swimmer in Swimmers)
                    {
                        Registrant newswimmer = new Registrant(swimmer.Name, swimmer.DateOfBirth, swimmer.Address, swimmer.PhoneNumber);
                        swmMngr.Swimmers.Add(newswimmer);
                    }

                    //Saving the file
                    swmMngr.Save(txtSaveSwimmer.Text, ",");
                }
                catch
                {
                    MessageBox.Show("Error in Saving the Swimemr to the File", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                
            
        }

        /*Alternative of providing the file path for LOAD Swimmer*/
        private void txtLoadSwimmer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialogSwimmer.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtLoadSwimmer.Text = openFileDialogSwimmer.FileName;
                }
            }
            catch
            {
            }

        }

        /*Alternative of providing the file path for SAVE Swimmer*/
        private void txtSaveSwimmer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = saveFileDialogSwimmer.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtSaveSwimmer.Text = saveFileDialogSwimmer.FileName;
                }

            }
            catch
            {
            } 
        }

        /*Accepts Letters only*/
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsLetter(e.KeyChar))
            {
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            else if (Char.IsWhiteSpace(e.KeyChar))
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        /*Accepts Digits only*/
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
    }
}
