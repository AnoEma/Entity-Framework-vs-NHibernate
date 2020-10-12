using CadastroPessoas.Dominio;
using CadastroPessoas.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroPessoas
{
    public partial class FrmPessoa : Form
    {
        private List<Pessoa> _pessoas = new List<Pessoa>();
        private static readonly object locker = new Object();
        public FrmPessoa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txbPesquisa.Text = string.Empty;
            PreencherDataGridViewAsync();
        }

        private async void PreencherDataGridViewAsync()
        {
            int quantidadeLinhas = await PreencherDataGridView();
            MessageBox.Show(string.Format("Há {0} registros.", quantidadeLinhas));
            dgvPessoa.Invoke((MethodInvoker)delegate
            {
                dgvPessoa.DataSource = _pessoas;
                dgvPessoa.Refresh();
            });
        }

        private Task<int> PreencherDataGridView()
        {
            return Task<int>.Run(() =>
            {
                Thread.Sleep(2000);
                IRepositorio<Pessoa> repositorio = new PessoaRepositorio();
                _pessoas = repositorio.SelecionarTodos();
                return _pessoas.Count;
            });
        }

        private void PreencherListaPessoas()
        {
            IRepositorio<Pessoa> repositorioPessoas = new PessoaRepositorio();
            List<Pessoa> pessoas = repositorioPessoas.SelecionarTodos();
            lock (locker)
            {
                foreach (Pessoa p in pessoas)
                {
                    p.Nome += "Thread 1";
                    _pessoas.Add(p);
                    Thread.Sleep(300);
                }
            }
        }

        private void PreencherListaPessoas2()
        {
            try
            {
                IRepositorio<Pessoa> repositorioPessoas = new PessoaRepositorio();
                List<Pessoa> pessoas = repositorioPessoas.SelecionarTodos();
                lock (locker)
                {
                    foreach (Pessoa p in pessoas)
                    {
                        p.Nome += "Thread 2";
                        _pessoas.Add(p);
                        Thread.Sleep(100);
                    }
                }
                throw new Exception("Acabou é Tetra!");
            }
            catch(Exception ex)
            {
                ExibirErro(ex);
            }
        }

        private void ExibirErro(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void bntAdicionarPessoa_Click(object sender, EventArgs e)
        {
            FrmAdicionarPessoas frmAdicionarPessoas = new FrmAdicionarPessoas();
            frmAdicionarPessoas.ShowDialog();
            PreencherDataGridViewAsync();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            IRepositorio<Pessoa> repositorio = new PessoaRepositorio();
            dgvPessoa.DataSource = repositorio.Selecionar(pessoa => pessoa.Nome.Contains(txbPesquisa.Text));
            dgvPessoa.Refresh();
        }
    }
}