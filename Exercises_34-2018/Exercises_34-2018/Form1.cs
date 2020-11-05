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

namespace Exercises_34_2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
                List<ExerciseResults> lista = new List<ExerciseResults>();
                string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FacultyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection cnn = new SqlConnection(constring);
                cnn.Open();
                string query = "SELECT * FROM ExerciseResults";
                SqlCommand com = new SqlCommand(query, cnn);
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    int idtemp = dr.GetInt32(0);
                    string nametemp = dr.GetString(1);
                    string indextemp = dr.GetString(2);
                    int pointstemp = dr.GetInt32(3);
                    ExerciseResults es = new ExerciseResults(idtemp, nametemp, indextemp, pointstemp);
                    lista.Add(es);
                }
                foreach (ExerciseResults n in lista)
                {
                listBoxExerciseResults.Items.Add(n.ToString());
                }

            }
        }
    }
