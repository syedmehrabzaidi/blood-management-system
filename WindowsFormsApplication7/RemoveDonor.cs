using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class RemoveDonor : Form
    {
        public RemoveDonor()
        {
            InitializeComponent();
            setData();
        }

    

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void ClearAll_btn_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            phoneNoDel.ResetText();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                database.con.Open();
                SqlCommand del = new SqlCommand("delete from Donor where D_id=@id", database.con);
                del.Parameters.AddWithValue("@id", comboBox1.Text);
                int i = del.ExecuteNonQuery();

                MessageBox.Show(i+" Record Removed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                setData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                database.con.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                database.con.Open();
                SqlCommand del1 = new SqlCommand("delete from Donor where PhoneNo=@contactno#", database.con);
                del1.Parameters.AddWithValue("@contactno#", phoneNoDel.Text);
                int i = del1.ExecuteNonQuery();
               
                MessageBox.Show(i+" Record Removed","Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                setData();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                database.con.Close();
            }
        }

        public void setData() {
            try
            {
           
                SqlDataAdapter sd = new SqlDataAdapter("select * from Donor", database.con);
                DataTable td = new DataTable();
                sd.Fill(td);
                dataGridView1.DataSource = td;
                database.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                database.con.Close();
            }
        }

        private void RemoveDonor_Load(object sender, EventArgs e)
        {

            try
            {
                database.con.Open();
                SqlCommand csd = new SqlCommand("select * from Donor", database.con);
                DataTable d = new DataTable();
                SqlDataReader srr = csd.ExecuteReader();
                while (srr.Read())
                {
                    comboBox1.Items.Add(srr["D_id"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.con.Close();
            }
        }
    }
}
