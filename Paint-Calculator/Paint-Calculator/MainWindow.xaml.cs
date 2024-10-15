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

        private TextBox widthBox;
        private TextBox lengthBox;
        private TextBox heightBox;

        private Label widthLabel;
        private Label lengthLabel;
        private Label heightLabel;

        private Button calculateButton;
        private Label[] results;

        public MainWindow()
        {
            InitializeComponent();
            CreateCanvas();
            CreateBaseRoom();
            PlaceTextBoxes();
            PlaceLabels();
            PlaceButton();
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
            //baseRoom.ToggleCentreSquare(true);
        }

        private void PlaceTextBoxes()
        {
            widthBox = new TextBox();
            widthBox.Width = 100;
            widthBox.Height = 25;
            mainCanvas.Children.Add(widthBox);
            Canvas.SetTop(widthBox, 650);
            Canvas.SetLeft(widthBox, 420);

            lengthBox = new TextBox();
            lengthBox.Width = 100;
            lengthBox.Height = 25;
            mainCanvas.Children.Add(lengthBox);
            Canvas.SetTop(lengthBox, 450);
            Canvas.SetLeft(lengthBox, 200);

            heightBox = new TextBox();
            heightBox.Width = 100;
            heightBox.Height = 25;
            mainCanvas.Children.Add(heightBox);
            Canvas.SetTop(heightBox, 500);
            Canvas.SetLeft(heightBox, 420);
        }

        private void PlaceLabels()
        {
            widthLabel = new Label();
            widthLabel.Content = "Width: ";
            mainCanvas.Children.Add(widthLabel);
            Canvas.SetTop(widthLabel, 650);
            Canvas.SetLeft(widthLabel, 370);

            lengthLabel = new Label();
            lengthLabel.Content = "Length: ";
            mainCanvas.Children.Add(lengthLabel);
            Canvas.SetTop(lengthLabel, 450);
            Canvas.SetLeft(lengthLabel, 150);

            heightLabel = new Label();
            heightLabel.Content = "Height: ";
            mainCanvas.Children.Add(heightLabel);
            Canvas.SetTop(heightLabel, 500);
            Canvas.SetLeft(heightLabel, 370);
        }

        private void PlaceButton()
        {
            calculateButton = new Button();
            calculateButton.Content = "Calculate!";
            calculateButton.Width = 100;
            calculateButton.Height = 25;
            calculateButton.Click += CalculateResults;
            mainCanvas.Children.Add(calculateButton);
            Canvas.SetTop(calculateButton, 700);
            Canvas.SetLeft(calculateButton, 420);
        }

        private void CalculateResults(object sender, RoutedEventArgs e)
        {
            if (UpdateRoomData() == false)
            {
                ResetResults();
                return;
            }

            int yPos = 750;
            results = new Label[3];
            for (int i = 0; i < 3; i++, yPos+=20)
            {
                results[i] = new Label();
                mainCanvas.Children.Add(results[i]);
                Canvas.SetTop(results[i], yPos);
                Canvas.SetLeft(results[i], 420);
            }

            string area = "Floor Area = " + baseRoom.Area.ToString() + " metres squared";
            string volume = "Volume of Room = " + baseRoom.Volume.ToString() + " metres squared";
            string paint = "Litres of Paint = " + baseRoom.GetPaintRequirement().ToString();

            results[0].Content = area;
            results[1].Content = volume;
            results[2].Content = paint;
        }

        private bool UpdateRoomData()
        {
            try
            {
                double newWidth = Double.Parse(widthBox.Text);
                double newLength = Double.Parse(lengthBox.Text);
                double newHeight = Double.Parse(heightBox.Text);

                if (newWidth < 0 || newLength < 0 || newHeight < 0)
                {
                    return false;
                }

                baseRoom.SetDimensions(newWidth, newLength, newHeight);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void ResetResults()
        {
            widthBox.Clear();
            lengthBox.Clear();
            heightBox.Clear();

            if (results[0] != null)
            {
                results[0].Content = "";
                results[1].Content = "";
                results[2].Content = "";
            }
        }
    }
}