using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLDT
{
    public partial class ASK_FORM : Form
    {
        string query, query1;
        bool advanceClicked = false;
        static bool isOpenAdvance = false;
        bool cbbLoaded = false;

        Controller controller;
        public ASK_FORM()
        {
            InitializeComponent();
            controller = new Controller();
            Init();
        }

        private void Init()
        {
            cbbTieuChi.SelectedIndex = 0;
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            if (isOpenAdvance == true)
            {
                isOpenAdvance = false;
            }
            else
            {
                isOpenAdvance = true;
            }

            advanceClicked = true;
            
            
            if (cbbLoaded == false)
            {
                loadToComboBox(cbbTinhThanh, getItem("TinhThanh"));
                loadToComboBox(cbbDVChuQuan, getItem("DVChuQuan"));
                cbbLoaded = true;
            }
            if (pnlAdvance.Visible == true)
            {
                pnlAdvance.Visible = false;
                this.MinimumSize = new Size(this.Width, this.Height - pnlAdvance.Height);
                this.Height = this.Height - pnlAdvance.Height;
            }
            else if (pnlAdvance.Visible == false)
            {
                pnlAdvance.Visible = true;
                this.Height = this.Height + pnlAdvance.Height;
                this.MinimumSize = new Size(this.Width, this.Height);
            }
        }

        private List<String> getItem(String conditionQuery)
        {
            var list = new List<String>();
            list.Add("None");
            SqlConnection conn = DBConnection.GetDBConnection();
            conn.Open();
            string sql = "SELECT * FROM [QLDT].[dbo].[cosodaotao]";
            using (var command = new SqlCommand(sql, conn))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bool isContain = false;
                        String item = reader[conditionQuery].ToString();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (item.Equals(list.ElementAt(i)))
                            {
                                isContain = true;
                                break;
                            }
                        }
                        if (!isContain)
                        {
                            list.Add(item);
                        }
                    }
                }
            }
            return list;
        }

        private void loadToComboBox(ComboBox cbb, List<String> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = list.ElementAt(i);
                item.Value = i;
                cbb.Items.Add(item);
            }
            cbb.SelectedIndex = 0;
        }

        private void rbtnS1_CheckedChanged(object sender, EventArgs e)
        {
            gbQuestion.Enabled = true;
            gbSearch.Enabled = false;
        }

        private void rbtnS2_CheckedChanged(object sender, EventArgs e)
        {
            gbQuestion.Enabled = false;
            gbSearch.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (advanceClicked == false && searchTextBox.Text == "")
            {
                MessageBox.Show("Mời nhập từ khóa để tìm kiếm");
                return;
            }
            if (advanceClicked == true && cbbTinhThanh.SelectedItem.ToString() == "None" && cbbDVChuQuan.SelectedItem.ToString() == "None" && searchTextBox.Text == "")
            {
                MessageBox.Show("Mời nhập từ khóa hoặc chọn tiêu chí để tìm kiếm");
                return;
            }
            int criteria_index = cbbTieuChi.SelectedIndex;
            String criteria_field ="";
            int numberSearch = -1;
            switch (criteria_index)
            {
                case 0:
                    criteria_field = "TenTruong";
                    numberSearch = 1;
                    break;
                case 1:
                    criteria_field = "TenChuyenNganh";
                    numberSearch = 0;
                    break;
                case 2:
                    criteria_field = "MaTruong";
                    numberSearch = 1;
                    break;
                case 3:
                    criteria_field = "MaNganh";
                    numberSearch = 0;
                    break;
                default:
                    break;
            }
            String input = searchTextBox.Text;
            String query ="";
            if (!advanceClicked)
            {
                if (numberSearch == 1)
                    query = "Select [MaTruong] 'MÃ TRƯỜNG' ,[TenTruong] 'TÊN TRƯỜNG' ,[DiaChi] 'ĐỊA CHỈ' ,[Website] 'WEBSITE' ,[TinhThanh] 'TỈNH THÀNH' ,[DVChuquan] 'ĐƠN VỊ CHỦ QUẢN' From [QLDT].[dbo].[cosodaotao] WHERE " + criteria_field + " LIKE N'%" + input + "%'";
                else if (numberSearch == 0)
                {
                    query = "Select chuyennganhdaotao.MaNganh 'MÃ NGÀNH', chuyennganhdaotao.TenChuyenNganh 'TÊN CHUYÊN NGÀNH', cosonganh.ChiTieu 'CHỈ TIÊU 2018', cosonganh.DiemChuan 'ĐIỂM CHUẨN' From [QLDT].[dbo].[chuyennganhdaotao] LEFT JOIN [QLDT].[dbo].[cosonganh] ON [QLDT].[dbo].[cosonganh].[MaNganh] = [QLDT].[dbo].[chuyennganhdaotao].[MaNganh] " + "WHERE [QLDT].[dbo].[chuyennganhdaotao].[" + criteria_field + "] LIKE N'%" + input + "%'";
                }
                //MessageBox.Show(query);
            }
            else
            {
                String cbbTextTinhThanh = cbbTinhThanh.SelectedItem.ToString();
                String cbbTextDVChuQuan = cbbDVChuQuan.SelectedItem.ToString();
                if (cbbTextDVChuQuan.Equals("None"))
                    cbbTextDVChuQuan = "";
                if (cbbTextTinhThanh.Equals("None"))
                    cbbTextTinhThanh = "";
                String scoreStart = txtStart.Text;
                String scoreFinish = txtFinish.Text;
                if (scoreStart == "" && scoreFinish == "")
                {
                    scoreStart = "0";
                    scoreFinish = "30";
                }
                else if(scoreStart == "" && scoreFinish != "")
                {
                    scoreStart = "0";
                }
                else if (scoreStart != "" && scoreFinish == "")
                {
                    scoreFinish = "30";
                }

                if (numberSearch == 1)
                {
                    query = "Select [MaTruong] 'MÃ TRƯỜNG' ,[TenTruong] 'TÊN TRƯỜNG' ,[DiaChi] 'ĐỊA CHỈ' ,[Website] 'WEBSITE',[TinhThanh] 'TỈNH THÀNH' ,[DVChuquan] 'ĐƠN VỊ CHỦ QUẢN' From [QLDT].[dbo].[cosodaotao] WHERE " + criteria_field + " LIKE N'%" + input + "%' AND TinhThanh LIKE N'%" + cbbTextTinhThanh + "%' AND DVChuQuan LIKE N'%" + cbbTextDVChuQuan + "%';";
                }
                else if (numberSearch == 0)
                {
                    if (float.Parse(txtFinish.Text) < float.Parse(txtStart.Text))
                    {
                        MessageBox.Show("Vui lòng nhập lại điểm hợp lệ!");
                        return;
                    }
                        query = "SELECT [QLDT].[dbo].[cosodaotao].[TenTruong] as 'TÊN TRƯỜNG' ,[QLDT].[dbo].[chuyennganhdaotao].[TenChuyenNganh] as 'TÊN CHUYÊN NGÀNH', [QLDT].[dbo].[cosonganh].[MaNganh] as 'MÃ NGÀNH', cosonganh.DiemChuan as 'ĐIỂM CHUẨN' FROM [QLDT].[dbo].[cosonganh],[QLDT].[dbo].[cosodaotao], [QLDT].[dbo].[chuyennganhdaotao] WHERE [QLDT].[dbo].[cosonganh].[MaTruong]=[QLDT].[dbo].[cosodaotao].[MaTruong] AND [QLDT].[dbo].[cosonganh].[MaNganh]=[QLDT].[dbo].[chuyennganhdaotao].[MaNganh] AND [QLDT].[dbo].[chuyennganhdaotao].[" + criteria_field + "] LIKE N'%" + input + "%'AND TinhThanh LIKE N'%" + cbbTextTinhThanh + "%' AND DVChuQuan LIKE N'%" + cbbTextDVChuQuan + "%' AND (cosonganh.DiemChuan > " + scoreStart + " AND cosonganh.DiemChuan < " + scoreFinish + ");";

                }
            }
            //MessageBox.Show(query);
            controller.PushDataToShowForm(query);
        }
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void llblQ1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Các trường đào tạo CNTT ?
            query = "Select MaTruong as 'MÃ TRƯỜNG', TenTruong as 'TÊN TRƯỜNG', Website 'WEBSITE' From [QLDT].[dbo].[cosodaotao] ";
            controller.PushDataToShowForm(query);
        }

        private void llblQ2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Địa Chỉ các trường đào tạo CNTT ?
            query = "Select TenTruong as 'TÊN TRƯỜNG', DiaChi as 'ĐỊA CHỈ' From [QLDT].[dbo].[cosodaotao] ";
            controller.PushDataToShowForm(query);
        }

        private void llblQ3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Website các trường đào tạo CNTT ?
            query = "Select TenTruong as 'TÊN TRƯỜNG', Website 'WEBSITE' From [QLDT].[dbo].[cosodaotao] ";
            controller.PushDataToShowForm(query);
        }


        
        private void llblQ4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Danh mục giáo dục, đào tạo cấp IV trình độ đại học chuyên ngành CNTT?
            query = "Select MaNganh as 'MÃ NGÀNH', TenChuyenNganh as 'TÊN CHUYÊN NGÀNH'  From [QLDT].[dbo].[chuyennganhdaotao] ";
            controller.PushDataToShowForm(query);
        }

        private void llblQ5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Danh sách các đơn vị chủ quản ?
            query = "Select DISTINCT DVChuquan as 'ĐƠN VỊ CHỦ QUẢN'  From [QLDT].[dbo].[cosodaotao] ";
            controller.PushDataToShowForm(query);
        }

        private void llblQ6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Số Cơ sở đào tạo CNTT tại Hà Nội?
            query = "SELECT [MaTruong] 'MÃ TRƯỜNG' ,[TenTruong] 'TÊN TRƯỜNG' ,[DiaChi] 'ĐỊA CHỈ' ,[Website] 'WEBSITE',[DVChuquan] 'ĐƠN VỊ CHỦ QUẢN' FROM [QLDT].[dbo].[cosodaotao] WHERE TinhThanh=N'Hà Nội'";
            //SHOW_FORM sf = new SHOW_FORM(query);
            controller.PushDataToShowForm(query);
            //sf.Show();
        }

        private void llblQ7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Chi tieu tuyen sinh cac truong
            query = "select (case when SL >= 500 then N'TRÊN 500' when SL < 500 and SL >= 100 then N'TỪ 100 ĐẾN 500' when SL < 100 then N'DƯỚI 100' else 'other' end) as ChiTieu, count(*) as SoLuong from (select sum(ChiTieu) as SL from cosonganh group by MaTruong) src group by (case when SL >= 500 then N'TRÊN 500' when SL < 500 and SL >= 100 then N'TỪ 100 ĐẾN 500' when SL < 100 then N'DƯỚI 100' else 'other' end);";
            query1 = "select cosodaotao.TenTruong, SL from cosodaotao left join (select MaTruong as MT,SUM(ChiTieu) as SL from cosonganh group by MaTruong) src on cosodaotao.MaTruong = src.MT";
            controller.PushDataToShowChart(query, query1);
        }

        private void llblQ8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //So luong csdt cac tinh thanh
            query = "SELECT TinhThanh as 'TỈNH THÀNH', COUNT(*) as 'SỐ LƯỢNG CSDT' FROM [QLDT].[dbo].[cosodaotao] GROUP BY TinhThanh";
            controller.PushDataToShowForm(query);
        }

        private void llblQ9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Số lượng cơ sở đào tạo theo đơn vị chủ quản ?
            query = "SELECT [QLDT].[dbo].[cosodaotao].DVChuquan as 'ĐƠN VỊ CHỦ QUẢN',COUNT(*) as 'SỐ TRƯỜNG' FROM [QLDT].[dbo].[cosodaotao] group by [QLDT].[dbo].[cosodaotao].DVChuquan";
            controller.PushDataToShowForm(query);
        }

        private void llblQ10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //10. Các cơ sở đào tạo CNTT tại Thành phố Hồ Chí Minh ?
            query = "SELECT [MaTruong] 'MÃ TRƯỜNG' ,[TenTruong] 'TÊN TRƯỜNG' ,[DiaChi] 'ĐỊA CHỈ' ,[Website] 'WEBSITE',[DVChuquan] 'ĐƠN VỊ CHỦ QUẢN' FROM [QLDT].[dbo].[cosodaotao] WHERE TinhThanh=N'TP. Hồ Chí Minh'";
            controller.PushDataToShowForm(query);
        }

        private void llblQ11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //11. Điểm chuẩn theo từng chuyên ngành tại các trường ?
            query = "SELECT [QLDT].[dbo].[cosodaotao].[TenTruong] as 'TÊN TRƯỜNG' ,[QLDT].[dbo].[chuyennganhdaotao].[MaNganh] as 'MÃ NGÀNH' ,[QLDT].[dbo].[chuyennganhdaotao].[TenChuyenNganh] as 'TÊN CHUYÊN NGÀNH' ,[QLDT].[dbo].[cosonganh].[DiemChuan] 'ĐIỂM CHUẨN' FROM [QLDT].[dbo].[chuyennganhdaotao],[QLDT].[dbo].[cosonganh],[QLDT].[dbo].[cosodaotao] WHERE [QLDT].[dbo].[chuyennganhdaotao].MaNganh=[QLDT].[dbo].[cosonganh].MaNganh AND [QLDT].[dbo].[cosonganh].[MaTruong]=[QLDT].[dbo].[cosodaotao].[MaTruong]";
            query1 = "select (case when SL >= 25 then N'TRÊN 25' when SL<25 and SL >= 20 then N'TỪ 20 ĐẾN 25' when SL < 20 then N'DƯỚI 20' else 'other' end) as ChiTieu, count(*) as SoLuong from (select DiemChuan as SL from cosonganh) src group by (case when SL >= 25 then N'TRÊN 25' when SL<25 and SL >= 20 then N'TỪ 20 ĐẾN 25' when SL < 20 then N'DƯỚI 20' else 'other' end);";
            controller.PushDataToShowChart(query1,query);
        }

        private void llblQ12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //12. Tên các trường có chuyên ngành có chỉ tiêu không it hơn 100 chỉ tiêu ?
            query = "SELECT [cosodaotao].[TenTruong] as 'TÊN TRƯỜNG' ,[chuyennganhdaotao].[TenChuyenNganh] as 'TÊN CHUYÊN NGÀNH' ,[cosonganh].[DiemChuan] as 'ĐIỂM CHUẨN' ,[ChiTieu] as 'CHỈ TIÊU 2018' FROM [QLDT].[dbo].[cosonganh] INNER JOIN [QLDT].[dbo].[chuyennganhdaotao] ON [cosonganh].MaNganh=[chuyennganhdaotao].MaNganh INNER JOIN [QLDT].[dbo].[cosodaotao] ON [cosonganh].MaTruong=[cosodaotao].MaTruong WHERE [ChiTieu] >= 100";
            controller.PushDataToShowForm(query);
        }

        private void btnAdvanced_MouseHover(object sender, EventArgs e)
        {
            if (isOpenAdvance == false)
            {
                btnAdvanced.Text = "NÂNG CAO>>>>";
            }
            else{
                btnAdvanced.Text = "NÂNG CAO<<<<";
            }
        }

        private void btnAdvanced_MouseLeave(object sender, EventArgs e)
        {
            btnAdvanced.Text = "NÂNG CAO";
        }

        private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (txtStart.Text != "")
            {
                if (!int.TryParse(txtStart.Text, out result))
                {
                    txtStart.Text = "";
                    MessageBox.Show("Invalid Integer");
                }
            }
        }

        private void txtFinish_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtFinish_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (txtFinish.Text != "")
            {
                if (!int.TryParse(txtFinish.Text, out result))
                {
                    txtFinish.Text = "";
                    MessageBox.Show("Invalid Integer");
                }
            }
            
        }

        private void cbbTieuChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTieuChi.SelectedIndex == 1 || cbbTieuChi.SelectedIndex == 3)
            {
                txtFinish.Enabled = true;
                txtStart.Enabled = true;
            }
            else 
            {
                txtFinish.Enabled = false;
                txtStart.Enabled = false;
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
