using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DuplicaObjetos
{
    public class Produto
    {
        public int id { get; set; }

        public string nome { get; set; }

        public decimal valor { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       



        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Produto p1 = new Produto();

            p1.id = 1;
            p1.nome = "PRODUTO TESTE";
            p1.valor = (decimal)1.99;


            Produto p2 = (Produto)CloneObject(p1, typeof(Produto));

            p2.nome = "PRODUTO JSON";

            //Produto p2 = new Produto
            //{
            //    id = p1.id,
            //    nome = p1.nome,
            //    valor = p1.valor
            //};

            Produto p3 = p1;


            MessageBox.Show("P2: " + p2.nome);
            MessageBox.Show("P1: " + p1.nome);

            p1.nome = "PRODUTO MODIFICADO";

            MessageBox.Show("P2: " + p2.nome);
            MessageBox.Show("P1: " + p1.nome);

        }

        public static object CloneObject(object original, Type tipo)
        {
            string serializacao = JsonConvert.SerializeObject(original);

            return JsonConvert.DeserializeObject(serializacao, tipo);
        }


    }
}
