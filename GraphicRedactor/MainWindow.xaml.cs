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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace GraphicRedactor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage pic;
        public MainWindow()
        {
            InitializeComponent();
            pic = new BitmapImage();
        }
        void ExitItemRed_CLick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemRed_CLick(object sender, RoutedEventArgs e)
        {
            MainInk.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void MenuItemBlue_CLick(object sender, RoutedEventArgs e)
        {
            MainInk.DefaultDrawingAttributes.Color = Colors.Blue;
        }

        private void MenuItemGreen_CLick(object sender, RoutedEventArgs e)
        {
            MainInk.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void MenuItemDraw(object sender, RoutedEventArgs e)
        {
            MainInk.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void MenuItemRedact(object sender, RoutedEventArgs e)
        {
            MainInk.DefaultDrawingAttributes.Color = Colors.White;
        }

        private void MenuItemDelete(object sender, RoutedEventArgs e)
        {
            this.MainInk.Strokes.Clear();
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                MainInk.DefaultDrawingAttributes.Width = ((Slider)sender).Value;
                MainInk.DefaultDrawingAttributes.Height = ((Slider)sender).Value;
            }
            catch { };
        }

        private void MenuItemYellow_CLick(object sender, RoutedEventArgs e)
        {
            MainInk.DefaultDrawingAttributes.Color = Colors.Yellow;
        }

        private void MenuItemBlack_CLick(object sender, RoutedEventArgs e)
        {
            MainInk.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void MenuItemOrange_CLick(object sender, RoutedEventArgs e)
        {
            MainInk.DefaultDrawingAttributes.Color = Colors.Orange;
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "InkCanvas Format |*.sandy";
            dig.Title = "Save InkCanvas File";
            dig.ShowDialog();
            if (dig.FileName == "") return;
            FileStream fs = File.Open(dig.FileName, FileMode.OpenOrCreate);
            MainInk.Strokes.Save(fs);
            fs.Close();
        }

        private void LoadFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dig1 = new SaveFileDialog();
            dig1.Title = "Load InkCanvas File";
            dig1.DefaultExt = "sandy";
            dig1.Filter = "InkCanvas Format(.sandy) |*.sandy";
            dig1.ShowDialog();
            if (dig1.FileName == "") return;
            FileStream fs = File.Open(dig1.FileName, FileMode.OpenOrCreate);
            StrokeCollection strkk = new StrokeCollection(fs);
            MainInk.Strokes=strkk;
            fs.Close();
        }
    }
}
