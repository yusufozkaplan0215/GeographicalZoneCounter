using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yusuf_Ozkaplan
{
    public partial class Map : UserControl, MapInterface
    {
        private int width;
        private int height;
        private int[,] mapArray;
        private PictureBox[,] pbMapArray;

        public event Action OnSolvedEvent;
        public Map()
        {
            InitializeComponent();
            panel1.Paint += Panel1_Paint;
            Visible = false;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            using (Pen pen = new Pen(Color.Black, 1))
            {
                gr.DrawRectangle(pen, new Rectangle(panel1.Location.X, panel1.Location.Y,
                panel1.Size.Width-1, panel1.Size.Height-1));
            }
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            Graphics gr = e.Graphics;

            using (Pen pen = new Pen(Color.Black, 1))
            {
                gr.DrawRectangle(pen, new Rectangle(pb.Location.X, pb.Location.Y,
                pb.Size.Width - 1, pb.Size.Height - 1));
            }
        }

        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                return;
            }

            var position = (sender as PictureBox).Tag as Tuple<int, int>;
            SetBorder(position.Item1, position.Item2);
        }

        /// <summary>
        /// Haritanın genişlik ve yüksekliği setlemek için kullanılır.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize(in int width, in int height)
        {
            this.width = width;
            this.height = height;

            mapArray = new int[height, width];
            pbMapArray = new PictureBox[height, width];

            panel1.Size = new Size(width * 18, height * 18);
            pnlContent.Location = new Point(panel1.Location.X + panel1.Size.Width);

            Width = panel1.Size.Width + pnlContent.Size.Width;
            Height = height*18;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pbMapArray[i, j] = new PictureBox();
                    pbMapArray[i, j].Margin = new Padding(3);
                    pbMapArray[i, j].Size = new Size(15, 15);
                    pbMapArray[i, j].Location = new Point((j * 18) + 1, (i * 18) + 1);
                    pbMapArray[i, j].BackColor = Color.White;
                    pbMapArray[i, j].Tag = new Tuple<int, int>(i, j);
                    pbMapArray[i, j].MouseMove += Map_MouseMove;
                    pbMapArray[i, j].Paint += Map_Paint;
                    panel1.Controls.Add(pbMapArray[i, j]);
                }
            }
        }

        /// <summary>
        /// Haritanın genişlik ve yüksekliği out olarak setlemek için kullanılır.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void GetSize(out int width, out int height)
        {
            width = this.width;
            height = this.height;
        }


        /// <summary>
        /// Haritanın x ve y locasyonuna kenarlık bilgisi setlenir.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetBorder(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return;
            }

            mapArray[x, y] = 1;
            pbMapArray[x, y].BackColor = Color.Black;
            pbMapArray[x, y].BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Haritanın x ve y locasyonundan kenarlık bilgisi silinir.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void ClearBorder(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return;
            }

            mapArray[x, y] = 0;
            pbMapArray[x, y].BackColor = Color.White;
            pbMapArray[x, y].BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Haritanın x ve y locasyonunun kenarlık olup olmadığı bilgisidir
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public bool IsBorder(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return false;
            }

            return mapArray[x, y] == 1;
        }

        /// <summary>
        /// Haritanın gösterilir.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Show()
        {
            Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnSolvedEvent != null)
            {
                OnSolvedEvent();
            }
        }
    }
}
