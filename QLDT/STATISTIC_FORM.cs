using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDT
{
    public partial class STATISTIC_FORM : Form
    {
        public STATISTIC_FORM(DataTable dt1, DataTable dt2)
        {
            InitializeComponent();
            loadDataToChart(dt1);
            loadDataToShow(dt2);
        }

        void loadDataToShow(DataTable dt)
        {
            dataGridStatisticForm.DataSource = dt;
            dataGridStatisticForm.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridStatisticForm.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridStatisticForm.ColumnHeadersDefaultCellStyle.Font = new Font("SansSerif", 10F, FontStyle.Bold);
            //dataGridStatisticForm.Columns[0].Width = 150;
            dataGridStatisticForm.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dataGridStatisticForm.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridStatisticForm.EnableHeadersVisualStyles = false;
        }

        void loadDataToChart(DataTable dt)
        {


            chart1.DataSource = dt;
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "range";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "cnt";

            chart1.Series["SV"].XValueMember = "ChiTieu";
            chart1.Series["SV"].YValueMembers = "SoLuong";

            chart1.Series["SV"].IsValueShownAsLabel = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
