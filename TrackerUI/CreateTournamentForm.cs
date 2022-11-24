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
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form
    {
        List<TeamModel> availableTeams = GlobalConfig.Connections.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>(); 
        public CreateTournamentForm()
        {
            
            InitializeComponent();
            WireUpLists();
        }
       

        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = null;
            
            selectTeamDropDown.DataSource = availableTeams;//drop.displaymem takes string not just simple name
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            //518 397
            //467 166
            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";


        }
        private void teamOneScoreValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void entryFeeLabel_Click(object sender, EventArgs e)
        {

        }

        private void tournameNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void createTournamentDeleteSelectedButton_Click(object sender, EventArgs e)
        {

        }

        private void createNewLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void tournamentPlayersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void tournamentNameValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectTeamLabel_Click(object sender, EventArgs e)
        {

        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;

            if(t!=null)
            {
                availableTeams.Remove(t);
                selectedTeams.Add(t);

                WireUpLists();
            }
        }
    }
}
