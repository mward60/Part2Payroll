using System;
using System.Data;
using System.Globalization;
using System.Linq;
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
            table.Columns.Add("HoursWorked", typeof(decimal));
            table.Columns.Add("Salary", typeof(decimal));
            table.Columns.Add("StateTaxRate", typeof(decimal));
            table.Columns.Add("FederalTaxRate", typeof(decimal));
            table.Columns.Add("YtdState", typeof(decimal));
            table.Columns.Add("YtdFederal", typeof(decimal));
            table.Columns.Add("YtdTaxTotal", typeof(decimal));
            table.Columns.Add("YtdTotal", typeof(decimal));
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

            if (!TryParseTotals(out decimal totalAfterTax, out decimal totalTax))
            {
                return;
            }

            DataRow existingRow = table.Rows.Cast<DataRow>()
                .FirstOrDefault(row => row["EmployeeID"].ToString() == txtEmployeeID.Text);

            if (existingRow != null)
            {
                UpdateExistingEmployee(existingRow, totalAfterTax, totalTax);
            }
            else
            {
                AddNewEmployee(totalAfterTax, totalTax);
            }

            ClearInputs();
        }

        private void bttView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null || dataGridView1.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Please select an employee to view.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dataGridView1.CurrentCell.RowIndex;
            LoadDataIntoInputs(index);
            ClearAdditionalFields();
        }

        private void ClearAdditionalFields()
        {
            txtTotalTax.Clear();
            txtTotalAfterTax.Clear();
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
            if (!decimal.TryParse(txtHours.Text, out var hoursWorked) ||
                !decimal.TryParse(txtSalary.Text, out var salary))
            {
                ClearCalculatedFields();
                return;
            }

            decimal stateTaxRate = decimal.TryParse(txtStateTax.Text, out var parsedStateTax) ? parsedStateTax : 5;
            decimal federalTaxRate = decimal.TryParse(txtFederalTax.Text, out var parsedFederalTax) ? parsedFederalTax : 15;

            decimal totalGrossPay = hoursWorked * salary;

            decimal totalStateTax = totalGrossPay * (stateTaxRate / 100);
            decimal totalFederalTax = totalGrossPay * (federalTaxRate / 100);
            decimal totalTaxes = totalStateTax + totalFederalTax;

            decimal totalAfterTax = totalGrossPay - totalTaxes;

            
            txtTotalTax.Text = totalTaxes.ToString("C");
            txtTotalAfterTax.Text = totalAfterTax.ToString("C");

           
            txtYtdState.Text = totalStateTax.ToString("C");
            txtYtdFederal.Text = totalFederalTax.ToString("C");
            txtYtdTotalTax.Text = totalTaxes.ToString("C");
            txtYtdTotal.Text = totalAfterTax.ToString("C");
        }

        private void ClearCalculatedFields()
        {
            txtTotalTax.Clear();
            txtTotalAfterTax.Clear();
            txtYtdState.Clear();
            txtYtdFederal.Clear();
            txtYtdTotalTax.Clear();
            txtYtdTotal.Clear();
        }

        private void ClearInputs()
        {
            txtEmployeeID.Clear();
            txtEmployeeName.Clear();
            txtHours.Clear();
            txtSalary.Clear();
            txtStateTax.Clear();
            txtFederalTax.Clear();
            ClearCalculatedFields();
        }

        private bool ValidateInputs()
        {
            return !string.IsNullOrWhiteSpace(txtEmployeeID.Text) &&
                   !string.IsNullOrWhiteSpace(txtEmployeeName.Text) &&
                   decimal.TryParse(txtHours.Text, out _) &&
                   decimal.TryParse(txtSalary.Text, out _) &&
                   decimal.TryParse(txtStateTax.Text, out _) &&
                   decimal.TryParse(txtFederalTax.Text, out _);
        }

        private bool TryParseTotals(out decimal totalAfterTax, out decimal totalTax)
        {
            if (!decimal.TryParse(txtTotalAfterTax.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out totalAfterTax))
            {
                MessageBox.Show("Total After Tax is not in a valid format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                totalTax = 0;
                return false;
            }

            if (!decimal.TryParse(txtTotalTax.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out totalTax))
            {
                MessageBox.Show("Total Tax is not in a valid format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UpdateExistingEmployee(DataRow existingRow, decimal totalAfterTax, decimal totalTax)
        {
            existingRow["Name"] = txtEmployeeName.Text;
            existingRow["HoursWorked"] = decimal.Parse(txtHours.Text);

            decimal existingYtdState = decimal.Parse(existingRow["YtdState"].ToString());
            decimal existingYtdFederal = decimal.Parse(existingRow["YtdFederal"].ToString());

            existingRow["YtdState"] = existingYtdState + (totalTax * (decimal.Parse(txtStateTax.Text) / 100));
            existingRow["YtdFederal"] = existingYtdFederal + (totalTax * (decimal.Parse(txtFederalTax.Text) / 100));

            existingRow["YtdTaxTotal"] = decimal.Parse(existingRow["YtdTaxTotal"].ToString()) + totalTax;
            existingRow["YtdTotal"] = decimal.Parse(existingRow["YtdTotal"].ToString()) + totalAfterTax;
        }

        private void AddNewEmployee(decimal totalAfterTax, decimal totalTax)
        {
            table.Rows.Add(
                txtEmployeeID.Text,
                txtEmployeeName.Text,
                decimal.Parse(txtHours.Text),
                decimal.Parse(txtSalary.Text),
                decimal.Parse(txtStateTax.Text),
                decimal.Parse(txtFederalTax.Text),
                0,  
                0,
                totalTax,
                totalAfterTax);
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
            txtYtdTotalTax.Text = table.Rows[index]["YtdTaxTotal"].ToString();
            txtYtdTotal.Text = table.Rows[index]["YtdTotal"].ToString();

            ClearAdditionalFields();
        }
        private void bttCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotal();
        }
    }
        
    
}