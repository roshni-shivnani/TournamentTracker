using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            InitializeComponent();

            //CreateSampleData();

            WireUpLists();

        }



        private void createTournamentLabel_Click(object sender, EventArgs e)
        {

        }

        private void tournamentNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void tournamentNameValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click(object sender, EventArgs e)
        {

        }

        private void selectTeamMemberDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createMemberLabel_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateForm()
        {
            //TO DO the Vldation
            if(firstNameValue.Text.Length==0)
            {
                return false;  
            }
            if(lastNameValue.Text.Length==0)
            {
                return false;
            }
            if (emailValue.Text.Length == 0)
            {
                return false;
            }
            if (cellPhoneValue.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress= emailValue.Text;
                p.CellPhoneNumber= cellPhoneValue.Text;

                p=GlobalConfig.Connections.CreatePerson(p);

                selectedTeamMembers.Add(p);
                WireUpLists();


                firstNameValue.Text="";
                lastNameValue.Text="";
                emailValue.Text="";
                cellPhoneValue.Text="";

            }
            else
            {
                MessageBox.Show("You need to fill all of the fields.");
            }
        }

        private List<PersonModel> availableTeamMembers = GlobalConfig.Connections.GetPerson_All();//addmemeber lib -sel list dropdown wireup

        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();//selected members disay in right side box

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Jane", LastName = "Smith" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
        }
        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;
            
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember= "FullName";
        }

        private void addTeamButton_Click(object sender,EventArgs e)//addmemebr wire up
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;
            if (p!=null)
            { 
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();  //dont use drip.refesh instrad in a func set dta src null 
            }
        }
        private void button3_Click(object sender,EventArgs e)
        {

        }

        private void createTournamentdeleteSelectedPlayerButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;
            if (p!=null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }

        }

        private void createTeamButton_Click(object sender,EventArgs e)
        {
            TeamModel t = new TeamModel();

            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            t = GlobalConfig.Connections.CreateTeam(t);
        }
    }
}
