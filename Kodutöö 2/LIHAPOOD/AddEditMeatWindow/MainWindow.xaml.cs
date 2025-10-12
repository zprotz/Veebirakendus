using System;
using System.Windows;
using System.Windows.Controls;

namespace LIHAPOOD
{
    public partial class AddEditMeatWindow : Window
    {
        public Meat NewMeat { get; private set; }

        public AddEditMeatWindow()
        {
            InitializeComponent();
            TypeComboBox.SelectedIndex = 0;
            FreshUntilDatePicker.SelectedDate = DateTime.Now.AddDays(7);
        }

        public AddEditMeatWindow(Meat meatToEdit) : this()
        {
            NameTextBox.Text = meatToEdit.Name;
            PriceTextBox.Text = meatToEdit.Pricekg.ToString();
            LocationTextBox.Text = meatToEdit.Location;
            FreshUntilDatePicker.SelectedDate = meatToEdit.FreshUntil;
            TypeComboBox.Text = meatToEdit.Type;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NewMeat = new Meat(
                NameTextBox.Text,
                double.Parse(PriceTextBox.Text),
                LocationTextBox.Text,
                FreshUntilDatePicker.SelectedDate.Value,
                TypeComboBox.Text
            );

            DialogResult = true;
            Close();
        }
    }
}