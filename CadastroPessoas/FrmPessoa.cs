using CadastroPessoas.Dominio;
using CadastroPessoas.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading;
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
            Thread thread = new Thread(PreencherDataGridView);
            thread.Start();
        }

        private void PreencherDataGridView()
        {
            try
            {
                Thread.Sleep(5000);
                Thread thread = new Thread(PreencherListaPessoas);
                Thread thread2 = new Thread(PreencherListaPessoas2);
                thread.Start();
                thread2.Start();
                thread.Join();
                thread2.Join();
                dgvPessoa.Invoke((MethodInvoker)delegate { dgvPessoa.DataSource = _pessoas; dgvPessoa.Refresh(); });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            PreencherDataGridView();
        }
    }
}