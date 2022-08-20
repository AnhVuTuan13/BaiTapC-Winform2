using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBH;
namespace GUI_QLVS
{
    public partial class frmQLSV : Form
    {
        public frmQLSV()
        {
            InitializeComponent();
        }
        BUS_QuanLy bus = new BUS_QuanLy();
        private void loadcb()
        {
            cbClass.DataSource = bus.showcb();
            cbClass.DisplayMember = "TenLop";
            cbClass.ValueMember = "MaLop";
        }
        private void loadDGV()
        {
            dataGridView1.DataSource = bus.showdgv();
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            loadcb();
            loadDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txthoten.Text==""|| txtque.Text == "" || txtmahs.Text=="" || txttuoi.Text == "" )
                    MessageBox.Show("Nhập Thiếu Dữ Liệu!!", "ThôngBaos");
            else
            {
                if(bus.check(txtmahs.Text))
                {
                    string tb = "";
                    int tuoicheck;
                    if (int.TryParse(txttuoi.Text, out tuoicheck) == false)
                        tb = "Tuổi Sai!";
                    if(tb!="")
                        MessageBox.Show(tb, "ThôngBaos");
                    else
                    {
                        string Nu;
                        if (ckNu.Checked)
                        {
                            Nu = "True";
                        }
                        else
                            Nu = "False";
                        bus.InsertSQL(txtmahs.Text, txthoten.Text, Nu, txtque.Text, txttuoi.Text, cbClass.SelectedValue.ToString());
                        loadDGV();
                    }    
                }   
                else
                    MessageBox.Show("Mã Học Sinh :"+txtmahs.Text+" ĐÃ tồn tại !", "ThôngBaos");
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ( txtmahs.Text == "" )
                MessageBox.Show("Nhập Mã Học Sinh Cấn Xoá!!", "ThôngBaos");
            else
            {
                if (bus.check(txtmahs.Text)==false)
                {

                        bus.DELETESQL(txtmahs.Text);
                        loadDGV();
                    
                }
                else
                    MessageBox.Show("Mã Học Sinh :" + txtmahs.Text + " Không tồn tại !", "ThôngBaos");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Có muốn Thoát", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == tl)
                Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtmahs.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txthoten.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "True")
                    ckNu.Checked = true;
                else
                    ckNu.Checked = false;
                txtque.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txttuoi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbClass.Text = bus.TenLop(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch
            {

            }
        }
    }
}
