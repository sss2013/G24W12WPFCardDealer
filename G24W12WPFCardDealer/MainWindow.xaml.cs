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

namespace G24W12WPFCardDealer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnDeal(object sender, RoutedEventArgs e)
        {
          
            HashSet<int> set = new HashSet<int>();
            string[] suits = [ "spades", "diamonds", "hearts", "clubs", ];
            string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king",];
            Random random = new Random();
            while (set.Count != 5)
            {
                int card = random.Next(suits.Length * values.Length);
                
                set.Add(card);
            }


            List<int> list = set.ToList();
            list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                string suit = suits[list[i] / values.Length];
                string value = values[list[i] % values.Length];
                if (value == "jack" || value == "queen" || value == "king")
                    suit += "2";
                BitmapImage image = new BitmapImage(
                new Uri(
                   $"Images/{value}_of_{suit}.png",
                   UriKind.RelativeOrAbsolute)
                );
                Image imageCard = (Image)FindName($"Card{i + 1}");
                imageCard.Source = image;
            }
           
            
        }
    }
}