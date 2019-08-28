using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace ProyectoFinal.pages
{
    /// <summary>
    /// Lógica de interacción para reportes.xaml
    /// </summary>
    public partial class reportes : Page
    {
        SqlParameter parametro = new SqlParameter();
        DBconexion db = new DBconexion();
        public reportes()
        {
            InitializeComponent();
            tabla1();
        }

        void tabla1()
        {
            string s = "select E.nombre, count(ID) as cantidad from especialidad as E inner join usuario as U " +
                "on U.especialidadID = E.ID group by E.nombre";
            DataTable response = new DataTable();
            response = db.Consulta(s, null, null);
            dgdocs.ItemsSource = response.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = "select p.nombre, fecha_entrada, fecha_salida, enf.nombre ,u.nombre as doctor " +
                "from hospitalizacion as h inner join pasiente as p on h.pasienteID = p.pasienteID inner join usuario as u on h.doctorID = u.usuarioID inner join enfermedades enf on h.motivo = enf.id " +
                "where fecha_entrada between '" + dp1.SelectedDate + "' and '" + dp2.SelectedDate + "'";
            DataTable response = new DataTable();
            response = db.Consulta(s, null, null);
            dghosps.ItemsSource = response.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string s = "select p.nombre, fecha_llegada, enf.nombre, u.nombre as doctor " +
                "from chequeo as h inner join pasiente as p on h.pasienteID = p.pasienteID inner join usuario as u on h.doctorID = u.usuarioID inner join enfermedades enf on h.motivo = enf.id " +
                "where fecha_llegada between '" + dp3.SelectedDate + "' and '" + dp4.SelectedDate + "'";
            DataTable response = new DataTable();
            response = db.Consulta(s, null, null);
            dgcons.ItemsSource = response.DefaultView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string s = "select e.nombre, count(e.ID) from enfermedades e join chequeo c " +
                "on e.id = c.motivo where fecha_llegada between '" + dp6.SelectedDate + "' and '" + dp7.SelectedDate + "' group by e.nombre";
            DataTable response = new DataTable();
            response = db.Consulta(s, null, null);
            dgenfs.ItemsSource = response.DefaultView;
        }
    }
}
