using CadastroPessoas.Dominio;
using CadastroPessoas.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CadastroPessoas
{
    public partial class FrmPessoa : Form
    {
        public FrmPessoa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PreencherDataGridView();
        }

        private void PreencherDataGridView()
        {
            IRepositorio<Pessoa> repositorioPessoas = new PessoaRepositorio();
            List<Pessoa> pessoas = repositorioPessoas.SelecionarTodos();
            dgvPessoa.DataSource = pessoas;
            dgvPessoa.Refresh();
        }

        private void bntAdicionarPessoa_Click(object sender, EventArgs e)
        {
            FrmAdicionarPessoas frmAdicionarPessoas = new FrmAdicionarPessoas();
            frmAdicionarPessoas.ShowDialog();
            PreencherDataGridView();
        }
    }
}