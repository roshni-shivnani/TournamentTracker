using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrackerUI
{
    public partial class CreatePrize : Form
    {
        public CreatePrize()
        {
            InitializeComponent();
            this.Controls.Clear();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(placeNameValue.Text, placeNumberValue.Text, prizeAmountValue.Text, prizePercentageValue.Text);
                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }
                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmountValue.Text = "0";
                prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again");
            }
            
        }
        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);


    if (placeNumberValidNumber == false)
            {
                output = false;
            }
            
            if (placeNumber < 1)
            {
                output = false;
            }
            if(placeNameValue.Text.Length==0)
            {
                output = false;
            }
            decimal prizeAmount = 0;
            decimal prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid= decimal.TryParse(prizePercentageValue.Text, out prizePercentage);
            if (prizeAmountValid == false || prizePercentageValid == false)
            {
                output = false;
            }
            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }
            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }
            return output;//prop to 0,0 amt& ercnt
            }
        //private void label1_Click(object sender,EventArgs e)
        //{

        //}
        //private void placeNumberValue_Changed(object sender, EventArgs e)
        //{

        //}
        //private void label1_Click_1(object sender,EventArgs e)
        //{

        //}
        private void CreatePrize_Load(object sender,EventArgs e)
        {

        }
    }
}
