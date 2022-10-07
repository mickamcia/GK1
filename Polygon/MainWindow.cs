namespace Polygon
{
    public partial class MainWindow : Form
    {
        private readonly Bitmap bits;
        private List<LinkedList<Vertex>> polygons;
        private LinkedList<Vertex> currentPolygon;
        private bool polygonSelectedMode;

        public MainWindow()
        {
            InitializeComponent();
            bits = new Bitmap(800, 800);
            polygons = new List<LinkedList<Vertex>>();
            currentPolygon = new LinkedList<Vertex>();
            polygonSelectedMode = false;
        }

        private void BitMap_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                return;
            }
            else
            {
                if(polygonSelectedMode == false)
                {
                    polygonSelectedMode = true;
                    currentPolygon = new LinkedList<Vertex>();
                    polygons.Add(currentPolygon);
                }
                currentPolygon.AddLast(new Vertex(e.Location));
            }
        }

        private void BitMap_Paint(object sender, PaintEventArgs e)
        {
            foreach(var x in polygons)
            {
                foreach(var y in x)
                {
                }
            }
        }
    }
}