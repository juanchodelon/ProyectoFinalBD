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
using System.Collections;
using System.Data;
using ProyectoFinal.pages;

namespace ProyectoFinal.pages
{
    /// <summary>
    /// Lógica de interacción para Enfermera.xaml
    /// </summary>

    public partial class Enfermera : Page
    {
        public DataTable datos = new DataTable();
        public string a;
        public Enfermera()
        {   
            
            InitializeComponent();
        }
        public void test()
        {
            Habitacion.Content = datos.Rows[0][10].ToString(); ;
        }
    }
}
