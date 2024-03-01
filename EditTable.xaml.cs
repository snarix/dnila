using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для EditTable.xaml
    /// </summary>
    public static class Data { public static int Id; }

    public partial class EditTable : Window
    {
        public TESTEntities entities = TESTEntities.GetContext();
        public Копия_Товар_import_Посуда suppl = new Копия_Товар_import_Посуда();
        public EditTable()
        {
            InitializeComponent();
            entities.Копия_Товар_import_Посуда.Load();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            try
            {
                suppl.Наименование = NameTb.Text;
                suppl.Стоимость = Convert.ToInt16(StoimTb.Text);
                suppl.Категория_товара = CatTb.Text;
                suppl.Кол_во_на_складе = Convert.ToByte(CountTb.Text);

                entities.SaveChanges();
                this.Close();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            suppl = entities.Копия_Товар_import_Посуда.Find(Data.Id);
            NameTb.Text = suppl.Наименование;
            StoimTb.Text = suppl.Стоимость.ToString();
            CatTb.Text = suppl.Категория_товара;
            CountTb.Text = suppl.Кол_во_на_складе.ToString();
        }
    }
}
