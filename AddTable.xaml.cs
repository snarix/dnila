using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddTable.xaml
    /// </summary>
    public partial class AddTable : Window
    {
        public TESTEntities entities = TESTEntities.GetContext();
        public Копия_Товар_import_Посуда suppl = new Копия_Товар_import_Посуда();
        public AddTable()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                suppl.Наименование = NameTb.Text;
                suppl.Стоимость = Convert.ToInt16(StoimTb.Text);
                suppl.Категория_товара = CatTb.Text;
                suppl.Кол_во_на_складе = Convert.ToByte(CountTb.Text);
                if (open.SafeFileName.Length != 0)
                {
                    string newPhoto = Directory.GetCurrentDirectory() + "\\Photo\\" + open.SafeFileName;
                    File.Copy(open.FileName, newPhoto, true);  
                    suppl.Изображение = open.SafeFileName;
                }

                entities.Копия_Товар_import_Посуда.Add(suppl);
                entities.SaveChanges();
            }
            catch (Exception)
            {

                MessageBox.Show("Чет не то");
            }

        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        OpenFileDialog open = new OpenFileDialog();
        private void PhotoClick(object sender, RoutedEventArgs e)
        {
            open.Filter = "Все файлы |*.*| Файлы *.jpg|*.jpg";
            open.FilterIndex = 2;
            if (open.ShowDialog() == true)
            {
                BitmapImage photoImage = new BitmapImage(new Uri(open.FileName));
                imgPhoto.Source = photoImage;
            }
        }
    }
}
