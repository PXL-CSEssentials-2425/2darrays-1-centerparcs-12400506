using System.Diagnostics.Metrics;
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
using System.Windows.Threading;

namespace center
{
    public partial class MainWindow : Window
    {
        private readonly int[] _numberOfDays = new int[] { 1, 2, 5, 7, 8, 12, 14, 21 };
        private string[,] _houseWithPrice = new string[5, 2] 
        {
           { "2 personen", "80" },
           { "4 personen", "120" } ,
           { "4 personen lux", "140" } ,
           { "6 personen", "180" },
           { "8 personen", "200"}
        };
        int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            LoadComboBoxes();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            //timer.Interval = new TimeSpan(0, 0, 1);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            //counter++;
            //timeLabel.Content = counter.ToString(); // timer die op tikt
            timeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void LoadComboBoxes()
        {
            foreach (var day in _numberOfDays)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = day.ToString();
                daysBox.Items.Add(item);
            }

            for (int i = 0; i < _houseWithPrice.GetLength(0); i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content= _houseWithPrice[i,0];
                buildingBox.Items.Add(item);
            }
        }

        private void buildingBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (daysBox.SelectedIndex != -1 && buildingBox.SelectedIndex != -1)
            {
                int input = daysBox.SelectedIndex; // dagen index vragen en dan zoekt die da op
                int days = _numberOfDays[input];

                int input2 = buildingBox.SelectedIndex; // prijs opzoeken aan de hand van de index[rij]
                int price = int.Parse(_houseWithPrice[input2, 1]);

                int total = days * price;
                resultTextBox.Text = total.ToString();
            }
        }


    }


}