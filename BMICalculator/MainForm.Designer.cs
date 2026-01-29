namespace Assignment3
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnMetric = new System.Windows.Forms.RadioButton();
            this.rbtnImperial = new System.Windows.Forms.RadioButton();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblResult1 = new System.Windows.Forms.Label();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.lblRecomended = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.textHight = new System.Windows.Forms.TextBox();
            this.textWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBMI = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textPeriod = new System.Windows.Forms.TextBox();
            this.textDeposit = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFinalBalance = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCalculateSaving = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(566, 308);
            this.label1.TabIndex = 0;
            this.label1.Text = "BMI Calculator";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hight(m,ft):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Weight(kg,lb):";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // rbtnMetric
            // 
            this.rbtnMetric.AutoSize = true;
            this.rbtnMetric.BackColor = System.Drawing.SystemColors.ControlDark;
            this.rbtnMetric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMetric.Location = new System.Drawing.Point(16, 46);
            this.rbtnMetric.Name = "rbtnMetric";
            this.rbtnMetric.Size = new System.Drawing.Size(184, 33);
            this.rbtnMetric.TabIndex = 9;
            this.rbtnMetric.Text = "Metric (kg,m).";
            this.rbtnMetric.UseVisualStyleBackColor = false;
            // 
            // rbtnImperial
            // 
            this.rbtnImperial.AutoSize = true;
            this.rbtnImperial.BackColor = System.Drawing.SystemColors.ControlDark;
            this.rbtnImperial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnImperial.Location = new System.Drawing.Point(16, 94);
            this.rbtnImperial.Name = "rbtnImperial";
            this.rbtnImperial.Size = new System.Drawing.Size(203, 33);
            this.rbtnImperial.TabIndex = 10;
            this.rbtnImperial.Text = "Imperial (ft,lbs).";
            this.rbtnImperial.UseVisualStyleBackColor = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(157, 331);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(223, 44);
            this.btnCalculate.TabIndex = 11;
            this.btnCalculate.Text = "Calculate BMI";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(27, 383);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(573, 351);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = " Result";
            this.lblResult.Click += new System.EventHandler(this.lblResult_Click);
            // 
            // lblResult1
            // 
            this.lblResult1.AutoSize = true;
            this.lblResult1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblResult1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult1.Location = new System.Drawing.Point(104, 437);
            this.lblResult1.Name = "lblResult1";
            this.lblResult1.Size = new System.Drawing.Size(135, 29);
            this.lblResult1.TabIndex = 13;
            this.lblResult1.Text = "BMI Result:";
            // 
            // lblResult2
            // 
            this.lblResult2.AutoSize = true;
            this.lblResult2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblResult2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult2.Location = new System.Drawing.Point(42, 518);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(197, 29);
            this.lblResult2.TabIndex = 15;
            this.lblResult2.Text = "Weight Category:";
            this.lblResult2.Click += new System.EventHandler(this.lblResult2_Click);
            // 
            // lblRecomended
            // 
            this.lblRecomended.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblRecomended.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecomended.ForeColor = System.Drawing.Color.Olive;
            this.lblRecomended.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblRecomended.Location = new System.Drawing.Point(37, 646);
            this.lblRecomended.Name = "lblRecomended";
            this.lblRecomended.Size = new System.Drawing.Size(543, 65);
            this.lblRecomended.TabIndex = 17;
            this.lblRecomended.Text = "Recomended Weight";
            this.lblRecomended.Click += new System.EventHandler(this.lblRecomended_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(157, 149);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(209, 26);
            this.textName.TabIndex = 18;
            // 
            // textHight
            // 
            this.textHight.Location = new System.Drawing.Point(214, 196);
            this.textHight.Name = "textHight";
            this.textHight.Size = new System.Drawing.Size(152, 26);
            this.textHight.TabIndex = 19;
            // 
            // textWeight
            // 
            this.textWeight.Location = new System.Drawing.Point(214, 257);
            this.textWeight.Name = "textWeight";
            this.textWeight.Size = new System.Drawing.Size(152, 26);
            this.textWeight.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(78, 587);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(468, 59);
            this.label6.TabIndex = 23;
            this.label6.Text = "Normal BMI is between 18.50 and 25.";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // lblBMI
            // 
            this.lblBMI.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblBMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBMI.Location = new System.Drawing.Point(254, 400);
            this.lblBMI.Name = "lblBMI";
            this.lblBMI.Size = new System.Drawing.Size(270, 66);
            this.lblBMI.TabIndex = 24;
            this.lblBMI.Text = ".....";
            this.lblBMI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCategory
            // 
            this.lblCategory.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(254, 502);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(292, 60);
            this.lblCategory.TabIndex = 25;
            this.lblCategory.Text = "......";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.rbtnMetric);
            this.groupBox1.Controls.Add(this.rbtnImperial);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(327, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 131);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unit";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textPeriod);
            this.groupBox2.Controls.Add(this.textDeposit);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(634, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 213);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saving Plan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 29);
            this.label7.TabIndex = 3;
            this.label7.Text = "Period (years)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "Monthly Deposit";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // textPeriod
            // 
            this.textPeriod.Location = new System.Drawing.Point(256, 130);
            this.textPeriod.Name = "textPeriod";
            this.textPeriod.Size = new System.Drawing.Size(199, 35);
            this.textPeriod.TabIndex = 1;
            // 
            // textDeposit
            // 
            this.textDeposit.Location = new System.Drawing.Point(256, 69);
            this.textDeposit.Name = "textDeposit";
            this.textDeposit.Size = new System.Drawing.Size(199, 35);
            this.textDeposit.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox3.Controls.Add(this.lblFinalBalance);
            this.groupBox3.Controls.Add(this.lblAmountPaid);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(634, 400);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(506, 238);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Future Value";
            // 
            // lblFinalBalance
            // 
            this.lblFinalBalance.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFinalBalance.Location = new System.Drawing.Point(208, 149);
            this.lblFinalBalance.Name = "lblFinalBalance";
            this.lblFinalBalance.Size = new System.Drawing.Size(217, 51);
            this.lblFinalBalance.TabIndex = 3;
            this.lblFinalBalance.Text = ".....";
            this.lblFinalBalance.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblAmountPaid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAmountPaid.Location = new System.Drawing.Point(222, 79);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(203, 47);
            this.lblAmountPaid.TabIndex = 2;
            this.lblAmountPaid.Text = ".....";
            this.lblAmountPaid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 29);
            this.label9.TabIndex = 1;
            this.label9.Text = "Final Balance:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Amount Paid:";
            // 
            // btnCalculateSaving
            // 
            this.btnCalculateSaving.BackColor = System.Drawing.Color.LightSalmon;
            this.btnCalculateSaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculateSaving.Location = new System.Drawing.Point(791, 331);
            this.btnCalculateSaving.Name = "btnCalculateSaving";
            this.btnCalculateSaving.Size = new System.Drawing.Size(209, 63);
            this.btnCalculateSaving.TabIndex = 29;
            this.btnCalculateSaving.Text = "Calculate Saving";
            this.btnCalculateSaving.UseVisualStyleBackColor = false;
            this.btnCalculateSaving.Click += new System.EventHandler(this.btnCalculateSaving_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1989, 1014);
            this.Controls.Add(this.btnCalculateSaving);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblBMI);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textWeight);
            this.Controls.Add(this.textHight);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.lblRecomended);
            this.Controls.Add(this.lblResult2);
            this.Controls.Add(this.lblResult1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ahmed Algabri BMI Calculator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnMetric;
        private System.Windows.Forms.RadioButton rbtnImperial;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblResult1;
        private System.Windows.Forms.Label lblResult2;
        private System.Windows.Forms.Label lblRecomended;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textHight;
        private System.Windows.Forms.TextBox textWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBMI;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPeriod;
        private System.Windows.Forms.TextBox textDeposit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCalculateSaving;
        private System.Windows.Forms.Label lblFinalBalance;
        private System.Windows.Forms.Label lblAmountPaid;
    }
}

