using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;
        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            AtualizarCamposDeTexto();
            AtualizarControles();
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        private void AtualizarControles()
        {
            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;

            btnOk.Click += cancelarEventHandler;
            btnCancelar.Click += okEventHandler;

            txtNome.Validacao += ValidarCampoNulo;
            txtTelefone.Validacao += ValidarCampoNulo;
            txtEndereco.Validacao += ValidarCampoNulo;
            txtDescricao.Validacao += ValidarCampoNulo;

            txtNumero.Validacao += ValidarCampoNulo;
            txtNumero.Validacao += ValidarSomenteDigito;
        }

        private void ValidarSomenteDigito(object sender, ValidacaoEventArgs e)
        {
            e.Valido = e.Texto.All(Char.IsDigit);
        }
        private void ValidarCampoNulo(object sender, ValidacaoEventArgs e)
        {
            e.Valido = !String.IsNullOrWhiteSpace(e.Texto);
        }

        //private void ValidarSomenteDigito(object sender, EventArgs e)
        //{
        //    var txt = sender as TextBox;

        //    //Func<char, bool> verificaSeEDigito = caractere =>
        //    //{
        //    //    return char.IsDigit(caractere);
        //    //};

        //    var todosCaracteresSaoDigitos = txt.Text.All(Char.IsDigit);

        //    txt.Background = todosCaracteresSaoDigitos
        //        ? new SolidColorBrush(Colors.White)
        //        : new SolidColorBrush(Colors.OrangeRed);
        //}




        //private void ValidarCampoNulo(object sender, EventArgs e)
        //{
        //    var txt = sender as TextBox;
        //    var textoEstaVazio = String.IsNullOrWhiteSpace(txt.Text);

        //    txt.Background = textoEstaVazio
        //    ? new SolidColorBrush(Colors.OrangeRed)
        //    : new SolidColorBrush(Colors.White);
        //}


        //private TextChangedEventHandler ConstruirDelegateDeValidacaoCampoNulo(TextBox txt)
        //{
        //    return (o, e) =>
        //    {
        //        var textoEstaVazio = String.IsNullOrWhiteSpace(txt.Text);

        //        txt.Background = textoEstaVazio
        //        ? new SolidColorBrush(Colors.OrangeRed)
        //        : new SolidColorBrush(Colors.White);

        //    };
        //}

        private void Fechar(object sender, EventArgs e) =>
            Close();
    }
}
