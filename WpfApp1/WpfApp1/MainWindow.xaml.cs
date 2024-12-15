using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Jedzenie> jedz = new List<Jedzenie>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Okno okno = new Okno();
            okno.Owner = this;
            okno.window = this;
            okno.ShowDialog();
            UiChange();
        }

        private void UiChange()
        {
            lista.ItemsSource = null;
            lista.ItemsSource = jedz;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Okno okno = new Okno();
            okno.Owner = this;
            okno.window = this;
            if (lista.SelectedItem != null)
            {
                okno.jedzenie = jedz[lista.SelectedIndex];
                okno.Zmien();
            }
            else
            {
                okno.jedzenie = jedz.Last();
                okno.Zmien();
            }
            okno.edit = true;
            okno.ShowDialog();
            UiChange();
        }

        private void Delate_Click(object sender, RoutedEventArgs e)
        {
            
            if(MessageBox.Show("czy susunac","ok",MessageBoxButton.YesNo,MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                if (lista.SelectedItem != null)
                {
                    jedz.Remove(jedz[lista.SelectedIndex]);
                }
                else
                {
                    jedz.Remove(jedz.Last());
                }
                UiChange();
            }
        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Title = "Otwieranie pliku";
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            List<string> a = new List<string>();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                a = new List<string>(File.ReadAllLines(openFileDialog.FileName));
            }


            foreach(string b in a)
            {
                Jedzenie jedzenie = new Jedzenie();

                // "hajs: "+hajs+" nazwa: "+Nazwa+" sk: "+skladniki+" kraj: "+kraj;
                // HAJS
                int pFrom = b.IndexOf("hajs: ") + "hajs: ".Length;
                int pTo = b.LastIndexOf(" nazwa: ");

                string result = b.Substring(pFrom, pTo - pFrom);

                //NAZWA
                jedzenie.hajs = float.Parse(result);
                pFrom = b.IndexOf(" nazwa: ") + " nazwa: ".Length;
                pTo = b.LastIndexOf(" sk: ");

                result = b.Substring(pFrom, pTo - pFrom);
                jedzenie.Nazwa = result;
                // SKŁADNIKI
                pFrom = b.IndexOf(" sk: ") + " sk: ".Length;
                pTo = b.LastIndexOf(" kraj: ");

                result = b.Substring(pFrom, pTo - pFrom);
                jedzenie.skladniki = result;

                //KRAJ
                pFrom = b.LastIndexOf(" kraj: ");

                result = b.Substring(pFrom);
                jedzenie.kraj = result;
                jedz.Add(jedzenie);

            }
            UiChange();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = "Okno zapisywania do pliku";
            saveFileDialog.InitialDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<string> a = new List<string>();
                foreach (Jedzenie abc in jedz)
                {
                    a.Add(abc.ToString());
                }
                File.WriteAllLines(saveFileDialog.FileName, a);
            }

        }

        private void font_dialog_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FontDialog fd = new System.Windows.Forms.FontDialog();
            var result = fd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Debug.WriteLine(fd.Font);

                lista.FontFamily = new FontFamily(fd.Font.Name);
                lista.FontSize = fd.Font.Size * 96.0 / 72.0;
                lista.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                lista.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;

                TextDecorationCollection tdc = new TextDecorationCollection();
                if (fd.Font.Underline) tdc.Add(TextDecorations.Underline);
                if (fd.Font.Strikeout) tdc.Add(TextDecorations.Strikethrough);
                //v_list.TextDecorations = tdc;
            }
        }

        private void font_color_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog cd = new System.Windows.Forms.ColorDialog();
            var result = cd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                lista.Foreground = new SolidColorBrush(Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B));
            }
        }
    }
}
