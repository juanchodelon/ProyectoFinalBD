using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace ProyectoFinal.pages
{
    /// <summary>
    /// Lógica de interacción para Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        DBconexion db = new DBconexion();
        string nombre;
        SqlParameter parametro = new SqlParameter();
        public Admin()
        {
            InitializeComponent();
            llenarTabla();
        }

        void llenarTabla()
        {
            string s = "Select nombre, apellido, dpi, celular, direccion, habitacionID From usuario where rolID='2'";
            DataTable response = new DataTable();
            response = db.Consulta(s, null, null);
            DGenfermeras.ItemsSource = response.DefaultView;
        }

        private void DGenfermeras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = DGenfermeras.SelectedItem as DataRowView;
            if (row != null)
            {
                nombre = row["nombre"].ToString();
                txtEnfermera.Content = "Asignar / Reasignar habitacion para: " + nombre;
                obtener_habitaciones("Select nombre from sector", sector);
                sector.IsEnabled = true;
            }
            else
            {
                txtEnfermera.Content = "no se ha seleccionado enfermera";
            }
        }

        void obtener_habitaciones(string s, ComboBox c)
        {
            DataTable response = new DataTable();
            response = db.Consulta(s, null, null);

            c.Items.Clear();
            foreach (DataRow row in response.Rows)
            {
                foreach (DataColumn column in response.Columns)
                {
                    c.Items.Add(row[column].ToString());
                }
            }
        }
        

        private void Sector_DropDownClosed(object sender, EventArgs e)
        {
            obtener_habitaciones("Select habitacion from habitacion as H Inner Join sector as S on H.sector = S.ID where nombre='" + sector.Text + "'", habitacion);
            habitacion.IsEnabled = true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string c = "Select habitacionID from habitacion as H Inner Join sector as S on H.sector = S.ID where habitacion = '" + habitacion.Text + "'";
            string s = "Update usuario Set habitacionID=@nombre Where nombre=@id";
            int cod = 0;

            DataTable response = new DataTable();
            response = db.Consulta(c, null, null);
            foreach (DataRow row in response.Rows)
            {
                foreach (DataColumn column in response.Columns)
                {
                    cod = Convert.ToInt32(row[column]);
                }
            }
            
            ArrayList nombres = new ArrayList();
            ArrayList values = new ArrayList();

            nombres.Add("@nombre");
            nombres.Add("@id");
            values.Add(cod);
            values.Add(nombre);

            resultado.Content = db.crud(s, nombres, values);
            llenarTabla();

        }
    }
}
