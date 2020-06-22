using AnyStore.BLL;
using AnyStore.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.UI
{
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        categoriesBLL c = new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();
        userDAL udal = new userDAL();

        private void btnADD_Click(object sender, EventArgs e)
        {
            //รับค่าจากตาราง Categories
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;

            //iy[ ID ในช่อง Added by 
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            //ส่งค่า id ของผู้ใช้ที่ล็อกอินในช่อง added by
            c.added_by = usr.id;

            //สร้าง Boolean เพื่อแทรกข้อมูลไปสู้ดาต้าเบส
            bool success = dal.Insert(c);

            //หากแทรก Categories สำเร็จแล้ว ค่าของ Success จะเป็นจริง
            if (success==true)
            {
                //ทำการแทรกข้อมูลใหม่ลงใน categories แล้ว
                MessageBox.Show("ได้ทำการเพิ่ม Category ใหม่ เรียบร้อยแล้ว");
                Clear();
                //ทำการรีเฟรชข้อมูลให้ใหม่
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                //เมื่อไม่สามารถแทรกข้อมูลลงไปใน categories ได้
                MessageBox.Show("ไม่สามารถทำการเพิ่ม Category ใหม่ได้! กรุณาลองอีกครั้ง");
            }
        }
        public void Clear()
        {
            txtCategoryID.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            //เขียนโค้ดในนี้เพื่อให้ datagridview แสดงข้อมูลทุกๆข้อมูลในตาราง
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }

        private void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ค้นหาข้อมูลในแถวของตัวที่เราคลิกเมาส์ไว้ที่ข้อมูล
            int RowIndex = e.RowIndex;
            txtCategoryID.Text = dgvCategories.Rows[RowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvCategories.Rows[RowIndex].Cells[1].Value.ToString();
            txtDescription.Text = dgvCategories.Rows[RowIndex].Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //รับค่าจากดาต้าเบส
            c.id = int.Parse(txtCategoryID.Text);
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;
            //รับ ID ในช่อง Added by
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            //ส่งข้อมูล id ของผู้ใช้งานที่ล็อกอินใน added by
            c.added_by = usr.id;

            //สร้างตัวแปร Boolean เพื่ออัปเดท categories และเช็คค่า 
            bool success = dal.Update(c);
            //หาก Categories ได้รับการอัปเดตสำเร็จแล้วค่าความสำเร็จจะเป็นจริง
            if (success==true)
            {
                //Category ทำการอัปเดทเสร็จสิ้น
                MessageBox.Show("ทำการเปลี่ยนแปลง Category ใหม่เรียบ้อยแล้ว");
                Clear();
                //รีเฟรชค่าใน datagridview
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                //Category ทำการอัปเดทไม่สำเร็จ
                MessageBox.Show("ไม่สามารถทำการเปลี่ยนแปลง Category ได้! กรุณาลองใหม่อีกครั้ง");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //รับค่าจากดาต้าเบส
            c.id = int.Parse(txtCategoryID.Text);

            //สร้างตัวแปร Boolean เพื่ออัปเดท categories และเช็คค่า 
            bool success = dal.Delete(c);

            //หาก Categories ได้รับการลบสำเร็จแล้วค่าความสำเร็จจะเป็นจริง
            if (success==true)
            {
                //Category ทำการลบเสร็จสิ้น
                MessageBox.Show("ทำการลบ Category เรียบร้อยแล้ว");
                Clear();
                //รีเฟรชค่าใน datagridview
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                //Category ทำการลบไม่สำเร็จ
                MessageBox.Show("ไม่สามารถทำการลบ Category ได้! กรุณาลองใหม่อีกครั้ง");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //รับค่า Keywords
            string keywords = txtSearch.Text;

            //กรองหมวดหมู่ตามคำหลัก
            if (keywords!=null)
            {
                //ใช้วิธีการค้นหาเพื่อแสดง Categories
                DataTable dt = dal.Search(keywords);
                dgvCategories.DataSource = dt;
            }
            else
            {
                //ใช้วิธีการเลือกเพื่อแสดง Categories ทั้งหมด
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
        }

        private void lblTop_Click(object sender, EventArgs e)
        {

        }
    }
}
