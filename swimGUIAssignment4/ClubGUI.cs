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
    public partial class ClubGUI : Form
    {
        Home home;
        ClubsManager clbMngr;
        SoundforGUI sog = new SoundforGUI();

        /*fields*/
        private List<Club> clubs;
        private List<Swimmer> swimmers;
        private List<Coach> coaches;

        /*Properties*/
        public List<Club> Clubs
        {
            set
            {
                clubs = value;
            }
            get
            {
                return clubs;
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

        public ClubGUI()
        {
            InitializeComponent();
        }

        /* Loading the  clubs and registraants as the form is loaded*/
        private void ClubGUI_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var club in Clubs)
                {
                    lbClubs.Items.Add(club.Name);
                }
                foreach (var swimmer in Swimmers)
                {
                    lbSwimmerCoach.Items.Add(swimmer.Name);
                }
            }
            catch
            {

            }
        }

        //Displaying Info of Club based on Selection
        private void lbClubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var club in Clubs)
                {
                    //Showing Info for Selcetd club: if found show info and break the loop[
                    if (club.Name == lbClubs.SelectedItem.ToString())
                    {
                        lblInfoC.Text = club.ToStringGUI();
                        break;
                    }
                }
            }
            catch
            {

            }
            try
            {
                //Setting the vakue basedc on user input
                txtRegNo.Text = Clubs[lbClubs.SelectedIndex].UniqueId.ToString();
                txtName.Text = Clubs[lbClubs.SelectedIndex].Name;
                txtPhNo.Text = Clubs[lbClubs.SelectedIndex].PhoneNumber.ToString();
                txtStreet.Text = Clubs[lbClubs.SelectedIndex].Address.street;
                txtCity.Text = Clubs[lbClubs.SelectedIndex].Address.city;
                txtPro.Text = Clubs[lbClubs.SelectedIndex].Address.province;
                txtPostCode.Text = Clubs[lbClubs.SelectedIndex].Address.postalCode;
            }
            catch
            {
            }
            //Displaying Regostrant in list box
            ShowRegistrant();
        }

        //Showing Registrants Based on the Radio Button Selection 
        private void ShowRegistrant()
        {
            try
            {
                lbClubSwimmerCoach.Items.Clear();
                if (rbSwimmerC.Checked)
                {
                    foreach (var item in ReturnObjectClub(lbClubs, Clubs).Swimmers)
                    {
                        lbClubSwimmerCoach.Items.Add(item.Name);
                    }

                }

                else
                {
                    foreach (var item in ReturnObjectClub(lbClubs, Clubs).Coaches)
                    {
                        lbClubSwimmerCoach.Items.Add(item.Name);
                    }
                }
            }
            catch
            {

            }
        }

        //Loading the Club from the file specifed
        private void btnLoad_Click(object sender, EventArgs e)
        {
            sog.SaveLoad();
            try
            {
                clbMngr = new ClubsManager();
                // Getting the file path
                clbMngr.Load(txtLoad.Text, ",");
                Clubs.AddRange(clbMngr.Clubs);

                //Adding Club to list
                foreach (var club in clbMngr.Clubs)
                {
                    lbClubs.Items.Add(club.Name);
                }
            }
            catch
            {
                MessageBox.Show("Error in loading the Clubs.\nMake Sure that you have provided correct path",
                    "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        //Load dialogue box
        private void txtLoad_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtLoad.Text = openFileDialog1.FileName;
                }
            }
            catch
            {
                MessageBox.Show("Error in loading the Clubs.\nMake Sure that you have provided correct path",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        //Saving the Club from the File Specified 
        private void btnSave_Click(object sender, EventArgs e)
        {
            sog.SaveLoad();
            try
            {
                if (txtSave.Text != "Double Click me! or  Enter the path")
                {
                    clbMngr = new ClubsManager();
                    // Saving Culb tp file specifed
                    clbMngr.Clubs = Clubs;
                    clbMngr.Save(txtSave.Text, "|");
                    MessageBox.Show("File saved Successfully .",
                    "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(txtSave.Text == "Double Click me! or  Enter the path")
                {
                    MessageBox.Show("Please enter the correct path for the file to be saved .",
                    "WAIT...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Error in Saving the Clubs.",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        //Save dialogue box
        private void txtSave_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtSave.Text = saveFileDialog1.FileName;
                }
            }
            catch 
            {
                MessageBox.Show("Error in Saving the Clubs.",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Changing the list box as the radio button is changed
        private void rbAddSwimmer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lbSwimmerCoach.Items.Clear();
                if (rbAddSwimmer.Checked)
                {
                    foreach (var swimmer in Swimmers)
                    {
                        lbSwimmerCoach.Items.Add(swimmer.Name);
                    }
                }
                else
                {
                    foreach (var coach in Coaches)
                    {
                        lbSwimmerCoach.Items.Add(coach.Name);
                    }
                }
            }
            catch
            {
            }
        }

        //Assign Selceted Swimmer or Coach to the CLub
        private void btnAssign_Click(object sender, EventArgs e)
        {
            sog.AddAssign();
            try
            {
                if (rbAddSwimmer.Checked)
                {
                    foreach (var swimmer in Swimmers)
                    {
                        if (swimmer.Name == lbSwimmerCoach.SelectedItem.ToString())
                        {
                            ReturnObjectClub(lbClubs, Clubs).AddSwimmer(swimmer);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var coach in Coaches)
                    {
                        if (coach.Name == lbSwimmerCoach.SelectedItem.ToString())
                        {
                            ReturnObjectClub(lbClubs, Clubs).AddCoach(coach);
                            break;
                        }
                    }
                }

                foreach (var club in Clubs)
                {
                    if (club.Name == lbClubs.SelectedItem.ToString())
                    {
                        lblInfoC.Text = club.ToStringGUI();
                        break;
                    }
                }
               
                ShowRegistrant();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        //Adding new Club to the list
        private void btnAdd_Click(object sender, EventArgs e)
        {
            sog.AddAssign();
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter your Name", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtCity.Text == "")
            {
                txtCity.Text = "N/A";
            }
            long phoneNo = 0;
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
                Club newClub = new Club(txtName.Text,new Address(txtStreet.Text, txtCity.Text, txtPro.Text, txtPostCode.Text),phoneNo);
                Clubs.Add(newClub);

                home = new Home();
                home.Clubs = Clubs;
                lbClubs.Items.Add(newClub.Name);
                //Displaying Message
                MessageBox.Show($"Club {newClub.Name} Added Sucessfully", "SUCCESS",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DefaultValues();
            }
            catch 
            {
                
            }
        }

        //Default value for text fileds
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
            }
            catch
            {
            }
        }

        //Extracting the CLub form the list based on the name of the club 
        private Club ReturnObjectClub(ListBox lb, List<Club> clubs)
        {
            Club newClub = null;
            try
            {
                foreach (var item in clubs)
                {
                    if (item.Name == lb.SelectedItem.ToString())
                    {
                        return item;
                    }
                }

            }
            catch
            {

            }
            return newClub;
        }


        //Deleting the Club form the list
        private void btnDelete_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();
            try
            {
                Clubs.RemoveAt(lbClubs.SelectedIndex);
                lbClubs.Items.Remove(lbClubs.SelectedItem);
                lbClubs.SelectedIndex = 0;
                lblInfoC.Text = "";
                DefaultValues();
            }
            catch
            {
            }
        }

        //Updating the Club info
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sog.UpdateDelete();
            try
            {
                Clubs[lbClubs.SelectedIndex].Name = txtName.Text;
                Clubs[lbClubs.SelectedIndex].PhoneNumber = long.Parse(txtPhNo.Text);
                Clubs[lbClubs.SelectedIndex].Address.street = txtStreet.Text;
                Clubs[lbClubs.SelectedIndex].Address.city = txtCity.Text;
                Clubs[lbClubs.SelectedIndex].Address.province = txtPro.Text;
                Clubs[lbClubs.SelectedIndex].Address.postalCode = txtPostCode.Text;
                lbClubs.Items.Clear();
                lbClubs.Update();

                foreach (var club in this.Clubs)
                {
                    lbClubs.Items.Add(club.Name);
                }
            }
            catch
            {
            }
            lblInfoC.Text = "";
        }

        //getting Swimmer and Coach related to the clubb
        private void rbSwimmerC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //To Avoid the Reduncancy
                lbClubSwimmerCoach.Items.Clear();
                if (rbSwimmerC.Checked)
                {
                    foreach (var swimmer in ReturnObjectClub(lbClubs, Clubs).Swimmers)
                    {
                        lbClubSwimmerCoach.Items.Add(swimmer.Name);
                    }
                }
                else
                {
                    foreach (var coach in ReturnObjectClub(lbClubs, Clubs).Coaches)
                    {
                        lbClubSwimmerCoach.Items.Add(coach.Name);
                    }
                }
            }
            catch
            {
            }
        }

        //Showing the information of Swimmer and Coacj on the Bassiss of Selection
        private void lbClubSwimmerCoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbSwimmerC.Checked)
                {
                    foreach (var swimmer in Swimmers)
                    {
                        if (swimmer.Name == lbClubSwimmerCoach.SelectedItem.ToString())
                        {
                            lbInfoR.Text = swimmer.ToString();
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var coach in Coaches)
                    {
                        if (coach.Name == lbClubSwimmerCoach.SelectedItem.ToString())
                        {
                            lbInfoR.Text = coach.ToString();
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        //Restricting user to enter letters only
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
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

        //Restricting user to enter numbers only
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
