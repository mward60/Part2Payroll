namespace Part2Payroll
{
    partial class Form1
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
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bttNew = new System.Windows.Forms.Button();
            this.bttSave = new System.Windows.Forms.Button();
            this.bttView = new System.Windows.Forms.Button();
            this.bttDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStateTax = new System.Windows.Forms.TextBox();
            this.txtFederalTax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalTax = new System.Windows.Forms.TextBox();
            this.txtTotalAfterTax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtYtdState = new System.Windows.Forms.TextBox();
            this.txtYtdFederal = new System.Windows.Forms.TextBox();
            this.txtYtdTotalTax = new System.Windows.Forms.TextBox();
            this.txtYtdTotal = new System.Windows.Forms.TextBox();
            this.bttCalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee Name";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(129, 37);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(142, 22);
            this.txtEmployeeID.TabIndex = 2;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(429, 31);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(142, 22);
            this.txtEmployeeName.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(41, 281);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(728, 116);
            this.dataGridView1.TabIndex = 9;
            // 
            // bttNew
            // 
            this.bttNew.Location = new System.Drawing.Point(54, 236);
            this.bttNew.Name = "bttNew";
            this.bttNew.Size = new System.Drawing.Size(117, 39);
            this.bttNew.TabIndex = 5;
            this.bttNew.Text = "New";
            this.bttNew.UseVisualStyleBackColor = true;
            this.bttNew.Click += new System.EventHandler(this.bttNew_Click);
            // 
            // bttSave
            // 
            this.bttSave.Location = new System.Drawing.Point(187, 236);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(130, 39);
            this.bttSave.TabIndex = 6;
            this.bttSave.Text = "Save";
            this.bttSave.UseVisualStyleBackColor = true;
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // bttView
            // 
            this.bttView.Location = new System.Drawing.Point(339, 236);
            this.bttView.Name = "bttView";
            this.bttView.Size = new System.Drawing.Size(120, 39);
            this.bttView.TabIndex = 7;
            this.bttView.Text = "View";
            this.bttView.UseVisualStyleBackColor = true;
            this.bttView.Click += new System.EventHandler(this.bttView_Click);
            // 
            // bttDelete
            // 
            this.bttDelete.Location = new System.Drawing.Point(484, 236);
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(113, 39);
            this.bttDelete.TabIndex = 8;
            this.bttDelete.Text = "Delete";
            this.bttDelete.UseVisualStyleBackColor = true;
            this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hours Worked";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Salary";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(228, 89);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(100, 22);
            this.txtHours.TabIndex = 13;
            this.txtHours.TextChanged += new System.EventHandler(this.txtHours_TextChanged);
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(228, 129);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(100, 22);
            this.txtSalary.TabIndex = 14;
            this.txtSalary.TextChanged += new System.EventHandler(this.txtSalary_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(366, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "State Tax";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Federal Tax";
            // 
            // txtStateTax
            // 
            this.txtStateTax.Location = new System.Drawing.Point(441, 129);
            this.txtStateTax.Name = "txtStateTax";
            this.txtStateTax.Size = new System.Drawing.Size(100, 22);
            this.txtStateTax.TabIndex = 17;
            // 
            // txtFederalTax
            // 
            this.txtFederalTax.Location = new System.Drawing.Point(441, 92);
            this.txtFederalTax.Name = "txtFederalTax";
            this.txtFederalTax.Size = new System.Drawing.Size(100, 22);
            this.txtFederalTax.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(336, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Total After Tax";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(366, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Total Tax";
            // 
            // txtTotalTax
            // 
            this.txtTotalTax.Location = new System.Drawing.Point(441, 163);
            this.txtTotalTax.Name = "txtTotalTax";
            this.txtTotalTax.Size = new System.Drawing.Size(100, 22);
            this.txtTotalTax.TabIndex = 21;
            // 
            // txtTotalAfterTax
            // 
            this.txtTotalAfterTax.Location = new System.Drawing.Point(441, 198);
            this.txtTotalAfterTax.Name = "txtTotalAfterTax";
            this.txtTotalAfterTax.Size = new System.Drawing.Size(100, 22);
            this.txtTotalAfterTax.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(581, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Ytd State";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(565, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Ytd Federal";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(561, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "Ytd Total tax";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(581, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Ytd Total";
            // 
            // txtYtdState
            // 
            this.txtYtdState.Location = new System.Drawing.Point(669, 95);
            this.txtYtdState.Name = "txtYtdState";
            this.txtYtdState.Size = new System.Drawing.Size(100, 22);
            this.txtYtdState.TabIndex = 27;
            // 
            // txtYtdFederal
            // 
            this.txtYtdFederal.Location = new System.Drawing.Point(669, 132);
            this.txtYtdFederal.Name = "txtYtdFederal";
            this.txtYtdFederal.Size = new System.Drawing.Size(100, 22);
            this.txtYtdFederal.TabIndex = 28;
            // 
            // txtYtdTotalTax
            // 
            this.txtYtdTotalTax.Location = new System.Drawing.Point(669, 166);
            this.txtYtdTotalTax.Name = "txtYtdTotalTax";
            this.txtYtdTotalTax.Size = new System.Drawing.Size(100, 22);
            this.txtYtdTotalTax.TabIndex = 29;
            // 
            // txtYtdTotal
            // 
            this.txtYtdTotal.Location = new System.Drawing.Point(669, 204);
            this.txtYtdTotal.Name = "txtYtdTotal";
            this.txtYtdTotal.Size = new System.Drawing.Size(100, 22);
            this.txtYtdTotal.TabIndex = 30;
            // 
            // bttCalculate
            // 
            this.bttCalculate.Location = new System.Drawing.Point(604, 236);
            this.bttCalculate.Name = "bttCalculate";
            this.bttCalculate.Size = new System.Drawing.Size(165, 39);
            this.bttCalculate.TabIndex = 31;
            this.bttCalculate.Text = "Calculate";
            this.bttCalculate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttCalculate);
            this.Controls.Add(this.txtYtdTotal);
            this.Controls.Add(this.txtYtdTotalTax);
            this.Controls.Add(this.txtYtdFederal);
            this.Controls.Add(this.txtYtdState);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTotalAfterTax);
            this.Controls.Add(this.txtTotalTax);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFederalTax);
            this.Controls.Add(this.txtStateTax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bttDelete);
            this.Controls.Add(this.bttView);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.bttNew);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TextChanged += new System.EventHandler(this.txtHours_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bttNew;
        private System.Windows.Forms.Button bttSave;
        private System.Windows.Forms.Button bttView;
        private System.Windows.Forms.Button bttDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStateTax;
        private System.Windows.Forms.TextBox txtFederalTax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalTax;
        private System.Windows.Forms.TextBox txtTotalAfterTax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtYtdState;
        private System.Windows.Forms.TextBox txtYtdFederal;
        private System.Windows.Forms.TextBox txtYtdTotalTax;
        private System.Windows.Forms.TextBox txtYtdTotal;
        private System.Windows.Forms.Button bttCalculate;
    }
}

