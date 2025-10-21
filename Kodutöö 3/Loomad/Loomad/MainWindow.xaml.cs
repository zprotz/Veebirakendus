using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Loomad
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Animal> Animals { get; set; } = new ObservableCollection<Animal>();
        public ObservableCollection<string> LogEntries { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

            LogListBox.ItemsSource = LogEntries;
            AnimalsListBox.ItemsSource = Animals;
            AnimalsListBox.DisplayMemberPath = "Name";

            AddAnimals();
        }

        public void AddAnimals()
        {
            Animals.Add(new Lehm { Name = "Mihku", Age = 3, Color = "must valge", Home = "Kesk Eesti" });
            Animals.Add(new Elevant { Name = "Mambo", Age = 15, Color = "hall", Home = "Aafrika savann" });
            Animals.Add(new Vares { Name = "Mia", Age = 2, Color = "must", Home = "linnapargis" });
        }

        public void AddToLog(string message)
        {
            LogEntries.Add($"{DateTime.Now:HH:mm:ss}: {message}");
        }

        private void AnimalsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selectedAnimal)
            {
                AnimalDetailsText.Text = selectedAnimal.Describe();
            }
        }

        private void AddAnimal(object sender, RoutedEventArgs e)
        {
            Animals.Add(new Lehm { Name = "Uus Lehm", Age = 1, Color = "pruun", Home = "uus farm" });
            AddToLog("Lisati uus loom: Uus Lehm");
        }

        private void RemoveAnimal(object sender, RoutedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selectedAnimal)
            {
                string animalName = selectedAnimal.Name;
                Animals.Remove(selectedAnimal);
                AddToLog($"Eemaldati loom: {animalName}");
            }
            else
            {
                AddToLog("Vali loom mida eemaldada!");
            }
        }

        private void MakeSound(object sender, RoutedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selectedAnimal)
            {
                string SoundText = selectedAnimal.MakeSound();
                AddToLog($"{ SoundText}");
            }
        }


        private void Feed(object sender, RoutedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selectedAnimal && !string.IsNullOrWhiteSpace(FoodTextBox.Text))
            {
                AddToLog($"{selectedAnimal.Name} sõi {FoodTextBox.Text}");
                FoodTextBox.Clear();
            }
        }

        private void CrazyAction(object sender, RoutedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selectedAnimal)
            {
                if (selectedAnimal is ICrazyAction crazyAnimal)
                {
                    
                    string CrazyText = crazyAnimal.ActCrazy();
                    AddToLog($"{CrazyText}");
                }

                else
                {
                    AddToLog($"{selectedAnimal.Name} ei oska teha crazy actionit!");
                }
            }
        }

        private void Fly(object sender, RoutedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selectedAnimal)
            {
                if (selectedAnimal is IFlyable flyableAnimal)
                {
                    string flyText = flyableAnimal.Fly();
                    AddToLog(flyText);
                }
                else
                {
                    AddToLog($"{selectedAnimal.Name} ei oska lennata!");
                }
            }
        }

        private void FoodTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}