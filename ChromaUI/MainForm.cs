using System.Drawing;
using System.Windows.Forms;
using ChromaUI.Overwatch;

namespace ChromaUI
{
    public partial class MainForm : Form
    {
        private Bitmap _buttonBitmap;

        public MainForm()
        {
            InitializeComponent();
            _buttonBitmap = new Bitmap(1,1);
        }

        public void UpdateCurrentChampion(Champion champ)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) delegate { UpdateCurrentChampion(champ); });
                return;
            }
            ChampionNameBox.Text = champ.ToString();
        }

        public void UpdateKeyboardColors(Color[,] colors)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) delegate { UpdateKeyboardColors(colors); });
                return;
            };

            const int keySize = 35;
            const int padding = 2;

            _buttonBitmap = new Bitmap((keySize + padding)*colors.GetLength(1), 
                (keySize + padding)*colors.GetLength(0));
            var buttonGraphics = Graphics.FromImage(_buttonBitmap);

            for (var x = 0; x < colors.GetLength(0); x++)
            {
                for (var y = 0; y < colors.GetLength(1); y++)
                {
                    var newBrush = new SolidBrush(colors[x, y]);
                    buttonGraphics.FillRectangle(newBrush, y * (keySize + padding), 
                        x * (keySize + padding), keySize, keySize);
                }
            }
            pictureBox1.Image = _buttonBitmap;
        }
    }
}
