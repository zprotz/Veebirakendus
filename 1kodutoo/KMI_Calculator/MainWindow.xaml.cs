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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KMI_Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // funktsioon mis arvutab kmi valja
            if (double.TryParse(HeightTextBox.Text, out double height) &&
                double.TryParse(WeightTextBox.Text, out double weight))
            {
                double kmi = Mykmi(height, weight);

                if (kmi > 0)
                {
                    // arvutatakse kmi ja antakse info inimese kohta kas ta on alakaalus, tavaline, rasvund voi paks
                    string health = "";

                    if (kmi < 18.5)
                    {
                        health = "underweight";
                    }
                    else if (kmi < 25)
                    {
                        health = "normal";
                    }
                    else if (kmi < 30)
                    {
                        health = "overweight";
                    }
                    else
                    {
                        health = "obese";
                    }

                    // prindib valja kmi ja olek 
                    ResultTextBlock.Text = $"your KMI is {kmi:F2}";
                    HealthStatusTextBlock.Text = $"you are {health}";
                }
                else
                {
                    // kui sisestatakse ebarealistlik kaal voi pikkus siis vistatakse valja
                    ResultTextBlock.Text = "Enter valid weight/height";
                    HealthStatusTextBlock.Text = "";
                }
            }
            else
            {
                ResultTextBlock.Text = "Enter valid weight/height";
                HealthStatusTextBlock.Text = "";
            }
        }

        // funktsioon mis arvutab kmi valja
        public static double Mykmi(double height, double weight)
        {
            // kui sisestatakse ebarealistlik kaal voi pikkus siis vistatakse valja
            if (weight <= 0 || height <= 0)
            {
                return 0;
            }
            // arvutatakse kmi ja tagastatakse kmi
            else
            {
                double kmi = weight / (height * height);
                return kmi;
            }
        }
    }
}