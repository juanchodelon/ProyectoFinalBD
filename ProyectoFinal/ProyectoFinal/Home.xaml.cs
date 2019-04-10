using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Collections;
using ProyectoFinal.Properties;


namespace ProyectoFinal
{
    public partial class Home : Window
    {
        public int id;
        DBconexion db = new DBconexion();
        public Home()
        {
            InitializeComponent();
        }

        public void user()
        {
            DataTable res = new DataTable();
            string s = "";
            if (id < 100)
            {
                s = "Select* From administrador Where adminID = @id";
                Frame.Navigate(new test1());
            }
            else if (id < 300 && id >= 100)
                s = "Select* From enfermera Where enfermeraID = @id";
            else if (id >= 300)
                s = "Select* From Doctor Where doctorID = @id";
            
            ArrayList nombres = new ArrayList();
            ArrayList values = new ArrayList();

            nombres.Add("@id");
            values.Add(id);
            
            res = db.Consulta(s, nombres, values);

            if (res != null)
            {
                if (res.Rows.Count > 0)
                    txtnombre.Content = res.Rows[0][2].ToString().Trim() +" "+ res.Rows[0][3].ToString().Trim();
                else
                    MessageBox.Show("parece que hubo un error");
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

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            id = 0;
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
