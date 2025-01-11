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

namespace MoveRectangle.HW
{
    public partial class MainWindow : Window
    {
        private bool isDragging = false;
        private Point clickPosition;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            clickPosition = e.GetPosition(this);
            rectangle.CaptureMouse();
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var currentPosition = e.GetPosition(this);
                double offsetX = currentPosition.X - clickPosition.X;
                double offsetY = currentPosition.Y - clickPosition.Y;

                double newX = Canvas.GetLeft(rectangle) + offsetX;
                double newY = Canvas.GetTop(rectangle) + offsetY;

                Canvas.SetLeft(rectangle, newX);
                Canvas.SetTop(rectangle, newY);

                XTextBox.Text = newX.ToString();
                YTextBox.Text = newY.ToString();

                clickPosition = currentPosition;
            }
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            rectangle.ReleaseMouseCapture();
        }

        private void XTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(XTextBox.Text, out double newX))
            {
                Canvas.SetLeft(rectangle, newX);
            }
        }

        private void YTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(YTextBox.Text, out double newY))
            {
                Canvas.SetTop(rectangle, newY);
            }
        }
    }

}
