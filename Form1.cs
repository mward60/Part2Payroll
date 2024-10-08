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
private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].Name == "YtdState" ||
            dataGridView1.Columns[e.ColumnIndex].Name == "YtdFederal" ||
            dataGridView1.Columns[e.ColumnIndex].Name == "YtdTaxTotal" ||
            dataGridView1.Columns[e.ColumnIndex].Name == "YtdTotal")
        {
            if (e.Value != null)
            {
                e.Value = string.Format(CultureInfo.CurrentCulture, "{0:C}", e.Value);
                e.FormattingApplied = true;
            }
        }
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
            dataGridView1.DataSource = table;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Employee updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AddNewEmployee(totalAfterTax, totalTax);
                MessageBox.Show("Employee added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ClearInputs();
        }
        private void bttDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index > -1)
            {
                table.Rows[index].Delete();
            }
        }
        private void AddNewEmployee(decimal totalAfterTax, decimal totalTax)
        {
            decimal hoursWorked = decimal.Parse(txtHours.Text);
            decimal salary = decimal.Parse(txtSalary.Text);
            decimal stateTaxRate = decimal.Parse(txtStateTax.Text) / 100;
            decimal federalTaxRate = decimal.Parse(txtFederalTax.Text) / 100;

            decimal totalGrossPay = hoursWorked * salary;
            decimal totalStateTax = totalGrossPay * stateTaxRate;
            decimal totalFederalTax = totalGrossPay * federalTaxRate;

            table.Rows.Add(
                txtEmployeeID.Text,
                txtEmployeeName.Text,
                hoursWorked,
                salary,
                stateTaxRate * 100,
                federalTaxRate * 100,
                totalStateTax, 
                totalFederalTax,
                totalTax,
                totalAfterTax);
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

            decimal stateTaxRate = decimal.TryParse(txtStateTax.Text, out var parsedStateTax) ? parsedStateTax / 100 : 0.05m;
            decimal federalTaxRate = decimal.TryParse(txtFederalTax.Text, out var parsedFederalTax) ? parsedFederalTax / 100 : 0.15m; 

            decimal totalGrossPay = hoursWorked * salary;

            decimal totalStateTax = totalGrossPay * stateTaxRate;
            decimal totalFederalTax = totalGrossPay * federalTaxRate;
            decimal totalTaxes = totalStateTax + totalFederalTax;

            decimal totalAfterTax = totalGrossPay - totalTaxes;

            txtTotalTax.Text = totalTaxes.ToString("C", CultureInfo.CurrentCulture);
            txtTotalAfterTax.Text = totalAfterTax.ToString("C", CultureInfo.CurrentCulture);

            txtYtdState.Text = totalStateTax.ToString("C", CultureInfo.CurrentCulture);
            txtYtdFederal.Text = totalFederalTax.ToString("C", CultureInfo.CurrentCulture);
            txtYtdTotalTax.Text = totalTaxes.ToString("C", CultureInfo.CurrentCulture);
            txtYtdTotal.Text = totalAfterTax.ToString("C", CultureInfo.CurrentCulture);
        }





        private void RefreshTotals()
        {
           
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
            existingRow["Salary"] = decimal.Parse(txtSalary.Text);

            decimal stateTaxRate = decimal.Parse(txtStateTax.Text) / 100;
            decimal federalTaxRate = decimal.Parse(txtFederalTax.Text) / 100;
            decimal hoursWorked = decimal.Parse(txtHours.Text);
            decimal salary = decimal.Parse(txtSalary.Text);

            decimal totalGrossPay = hoursWorked * salary;
            decimal totalStateTax = totalGrossPay * stateTaxRate;
            decimal totalFederalTax = totalGrossPay * federalTaxRate;

            decimal existingYtdState = decimal.Parse(existingRow["YtdState"].ToString());
            decimal existingYtdFederal = decimal.Parse(existingRow["YtdFederal"].ToString());

            existingRow["YtdState"] = existingYtdState + totalStateTax;
            existingRow["YtdFederal"] = existingYtdFederal + totalFederalTax;

            existingRow["YtdTaxTotal"] = decimal.Parse(existingRow["YtdTaxTotal"].ToString()) + totalTax;
            existingRow["YtdTotal"] = decimal.Parse(existingRow["YtdTotal"].ToString()) + totalAfterTax;
        }


        private void LoadDataIntoInputs(int index)
        {
            txtEmployeeID.Text = table.Rows[index]["EmployeeID"].ToString();
            txtEmployeeName.Text = table.Rows[index]["Name"].ToString();
            txtHours.Text = table.Rows[index]["HoursWorked"].ToString();
            txtSalary.Text = table.Rows[index]["Salary"].ToString();
            txtStateTax.Text = table.Rows[index]["StateTaxRate"].ToString();
            txtFederalTax.Text = table.Rows[index]["FederalTaxRate"].ToString();

            // Format YTD values as currency
            txtYtdState.Text = decimal.Parse(table.Rows[index]["YtdState"].ToString()).ToString("C", CultureInfo.CurrentCulture);
            txtYtdFederal.Text = decimal.Parse(table.Rows[index]["YtdFederal"].ToString()).ToString("C", CultureInfo.CurrentCulture);
            txtYtdTotalTax.Text = decimal.Parse(table.Rows[index]["YtdTaxTotal"].ToString()).ToString("C", CultureInfo.CurrentCulture);
            txtYtdTotal.Text = decimal.Parse(table.Rows[index]["YtdTotal"].ToString()).ToString("C", CultureInfo.CurrentCulture);
        }
        private void bttCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotal();
        }
    }
    

}