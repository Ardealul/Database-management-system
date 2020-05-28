using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab1
{
    public partial class Form1 : Form
    {

        SqlConnection connection =
            new SqlConnection("Data Source=DESKTOP-TOOTN13\\SQLEXPRESS; Initial Catalog=Restaurant; Integrated Security=True;");

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet();
        BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataSet.Tables.Add("TipEvenimentTable");
            dataSet.Tables.Add("EvenimentTable");
            dataSet.Tables.Add("EvenimenteAsociateTable");
            gridViewUpdate();
        }

        public void EvenimentGridViewUpdate(int index)
        {
            SqlCommand commandTipEveniment = new SqlCommand("select * from TipEveniment", connection);
            SqlCommand commandEveniment = new SqlCommand("select * from Eveniment where Teid=@teid", connection);
            commandEveniment.Parameters.Add("@teid", SqlDbType.Int).Value = index;

            dataSet.Clear();

            dataAdapter.SelectCommand = commandTipEveniment;
            dataAdapter.Fill(dataSet.Tables["TipEvenimentTable"]);
            dataAdapter.SelectCommand = commandEveniment;
            dataAdapter.Fill(dataSet.Tables["EvenimentTable"]);

            TipEvenimentGridView.DataSource = dataSet.Tables["TipEvenimentTable"];
            EvenimentGridView.DataSource = dataSet.Tables["EvenimentTable"];
        }

        public void gridViewUpdate()
        {
            SqlCommand commandTipEveniment = new SqlCommand("select * from TipEveniment", connection);
            SqlCommand commandEveniment = new SqlCommand("select * from Eveniment", connection);

            dataSet.Clear();

            dataAdapter.SelectCommand = commandTipEveniment;
            dataAdapter.Fill(dataSet.Tables["TipEvenimentTable"]);
            dataAdapter.SelectCommand = commandEveniment;
            dataAdapter.Fill(dataSet.Tables["EvenimentTable"]);

            TipEvenimentGridView.DataSource = dataSet.Tables["TipEvenimentTable"];
            EvenimentGridView.DataSource = dataSet.Tables["EvenimentTable"];
        }

        private void TipEvenimentGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            DataGridViewRow selectedRow = TipEvenimentGridView.Rows[index];
            TeidTextBox.Text = selectedRow.Cells[0].Value.ToString();
            EidTextBox.Clear();
            nrPersoaneTextBox.Clear();
            dataEvenimentTextBox.Clear();

            EvenimentGridViewUpdate(Int32.Parse(selectedRow.Cells[0].Value.ToString()));

        }
        private void EvenimentGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = EvenimentGridView.Rows[index];
            EidTextBox.Text = selectedRow.Cells[0].Value.ToString();
            nrPersoaneTextBox.Text = selectedRow.Cells[1].Value.ToString();
            dataEvenimentTextBox.Text = selectedRow.Cells[2].Value.ToString();
            TeidTextBox.Text = selectedRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapter.InsertCommand =
                    new SqlCommand("insert into Eveniment(NrPersoane, DataEveniment, Teid) values (@nr, @de, @id)", connection);
                dataAdapter.InsertCommand.Parameters.Add("@nr", SqlDbType.Int).Value = nrPersoaneTextBox.Text;
                dataAdapter.InsertCommand.Parameters.Add("@de", SqlDbType.Date).Value = dataEvenimentTextBox.Text;
                dataAdapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int).Value = TeidTextBox.Text;

                connection.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();

                //gridViewUpdate();
                EvenimentGridViewUpdate(Int32.Parse(TeidTextBox.Text.ToString()));
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapter.InsertCommand =
                    new SqlCommand("delete from Eveniment where Eid=@eid", connection);
                dataAdapter.InsertCommand.Parameters.Add("@eid", SqlDbType.Int).Value = EidTextBox.Text;

                connection.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();

                //gridViewUpdate();
                EvenimentGridViewUpdate(Int32.Parse(TeidTextBox.Text.ToString()));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapter.InsertCommand =
                    new SqlCommand("update Eveniment set NrPersoane=@nr, DataEveniment=@de, Teid=@teid where Eid=@eid", connection);
                dataAdapter.InsertCommand.Parameters.Add("@nr", SqlDbType.Int).Value = nrPersoaneTextBox.Text;
                dataAdapter.InsertCommand.Parameters.Add("@de", SqlDbType.Date).Value = dataEvenimentTextBox.Text;
                dataAdapter.InsertCommand.Parameters.Add("@teid", SqlDbType.Int).Value = TeidTextBox.Text;
                dataAdapter.InsertCommand.Parameters.Add("@eid", SqlDbType.Int).Value = EidTextBox.Text;

                connection.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();

                //gridViewUpdate();
                EvenimentGridViewUpdate(Int32.Parse(TeidTextBox.Text.ToString()));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}
