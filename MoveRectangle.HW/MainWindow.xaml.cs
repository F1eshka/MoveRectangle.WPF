using System.Windows;
using System.Windows.Input;

namespace MoveRectangle.HW
{
    public partial class MainWindow : Window
    {
        private bool isDragging = false;
        private Point clickPosition;
        public RectangleViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new RectangleViewModel { X = 280, Y = 150 };
            DataContext = ViewModel;
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

                ViewModel.X += offsetX;
                ViewModel.Y += offsetY;

                clickPosition = currentPosition;
            }
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            rectangle.ReleaseMouseCapture();
        }
    }
}
