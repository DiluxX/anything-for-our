using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private SolidColorBrush currentColor = Brushes.Black;
        private double currentThickness = 2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeBack_Click(object sender, RoutedEventArgs e)
        {
          
            var colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Background = new SolidColorBrush(Color.FromArgb(
                    colorDialog.Color.A,
                    colorDialog.Color.R,
                    colorDialog.Color.G,
                    colorDialog.Color.B));
                MessageBox.Show("Фон изменен");
            }
        }

        private void OBOMNE_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Информация о разработчике...");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ChangeInkColor_Click(object sender, RoutedEventArgs e)
        {
         
            var colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentColor = new SolidColorBrush(Color.FromArgb(
                    colorDialog.Color.A,
                    colorDialog.Color.R,
                    colorDialog.Color.G,
                    colorDialog.Color.B));
                inkCanvas.DefaultDrawingAttributes.Color = currentColor.Color;
               
            }
        }

        private void ChangeInkSize_Click(object sender, RoutedEventArgs e)
        {
            
            currentThickness += 1; 
            inkCanvas.DefaultDrawingAttributes.Width = currentThickness;
            inkCanvas.DefaultDrawingAttributes.Height = currentThickness;
        }

        private void UseEraser_Click(object sender, RoutedEventArgs e)
        {
            // Установка режима ластика
            var eraser = new DrawingAttributes
            {
                Color = Colors.White, 
                Width = 50, 
                Height = 50,
                IsHighlighter = false 
            };

           
            inkCanvas.DefaultDrawingAttributes = eraser;
        }
    }
}