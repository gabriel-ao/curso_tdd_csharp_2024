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
            var id = Guid.NewGuid().ToString();

            //Adicionar(id, nome);

            // buscando o ID e salvando no textBox


        }
    }
}