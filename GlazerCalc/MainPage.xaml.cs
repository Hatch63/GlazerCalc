using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            double width = 0;
            double height = 0;
            var tint = comTint;
            double quantity = 0;
            double woodLength;
            double glassArea;

            //HEIGHT CHECK
            if(double.TryParse(txtHeight.Text, out double number))
            {
                height = double.Parse(txtHeight.Text);
                heightOutput.Text = txtHeight.Text;
                txtHeight.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
            }
            else
            {
                txtHeight.Text = "Invalid Entry";
                txtHeight.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }

            //WIDTH CHECK
            if (double.TryParse(txtWidth.Text, out double number2))
            {
                width = double.Parse(txtWidth.Text);
                widthOutput.Text = txtWidth.Text;
                txtWidth.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
            }
            else
            {
                txtWidth.Text = "Invalid Entry";
                txtWidth.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }

            //SLIDER VALUE
            if(double.TryParse(quantityOutput.Text, out double number3))
            {
                quantity = double.Parse(quantityOutput.Text);
            }
            else
            {
                quantityOutput.Text = "Please chose a quantity";
            }

            //TINT COLORS
            if(comTint.SelectedIndex == -1)
            {
                tintOutput.Text = "Please choose a color";
            }
            else if(comTint.SelectedIndex == 0)
            {
                tintOutput.Text = "Black";
            }
            else if (comTint.SelectedIndex == 1)
            {
                tintOutput.Text = "Brown";
            }
            else if (comTint.SelectedIndex == 2)
            {
                tintOutput.Text = "Blue";
            }

            //CALCULATIONS
            if(!(width==0 || height==0 || comTint.SelectedIndex==-1 || quantity == -1))
            {
                woodLength = (2 * (width + height) * 3.25) * quantity;
                glassArea = (2 * (width * height)) * quantity;
                lengthOutput.Text = woodLength.ToString();
                areaOutput.Text = glassArea.ToString();
            }

            //ADD DATE
            dateOutput.Text = DateTime.Now.ToString();


        }

        private void ComTint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void SldQuantity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            quantityOutput.Text = ((Slider)sender).Value.ToString();
        }
    }
}
