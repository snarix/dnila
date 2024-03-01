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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для BigMain.xaml
    /// </summary>
    public partial class BigMain : Window
    {
        public TESTEntities entities = TESTEntities.GetContext();

        public BigMain(int x)
        {
            InitializeComponent();

            if (x == 2)
            {
                q.IsEnabled = false;
                w.IsEnabled = false;
                e.IsEnabled = false;
            }
            entities.Копия_Товар_import_Посуда.Load();
            ImportTable.ItemsSource = entities.Копия_Товар_import_Посуда.Local.ToBindingList();


        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddTable add = new AddTable();
            add.Owner = this;
            add.ShowDialog();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            int indexRow = ImportTable.SelectedIndex;
            if (indexRow != -1)
            {
                Копия_Товар_import_Посуда row = (Копия_Товар_import_Посуда)ImportTable.Items[indexRow];
                Data.Id = row.Id;

                EditTable edit = new EditTable();
                edit.ShowDialog();

                ImportTable.Items.Refresh();
                ImportTable.Focus();
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Копия_Товар_import_Посуда row = (Копия_Товар_import_Посуда)ImportTable.SelectedItems[0];
                entities.Копия_Товар_import_Посуда.Remove(row);
                entities.SaveChanges();
                ImportTable.Items.Refresh();
            }
            catch (Exception)
            {

                MessageBox.Show("Выберите запись");
            }
        }
    }
}
