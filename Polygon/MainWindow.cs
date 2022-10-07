namespace Polygon
{
    public partial class MainWindow : Form
    {
        private readonly Bitmap bits;
        public MainWindow()
        {
            InitializeComponent();
            bits = new Bitmap(800, 800);

        }
    }
}