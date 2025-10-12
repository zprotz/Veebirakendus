using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LIHAPOOD
{

    // Esialgsete funktioonside ja elementide tähistamine
    public partial class MainWindow : Window
    {
        private List<Meat> meats = new List<Meat>();
        private List<Meat> allMeats;

        public MainWindow()
        {
            InitializeComponent();
            LoadSampleData();
            MeatDataGrid.ItemsSource = meats;
            allMeats = new List<Meat>(meats);
            UpdateStatus();
        }


        // Info erinavate toodete kohta mis kasutatakse DataGridis.
        private void LoadSampleData()
        {
            meats.Add(new Meat("Kanafilee", 9, "Tartumaa", DateTime.Now.AddDays(5), "Kanaliha"));
            meats.Add(new Meat("Kanakintsuliha", 12, "Tartumaa", DateTime.Now.AddDays(3), "Kanaliha"));
            meats.Add(new Meat("Seasisefilee", 8, "Harjumaa", DateTime.Now.AddDays(7), "Sealiha"));
            meats.Add(new Meat("Veiseliha", 22.99, "Põlvamaa", DateTime.Now.AddDays(2), "Veiseliha"));
        }

        // Funktsioon mille abil saab nupuga lisada toote.
        private void AddButton(object sender, RoutedEventArgs e)
        {

            var newMeat = new Meat("Uus Liha", 10.0, "Asukoht", DateTime.Now.AddDays(5), "Kanaliha");
            meats.Add(newMeat);
            RefreshDataGrid();
        }

        // Funktsioon millega saab muuta toodet.
        private void EditButton(object sender, RoutedEventArgs e)
        {
            if (MeatDataGrid.SelectedItem is Meat selectedMeat)
            {

                selectedMeat.Pricekg += 1.0;
                RefreshDataGrid();
            }
        }
        // Funktsioon millega saab eemaldada rida.
        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (MeatDataGrid.SelectedItem is Meat selectedMeat)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show(
                    $"Soovite kustutada? '{selectedMeat.Name}'?",
                    "Kinnitage kustutamine",
                    MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    meats.Remove(selectedMeat);
                    allMeats.Remove(selectedMeat);
                    RefreshDataGrid();
                }
            }
        }

        // Sorteerib hinnaga.
        private void SortByPrice(object sender, RoutedEventArgs e)
        {
            meats = meats.OrderBy(m => m.Pricekg).ToList();
            RefreshDataGrid();
        }

        // Otsi toodet.
        private void SearchBox(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchTextBox.Text.ToLower();
            
            if (string.IsNullOrWhiteSpace(searchText))
            {
                meats = new List<Meat>(allMeats);
            }
            else
            {
                meats = allMeats.Where(m => 
                    m.Name.ToLower().Contains(searchText) ||
                    m.Location.ToLower().Contains(searchText) ||
                    m.Type.ToLower().Contains(searchText)
                ).ToList();
            }
            RefreshDataGrid();
        }


        // Uuendab Datagridi.
        private void RefreshDataGrid()
        {
            MeatDataGrid.ItemsSource = null;
            MeatDataGrid.ItemsSource = meats;
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            StatusText.Text = $"Kokku leitud: {meats.Count} eset";
        }

        private void MeatDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}