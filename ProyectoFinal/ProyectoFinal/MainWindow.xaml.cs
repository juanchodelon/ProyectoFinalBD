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
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DBconexion db = new DBconexion();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAcceder_Click(object sender, RoutedEventArgs e)
        {
            DataTable response = new DataTable();
            response = db.Autenticar(Username.Text, Password.Password);
            if (response != null)
            {
                if(response.Rows.Count > 0)
                {
                    MessageBox.Show("Bienvenido " + response.Rows[0][1].ToString());
                }
                else
                {
                    MessageBox.Show("datos erroneos");
                }
            }
        }
    }
}
