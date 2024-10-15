using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using static Paint_Calculator.RoomData;

namespace Paint_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int padding = 80;

        private Canvas mainCanvas;
        private Square baseRoom;
        public MainWindow()
        {
            InitializeComponent();
            CreateCanvas();
            CreateBaseRoom();
        }

        private void CreateCanvas()
        {
            mainCanvas = new Canvas();
            Content = mainCanvas; //Sets the main content of the window to equal the canvas

            //Canvas Settings
            mainCanvas.Background = Brushes.Gray;
            mainCanvas.Width = Width - padding;
            mainCanvas.Height = Height - padding;
        }

        /// <summary>
        /// Displays the starter room using Labels and RoomData
        /// </summary>
        private void CreateBaseRoom()
        {
            baseRoom = new Square(10, 10, 10);
            baseRoom.Canvas = mainCanvas;
            baseRoom.ToggleCentreSquare(true);
        }
    }
}