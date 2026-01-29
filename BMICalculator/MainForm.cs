using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class MainForm : Form
    {

        private BMICalculator bmi_calc = new BMICalculator();
        private SavingCalculator s_calc = new SavingCalculator();

        public MainForm()
        {
            InitializeComponent();
            intilializeGUI();
        }

        public void intilializeGUI()
        {
            rbtnMetric.Checked = true;
            rbtnMetric.Enabled = true;
               
            rbtnImperial.Enabled = true;
            lblBMI.Text = string.Empty;
            lblCategory.Text = string.Empty; 
            lblRecomended.Text = "Recomended Weight: "+string.Empty;


            lblAmountPaid.Text = string.Empty;
            lblFinalBalance.Text = string.Empty;
        }

//-------------------------------------------------------------------------

        public void btnCalculate_Click(object sender, EventArgs e)
        {
             
            bool ok = true;
            readName();
            readHight();
            readWeight();
           
            
            lblResult.Text = bmi_calc.getName().ToUpper() + "'s results:";
            
            if (ok)
            {
                bool pass;
                double result;
                double recomended;
                if (rbtnImperial.Checked)
                  {
                    result = bmi_calc.Imperial( out pass);
                    recomended=bmi_calc.RecomendedWeightInLbs();
                    lblRecomended.Text = "Recomended weight for " + bmi_calc.getName().ToUpper() + " is " + recomended.ToString("f2")+" lbs";
                }
                else{
                    result = bmi_calc.Metric( out pass); 
                    recomended = bmi_calc.RecomendedWeightInKg();
                    lblRecomended.Text = "Recomended weight for " + bmi_calc.getName().ToUpper() + " is " + recomended.ToString("f2")+" kg";
                }

                if (pass)
                {
                    lblBMI.Text = result.ToString("f2");
                    lblCategory.Text = bmi_calc.Category(result);

                }
                else {
                    lblBMI.Text = "The calculation faild due to wrong value ";
                }
          
            
            }else {
                MessageBox.Show("Invalid Input");
              }

           
        }

        private void readName()
        {
            
           string name=  textName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                bmi_calc.setName(name);
            }
            else
            {
                bmi_calc.setName("Unknown"); 
            }
            
        }
        private bool readHight( )
        {
            bool pass;
            double hight;
            pass = double.TryParse(textHight.Text, out hight);
            bmi_calc.setHight(hight);
            return pass;
        }
        private bool readWeight()
        {
            bool pass;
            double weight;
            pass = double.TryParse(textWeight.Text, out weight);
            bmi_calc.setWeight(weight); 
            return pass;
        }

        //-----------------------------------------------------------------

        public void btnCalculateSaving_Click(object sender, EventArgs e)
        {
            bool ok=true;
           
            if (ok) {
            bool pass;
                readDeposit();
                readYears();

                s_calc.calculateSaving(out pass);

                if (pass) { 
                 lblAmountPaid.Text= s_calc.getAmount_paid().ToString("f2");
                lblFinalBalance.Text= s_calc.getBalance().ToString("f2");

                
                } else {

                    MessageBox.Show("The calculation faild due to wrong value ");     
                }
            
            
            }else {
                MessageBox.Show("Invalid Input");
            }

        }


        private bool readDeposit()
        {
            bool pass;
            double deposit;
            pass= double.TryParse(textDeposit.Text, out deposit);
            s_calc.setDeposit(deposit);
            return pass;
        }

        private bool readYears()
        {
            bool pass ;
            double years;
            pass = double.TryParse(textPeriod.Text, out years);
            s_calc.setYears(years);
            return pass;
        }












































        //----------------------------------------------------------

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblWeight_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void lblResult2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRecomended_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

       
    }
}
