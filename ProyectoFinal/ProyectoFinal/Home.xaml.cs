using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Collections;
using ProyectoFinal.pages;
using System.Xaml;


namespace ProyectoFinal
{
    public partial class Home : Window
    {
        int id, rol;
        public DataTable datos = new DataTable();
        DBconexion db = new DBconexion();
        Enfermera enfermera = new Enfermera();
        manRoles mantenimiento = new manRoles();
        public Home()
        {
            InitializeComponent();
        }

        public void user()
        {
            rol = Convert.ToInt32(datos.Rows[0][9]);
            id = Convert.ToInt32(datos.Rows[0][0]);
            DataTable res = new DataTable();
            string s = "Select * From usuario Where usuarioID = @id";

            ////////// OPCIONES
            if (rol == 6)
            {
                lblTitulo.Content = "Roles";
                menuSupervisor.Visibility = Visibility.Visible;
                menuAdmin.Visibility = Visibility.Hidden;
                mantenimiento.consulta("rol");
                Frame.Navigate(mantenimiento);
            }
            else if (rol == 3)
            {
                lblTitulo.Content = "Asignacion de habitaciones";
                Frame.Navigate(new pages.Admin());
                menuSupervisor.Visibility = Visibility.Hidden;
                menuAdmin.Visibility = Visibility.Visible;
            }
            else if (rol == 1)
            {
                Frame.Navigate(new Doctor());
                menuSupervisor.Visibility = Visibility.Hidden;
            }

            ArrayList nombres = new ArrayList();
            ArrayList values = new ArrayList();

            nombres.Add("@id");
            values.Add(id);

            res = db.Consulta(s, nombres, values);

            if (res != null)
            {
                if (res.Rows.Count > 0)
                    txtnombre.Content = res.Rows[0][3].ToString().Trim() +" "+ res.Rows[0][4].ToString().Trim();
                else
                    MessageBox.Show("parece que hubo un error");
            }
        }

        private void Roles_Click(object sender, RoutedEventArgs e)
        {
            lblTitulo.Content = "Roles";
            mantenimiento.consulta("rol");
        }
        private void Esp_Click(object sender, RoutedEventArgs e)
        {
            lblTitulo.Content = "Especializacion";
            mantenimiento.consulta("especialidad");
        }
        private void Habitacion_Click(object sender, RoutedEventArgs e)
        {
            lblTitulo.Content = "sectores";
            mantenimiento.consulta("sector");
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            id = 0;
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Asign_Click(object sender, RoutedEventArgs e)
        {
            lblTitulo.Content = "asignacion de habitaciones";
            Frame.Navigate(new pages.Admin());
        }

        private void AsignPas_Click(object sender, RoutedEventArgs e)
        {
            lblTitulo.Content = "asignacion de pasientes";
            Frame.Navigate(new pages.aPasientes());
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
