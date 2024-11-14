using Microsoft.EntityFrameworkCore;
using MusicCatalogue_P.Services;
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

namespace MusicCatalogue_P
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MusicDbContext _context;

        // Конструктор
        public MainWindow(MusicDbContext context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}