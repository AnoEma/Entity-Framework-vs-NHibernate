using CadastroPessoas.Dominio;
using CadastroPessoas.Repositorio;
using System;
using System.Windows.Forms;

namespace CadastroPessoas
{
    public partial class FrmAdicionarPessoas : Form
    {
        public FrmAdicionarPessoas()
        {
            InitializeComponent();
        }

        private void lblIdade_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa pessoas = new Pessoa
            {
                Nome = txbNome.Text,
                Idade = Convert.ToInt32(txbIdade.Text),
                Endereco = txbEndereco.Text
            };

            IRepositorio<Pessoa> repositorioPessoas = new PessoaRepositorio();
            repositorioPessoas.Adicionar(pessoas, (linhasAfetadas) =>
            {
                MessageBox.Show(string.Format("Fora inseridos {0} registros.", linhasAfetadas));
            });
            Close();
        }
    }
}