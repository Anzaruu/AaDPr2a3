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
            IDPr.SelectedValuePath = "Id";
        }

        private void Produc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Produc.SelectedItem != null)
            {
                var sel = Produc.SelectedItem as DataRowView;
                Add.Text = sel.Row[1].ToString();
                IDPr.SelectedValue = (int)sel.Row[2];
            }
            else
            {
                Add.Text = null;
                IDPr.Text = null;
            }
        }

        private void AddProd_Click(object sender, RoutedEventArgs e)
        {
            productTableAdapter.InsertQuery2(Add.Text, (int)(IDPr.SelectedValue));
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

        private void UpdateProd_Click(object sender, RoutedEventArgs e)
        {
            var sel = (Produc.SelectedItem as DataRowView).Row[0];
            productTableAdapter.UpdateQuery(Add.Text, (int)(IDPr.SelectedValue), (int)sel);
            Produc.ItemsSource = productTableAdapter.GetData();
        }
    }
}
