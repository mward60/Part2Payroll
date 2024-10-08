using System;
using System.Data;
using System.Windows.Forms;

namespace Part2Payroll
{
    public partial class Form1 : Form
    {
        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("EmployeeID", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("HoursWorked", typeof(decimal)); // Changed to Decimal
            table.Columns.Add("Salary", typeof(decimal)); // Changed to Decimal
            table.Columns.Add("StateTaxRate", typeof(decimal)); // Changed to Decimal
            table.Columns.Add("FederalTaxRate", typeof(decimal)); // Changed to Decimal
            table.Columns.Add("YtdState", typeof(decimal)); // Changed to Decimal
            table.Columns.Add("YtdFederal", typeof(decimal)); // Changed to Decimal
            table.Columns.Add("YtdTaxTotal", typeof(decimal)); // Changed to Decimal
            table.Columns.Add("YtdTotal", typeof(decimal)); // Changed to Decimal
            dataGridView1.DataSource = table;
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Please enter valid data in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the calculated totals
            decimal totalAfterTax = decimal.Parse(txtTotalAfterTax.Text, System.Globalization.NumberStyles.Currency);
            decimal totalTax = decimal.Parse(txtTotalTax.Text, System.Globalization.NumberStyles.Currency);

            table.Rows.Add(
                txtEmployeeID.Text,
                txtEmployeeName.Text,
                decimal.Parse(txtHours.Text),
                decimal.Parse(txtSalary.Text),
                decimal.Parse(txtStateTax.Text),
                decimal.Parse(txtFederalTax.Text),
                decimal.Parse(txtYtdState.Text),
                decimal.Parse(txtYtdFederal.Text),
                totalTax,
                totalAfterTax);

            ClearInputs();
        }

        private void bttView_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index > -1)
            {
                LoadDataIntoInputs(index);
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index > -1)
            {
                table.Rows[index].Delete();
            }
        }

        private void txtHours_TextChanged(object sender, EventArgs e) => CalculateTotal();
        private void txtSalary_TextChanged(object sender, EventArgs e) => CalculateTotal();
        private void txtStateTax_TextChanged(object sender, EventArgs e) => CalculateTotal();
        private void txtFederalTax_TextChanged(object sender, EventArgs e) => CalculateTotal();

        private void CalculateTotal()
        {
            // Try to parse inputs for hours worked, salary, state tax rate, and federal tax rate
            if (!decimal.TryParse(txtHours.Text, out var hoursWorked) ||
                !decimal.TryParse(txtSalary.Text, out var salary) ||
                !decimal.TryParse(txtStateTax.Text, out var stateTaxRate) ||
                !decimal.TryParse(txtFederalTax.Text, out var federalTaxRate))
            {
                // Clear the total tax and after-tax fields if input is invalid
                txtTotalTax.Clear();
                txtTotalAfterTax.Clear();
                return; // Exit early if any input is invalid
            }

            // Calculate total gross pay based on hours worked and salary
            decimal totalGrossPay = hoursWorked * salary;

            // Calculate state and federal taxes based on the gross pay
            decimal totalStateTax = totalGrossPay * (stateTaxRate / 100);
            decimal totalFederalTax = totalGrossPay * (federalTaxRate / 100);
            decimal totalTaxes = totalStateTax + totalFederalTax;

            // Calculate total after tax
            decimal totalAfterTax = totalGrossPay - totalTaxes;

            // Display results formatted as currency
            txtTotalTax.Text = totalTaxes.ToString("C");
            txtTotalAfterTax.Text = totalAfterTax.ToString("C");
        }
        private void ClearInputs()
        {
            txtEmployeeID.Clear();
            txtEmployeeName.Clear();
            txtHours.Clear();
            txtSalary.Clear();
            txtStateTax.Clear();
            txtFederalTax.Clear();
            txtTotalTax.Clear();
            txtTotalAfterTax.Clear();
            txtYtdState.Clear();
            txtYtdFederal.Clear();
            txtYtdTotalTax.Clear();
            txtYtdTotal.Clear();
        }

        private bool ValidateInputs()
        {
            return !string.IsNullOrWhiteSpace(txtEmployeeID.Text) &&
                   !string.IsNullOrWhiteSpace(txtEmployeeName.Text) &&
                   decimal.TryParse(txtHours.Text, out _) &&
                   decimal.TryParse(txtSalary.Text, out _) &&
                   decimal.TryParse(txtStateTax.Text, out _) &&
                   decimal.TryParse(txtFederalTax.Text, out _) &&
                   decimal.TryParse(txtYtdState.Text, out _) &&
                   decimal.TryParse(txtYtdFederal.Text, out _);
        }

        private void LoadDataIntoInputs(int index)
        {
            txtEmployeeID.Text = table.Rows[index]["EmployeeID"].ToString();
            txtEmployeeName.Text = table.Rows[index]["Name"].ToString();
            txtHours.Text = table.Rows[index]["HoursWorked"].ToString();
            txtSalary.Text = table.Rows[index]["Salary"].ToString();
            txtStateTax.Text = table.Rows[index]["StateTaxRate"].ToString();
            txtFederalTax.Text = table.Rows[index]["FederalTaxRate"].ToString();
            txtYtdState.Text = table.Rows[index]["YtdState"].ToString();
            txtYtdFederal.Text = table.Rows[index]["YtdFederal"].ToString();
            txtTotalTax.Text = table.Rows[index]["YtdTaxTotal"].ToString();
            txtTotalAfterTax.Text = table.Rows[index]["YtdTotal"].ToString();
        }
    }
}