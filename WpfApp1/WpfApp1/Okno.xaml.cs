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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Okno.xaml
    /// </summary>
    public partial class Okno : Window
    {
        public MainWindow window;
        public Jedzenie jedzenie = new Jedzenie();
        public bool edit = false;
        public Okno()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(edit == false)
            {
                jedzenie.Nazwa = Name_name.Text;
                jedzenie.kraj = kraj_name.Text;
                jedzenie.skladniki = sk_name.Text;
                jedzenie.hajs = float.Parse(hajs_id.Text);
                window.jedz.Add(jedzenie);
            }
            else
            {
                jedzenie.Nazwa = Name_name.Text;
                jedzenie.kraj = kraj_name.Text;
                jedzenie.skladniki = sk_name.Text;
                jedzenie.hajs = float.Parse(hajs_id.Text);
            }
            Close();
        }
            
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Zmien()
        {
            Name_name.Text = jedzenie.Nazwa;
            kraj_name.Text = jedzenie.kraj;
            sk_name.Text = jedzenie.skladniki;
            hajs_id.Text = jedzenie.hajs.ToString();
        }
    }
}
