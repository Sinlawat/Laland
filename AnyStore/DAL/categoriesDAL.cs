using AnyStore.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.DAL
{
    class categoriesDAL
    {
        //สร้างเส้นทางสำหรับเชื่อมต่อข้อมูลกับ Database
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method
        public DataTable Select()
        {
            //สร้างการเชื่อมต่อกับฐานข้อมูล
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //เขียน Query SQL เพื่อดึงข้อมูลจากดาต้าเบส
                string sql = "SELECT * FROM tbl_categories";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //เปิดการเชื่อมต่อดาต้าเบส
                conn.Open();
                //ทำการเพิ่มค่าจากตัว adapter สู่ DataTable dt เพื่อเก็บค่าเอาไว้ในดาต้าเบส
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion
        #region Insert New CAtegory
        public bool Insert(categoriesBLL c)
        {
            //สร้างตัวแปร Boolean และตั้งค่าเริ่มต้นเป็นเท็จ
            bool isSucces = false;

            //เชื่อมต่อกับดาต้าเบส
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //เพื่อเพิ่มข้อมูลลงไปยังตาราง categories
                string sql = "INSERT INTO tbl_categories (title, description, added_date, added_by) VALUES (@title, @description, @added_date, @added_by)";

                //สร้าง SQL command เพื่อส่งข้อมูลไปยังดาต้าเบส
                SqlCommand cmd = new SqlCommand(sql, conn);
                //ส่งค่าที่กรอกไปยังพารามิเตอร์
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);

                //เปิดการเชื่อมต่อดาต้าเบส
                conn.Open();

                //การสร้างตัวแปร int ชื่อ rows เพื่อดำเนินการค้นหา
                int rows = cmd.ExecuteNonQuery();

                //หากดำเนินการค้นหาได้สำเร็จค่าของมันจะมากกว่า 0 

                if (rows>0)
                {
                    //ทำการค้นหาสำเร็จ
                    isSucces = true;
                }
                else
                {
                    //ทำการค้นหาไม่สำเร็จ
                    isSucces = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //ทำการปิดการเชื่อมต่อกับดาต้าเบส
                conn.Close();
            }

            return isSucces;
        }
        #endregion
        #region Update Method
        public bool Update(categoriesBLL c)
        {
            //สร้างตัวแปร Boolean และตั้งค่าเริ่มต้นเป็นเท็จ
            bool isSuccess = false;

            //เชื่อมต่อกับดาต้าเบส
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //สร้างการอัปเดตไปยัง categories
                string sql = "UPDATE tbl_categories SET title=@title, description=@description, added_date=@added_date, added_by=@added_by WHERE id=@id";

                //สร้าง SQL command เพื่อส่งข้อมูลไปยังดาต้าเบส
                SqlCommand cmd = new SqlCommand(sql, conn);

                //ส่งค่าไปยัง cmd
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                cmd.Parameters.AddWithValue("@id", c.id);

                //เปิดการเชื่อมต่อกับดาต้าเบส
                conn.Open();

                //การสร้างตัวแปร int ชื่อ rows เพื่อดำเนินการค้นหา
                int rows = cmd.ExecuteNonQuery();

                //หากดำเนินการค้นหาได้สำเร็จค่าของมันจะมากกว่า 0 
                if (rows>0)
                {
                    //ทำการค้นหาสำเร็จ
                    isSuccess = true;
                }
                else
                {
                    //ทำการค้นหาไม่สำเร็จ
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
        #region Delete Category Method
        public bool Delete(categoriesBLL c)
        {
            //สร้างตัวแปร Boolean และตั้งค่าเริ่มต้นเป็นเท็จ
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //สร้างการฟังก์ชันลบไปยัง categories
                string sql = "DELETE FROM tbl_categories WHERE id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                //ส่งค่าไปยัง cmd
                cmd.Parameters.AddWithValue("@id", c.id);

                //เปิดการเชื่อมต่อกับดาต้าเบส
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //หากดำเนินการค้นหาได้สำเร็จค่าของมันจะมากกว่า 0 
                if (rows>0)
                {
                    //ทำการค้นหาสำเร็จ
                    isSuccess = true;
                }
                else
                {
                    //ทำการค้นหาไม่สำเร็จ
                    isSuccess = false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
        #region Method for Searh Funtionality
        public DataTable Search(string keywords)
        {
            //เชื่อมต่อกับดาต้าเบส
            SqlConnection conn = new SqlConnection(myconnstrng);

            //สร้าง Data TAble ที่ชื่อ dt เพื่อเก็บข้อมูลจากฐานข้อมูลชั่วคราว
            DataTable dt = new DataTable();

            try
            {
                //เพื่อค้นหาข้อมูลจากตาราง categories
                String sql = "SELECT * FROM tbl_categories WHERE id LIKE '%"+keywords+"%' OR title LIKE '%"+keywords+"%' OR description LIKE '%"+keywords+"%'";
                //สร้าง SQL command เพื่อส่งข้อมูลไปยังดาต้าเบส
                SqlCommand cmd = new SqlCommand(sql, conn);

                //รับข้อมูลมาจากฐานข้อมูล
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //เปิดการเชื่อมต่อดาต้าเบส
                conn.Open();
                //ส่งค่าจาก adapter ไปยัง Data Table ที่ชื่อ dt
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion
    }
}
