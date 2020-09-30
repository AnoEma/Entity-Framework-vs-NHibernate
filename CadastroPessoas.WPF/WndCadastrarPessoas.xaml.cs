using CadastroPessoas.Dominio;
using CadastroPessoas.Repositorio;
using System;
using System.Windows;

namespace CadastroPessoas.WPF
{
    /// <summary>
    /// Interaction logic for WndCadastrarPessoas.xaml
    /// </summary>
    public partial class WndCadastrarPessoas : Window
    {
        public WndCadastrarPessoas()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            IRepositorio<Pessoa> repositorioPessoas = new PessoaRepositorio();
            Pessoa pessoa = new Pessoa
            {
                Nome = txbNomePessoa.Text,
                Idade = Convert.ToInt32(txbIdadePessoa.Text),
                Endereco = txbEnderecoPessoa.Text
            };

            repositorioPessoas.Adicionar(pessoa);
            Close();
        }
    }
}