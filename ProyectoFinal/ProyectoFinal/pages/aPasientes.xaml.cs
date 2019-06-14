using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace ProyectoFinal.pages
{
    /// <summary>
    /// Lógica de interacción para aPasientes.xaml
    /// </summary>
    public partial class aPasientes : Page
    {
        DBconexion db = new DBconexion();
        string id;
        int cod;
        public aPasientes()
        {
            InitializeComponent();
            consulta();
        }

        void consulta()
        {
            string s = "select pasienteID, p.dpi, p.nombre, edad, p.celular, u.nombre as doctor, e.nombre as especialidad "
             + "from pasiente as p inner join usuario as u on p.doctorID = u.usuarioID inner join especialidad as e on u.especialidadID = e.ID";
            DataTable response = new DataTable();
            response = db.Consulta(s, null, null);
            dgPasiente.ItemsSource = response.DefaultView;
        }

        private void DGenfermeras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dgPasiente.SelectedItem as DataRowView;
            if (row != null)
            {
                obtener_habitaciones("Select nombre from especialidad ", cbespe);
                cbespe.IsEnabled = true;
                id = row["pasienteID"].ToString();
            }
        }

        private void Sector_DropDownClosed(object sender, EventArgs e)
        {
            obtener_habitaciones("Select U.nombre from usuario as U Inner Join especialidad as S on U.especialidadID = S.ID where S.nombre='" + cbespe.Text + "'", cbDoctores);
            cbDoctores.IsEnabled = true;
            btnasignar.IsEnabled = true;
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

        private void Btnasignar_Click(object sender, RoutedEventArgs e)
        {
            string s = "Update pasiente Set doctorID=@nombre Where pasienteID=@id";
            string c = "Select usuarioID From usuario where nombre = '" + cbDoctores.Text + "' ";

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
            values.Add(id);

            resultado.Content = db.crud(s, nombres, values);
            consulta();

        }
    }
}
