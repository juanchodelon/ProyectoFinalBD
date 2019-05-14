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
using System.Data;
using System.Collections;

namespace ProyectoFinal.pages
{
    /// <summary>
    /// Lógica de interacción para manRoles.xaml
    /// </summary>
    public partial class manRoles : Page
    {
        DBconexion db = new DBconexion();
        int codigo;
        string tabla;
        public manRoles()
        {
            InitializeComponent();
            DataRowView r = DGroles.SelectedItem as DataRowView;
        }
        
        public void consulta(string t)
        {
            string s = "Select * From " + t;
            DataTable response = new DataTable();
            response = db.Consulta(s, null, null);
            DGroles.ItemsSource = response.DefaultView;
            tabla = t;
        }
        private void DGroles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = DGroles.SelectedItem as DataRowView;
            if (row != null)
            {
                txtbox1.IsEnabled = true;
                codigo = Convert.ToInt32(row["ID"]);
                txtbox1.Text = row["nombre"].ToString();
                lblDelete.Content = row["nombre"].ToString();
            }
            else
            {
                txtbox1.IsEnabled = false;
                txtbox1.Text = " ";
                lblDelete.Content = " ";
            }
        }
        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            string s = "Update rol Set nombre=@rol Where rolID=@id";
            ArrayList nombres = new ArrayList();
            ArrayList values = new ArrayList();

            nombres.Add("@rol");
            nombres.Add("@id");
            values.Add(txtbox1.Text);
            values.Add(codigo);

            resultado.Content = db.crud(s, nombres, values);

        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            string s = "Insert Into " + tabla + " (nombre) Values(@rol)";

            ArrayList nombres = new ArrayList();
            ArrayList values = new ArrayList();

            nombres.Add("@rol");
            values.Add(txtNew.Text);

            resultadoNew.Content = db.crud(s, nombres, values);
        }

        private void BtnBorrar(object sender, RoutedEventArgs e)
        {
            string s = "Delete From rol Where ID=@id";

            ArrayList nombres = new ArrayList();
            ArrayList values = new ArrayList();

            nombres.Add("@rol");
            nombres.Add("@id");
            values.Add(lblDelete.Content);
            values.Add(codigo);

            resultadoDel.Content = db.crud(s, nombres, values);
        }

    }
}
