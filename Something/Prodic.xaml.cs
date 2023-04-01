using System;
using System.Collections.Generic;
using System.Data;
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
using Something.ProdDataSetTableAdapters;

namespace Something
{
    /// <summary>
    /// Логика взаимодействия для Prodic.xaml
    /// </summary>
    public partial class Prodic : Window
    {
        PriceTableAdapter priceTableAdapter = new PriceTableAdapter();
        ProductTableAdapter productTableAdapter = new ProductTableAdapter();
        public Prodic()
        {
            InitializeComponent();
            Produc.ItemsSource = productTableAdapter.GetData();
            IDPr.ItemsSource = priceTableAdapter.GetData();
            IDPr.DisplayMemberPath = "Sum";
        }

        private void Produc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Produc.SelectedItem != null)
            {
                var sel = Produc.SelectedItem as DataRowView;
            }
        }

        private void AddProd_Click(object sender, RoutedEventArgs e)
        {
            productTableAdapter.InsertQuery2(Add.Text, (int)(IDPr.SelectedValue as DataRowView).Row[0]);
            Produc.ItemsSource = productTableAdapter.GetData();
        }

        private void DeleteProd_Click(object sender, RoutedEventArgs e)
        {
            if (Produc.SelectedItem != null)
            {
                var sel = (Produc.SelectedItem as DataRowView).Row[0];
                productTableAdapter.DeleteQuery((int)sel);
                Produc.ItemsSource = productTableAdapter.GetData();
            }
        }
    }
}
