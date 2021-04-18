using Cars_MVVM.ViewModel;
using System.Windows;

namespace Cars_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new CarViewModel();
        }
    }
}
