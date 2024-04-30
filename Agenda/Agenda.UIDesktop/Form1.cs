using System.Data.SqlClient;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            //txtContatoSalvo.Text = nome;

            string strCon = @"Data Source=DESKTOP-98QJDF1\MSSQLSERVER01; Initial Catalog=Agenda; Integrated Security=True;";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();

            var ID = Guid.NewGuid().ToString();
            string sql = String.Format("insert into Contato (Id, Nome) values ('{0}', '{1}');", ID, nome);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            // buscando o ID e salvando no textBox
            sql = String.Format("select Nome from Contato where Id = '{0}'", ID);
            cmd = new SqlCommand(sql, con);
            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            con.Close();

        }
    }
}