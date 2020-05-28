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
using System.Configuration;

namespace lab1
{
    public partial class Form1 : Form
    {

        SqlConnection connection;
        string tabelParinte;
        string tabelFiu;
        List<string> parentTableColumnNames;
        List<string> childTableColumnNames;
        List<string> queryParameters;
        List<string> parametersType;
        int parentTableNrColumns;
        int childTableNrColumns;
        string insertQuery;
        string deleteQuery;
        string updateQuery;
        string selectQuery;

        TextBox[] textBoxes = new TextBox[10]; //initializare
        Label[] labels = new Label[10];

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            dataSet.Tables.Add("parinte");
            dataSet.Tables.Add("fiu");
        }

        private void conectareButton_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            connection = new SqlConnection(conn);

            tabelParinte = ConfigurationManager.AppSettings["parentTable"];
            tabelFiu = ConfigurationManager.AppSettings["childTable"];

            groupBoxParinte.Text = "Tabela " + tabelParinte;
            groupBoxFiu.Text = "Tabela " + tabelFiu;
            groupBoxFields.Text = tabelFiu;

            gridViewData();
            setTablesDetails();
            generateItems();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void setTablesDetails()
        {
            string pNrColumns = ConfigurationManager.AppSettings["parentTableNrColumns"];
            parentTableNrColumns = Int32.Parse(pNrColumns);
            string cNrColumns = ConfigurationManager.AppSettings["childTableNrColumns"];
            childTableNrColumns = Int32.Parse(cNrColumns);

            parentTableColumnNames = new List<string>(ConfigurationManager.AppSettings["parentTableColumnNames"].Split(','));
            childTableColumnNames = new List<string>(ConfigurationManager.AppSettings["childTableColumnNames"].Split(','));
            queryParameters = new List<string>(ConfigurationManager.AppSettings["queryParameters"].Split(','));
            parametersType = new List<string>(ConfigurationManager.AppSettings["queryParametersType"].Split(','));

            insertQuery = ConfigurationManager.AppSettings["insertQuery"];
            deleteQuery = ConfigurationManager.AppSettings["deleteQuery"];
            updateQuery = ConfigurationManager.AppSettings["updateQuery"];
            selectQuery = ConfigurationManager.AppSettings["selectQuery"];
            
        }
        public void generateItems()
        {
            int n = childTableNrColumns;

            int y = 40;
            for (int i = 0; i < n; i++)
            {
                labels[i] = new Label();
                labels[i].Location = new Point(25, y);
                labels[i].Size = new Size(120, 20);
                labels[i].Text = childTableColumnNames[i];
                labels[i].Font = new Font("Arial", 10, FontStyle.Bold);

                textBoxes[i] = new TextBox();
                textBoxes[i].Location = new Point(160, y);
                textBoxes[i].Size = new Size(90, 20);

                y += 40;
            }
            textBoxes[0].Enabled = false;

            for (int i = 0; i < n; i++)
            {
                panouControl.Controls.Add(textBoxes[i]);
                panouControl.Controls.Add(labels[i]);
            }
        }

        public void ParinteGridViewUpdate(int index)
        {
            SqlCommand commandParinte = new SqlCommand("select * from " + tabelParinte, connection);
            SqlCommand commandFiu = new SqlCommand(selectQuery, connection);
            commandFiu.Parameters.Add(queryParameters[childTableNrColumns - 1], SqlDbType.Int).Value = index;

            dataSet.Clear();

            dataAdapter.SelectCommand = commandParinte;
            dataAdapter.Fill(dataSet.Tables["parinte"]);
            dataAdapter.SelectCommand = commandFiu;
            dataAdapter.Fill(dataSet.Tables["fiu"]);

            ParinteGridView.DataSource = dataSet.Tables["parinte"];
            FiuGridView.DataSource = dataSet.Tables["fiu"];
        }

        public void gridViewData()
        {
            SqlCommand commandParinte = new SqlCommand("select * from " + tabelParinte, connection);
            SqlCommand commandFiu = new SqlCommand("select * from " + tabelFiu, connection);

            dataSet.Clear();

            dataAdapter.SelectCommand = commandParinte;
            dataAdapter.Fill(dataSet.Tables["parinte"]);
            dataAdapter.SelectCommand = commandFiu;
            dataAdapter.Fill(dataSet.Tables["fiu"]);

            ParinteGridView.DataSource = dataSet.Tables["parinte"];
            FiuGridView.DataSource = dataSet.Tables["fiu"];
        }

        private void ParinteGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = ParinteGridView.Rows[index];
            int n = childTableNrColumns;

            textBoxes[n - 1].Text = selectedRow.Cells[0].Value.ToString();
            for (int i = 0; i < n - 1; i++){ textBoxes[i].Clear(); }

            ParinteGridViewUpdate(Int32.Parse(selectedRow.Cells[0].Value.ToString()));
        }

        private void FiuGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = FiuGridView.Rows[index];
            int n = childTableNrColumns;

            for (int i = 0; i < n; i++)
            {
                textBoxes[i].Text = selectedRow.Cells[i].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = childTableNrColumns;
            try
            {
                dataAdapter.InsertCommand =
                    new SqlCommand(insertQuery, connection);

                for (int i = 1; i < n; i++)
                {
                    if(parametersType[i] == "int")
                    {
                        dataAdapter.InsertCommand.Parameters.Add(queryParameters[i], SqlDbType.Int).Value = Int32.Parse(textBoxes[i].Text);
                    }
                    else if(parametersType[i] == "date")
                    {
                        dataAdapter.InsertCommand.Parameters.Add(queryParameters[i], SqlDbType.Date).Value = textBoxes[i].Text;
                    }
                }

                connection.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();

                ParinteGridViewUpdate(Int32.Parse(textBoxes[n - 1].Text.ToString()));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = childTableNrColumns;
            try
            {
                dataAdapter.InsertCommand =
                    new SqlCommand(deleteQuery, connection);
                dataAdapter.InsertCommand.Parameters.Add(queryParameters[0], SqlDbType.Int).Value = textBoxes[0].Text;

                connection.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();

                ParinteGridViewUpdate(Int32.Parse(textBoxes[n - 1].Text.ToString()));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = childTableNrColumns;
            try
            {
                dataAdapter.InsertCommand =
                    new SqlCommand(updateQuery, connection);

                for (int i = 0; i < n; i++)
                {
                    if (parametersType[i] == "int")
                    {
                        dataAdapter.InsertCommand.Parameters.Add(queryParameters[i], SqlDbType.Int).Value = Int32.Parse(textBoxes[i].Text);
                    }
                    else if (parametersType[i] == "date")
                    {
                        dataAdapter.InsertCommand.Parameters.Add(queryParameters[i], SqlDbType.Date).Value = textBoxes[i].Text;
                    }
                }

                connection.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();

                ParinteGridViewUpdate(Int32.Parse(textBoxes[n - 1].Text.ToString()));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        
    }
}
