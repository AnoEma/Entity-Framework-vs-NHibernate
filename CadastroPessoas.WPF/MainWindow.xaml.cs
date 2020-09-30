using CadastroPessoas.Dominio;
using CadastroPessoas.Repositorio;
using System.Collections.Generic;
using System.Windows;

namespace CadastroPessoas.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CarregarDataGrid()
        {
            IRepositorio<Pessoa> repositorioPessoas = new PessoaRepositorio();
            List<Pessoa> pessoas = repositorioPessoas.SelecionarTodos();
            dgrPessoas.ItemsSource = pessoas;
        }

        private void dgrPessoas_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void WdwMain_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarDataGrid();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            WndCadastrarPessoas wndCadastrarPessoas = new WndCadastrarPessoas();
            wndCadastrarPessoas.ShowDialog();
            CarregarDataGrid();
        }
    }
}