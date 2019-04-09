using System;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

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
            try
            {
                DataTable response = new DataTable();
                ArrayList nombres = new ArrayList();
                ArrayList values = new ArrayList();
                string s = "Select * From usuario Where username = @username AND password = @password";

                nombres.Add("@username");
                nombres.Add("@password");
                values.Add(Username.Text);
                values.Add(Password.Password);

                response = db.Consulta(s, nombres, values);
                nombres.Clear();
                values.Clear();

                if (response != null)
                {
                    if (response.Rows.Count > 0)
                    {
                        Home home = new Home();
                        home.id = Convert.ToInt32(response.Rows[0][0]);
                        home.user();
                        home.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("datos erroneos");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                
            }

            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
