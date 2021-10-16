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
    public partial class MapForm : Form
    {        
        Map map;

        public MapForm()
        {
            InitializeComponent();
            map = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblResultValue.Text = "---";

            foreach (Control item in Controls)
            {
                if (item.GetType() == typeof(Map))
                {
                    Controls.Remove(item);
                    break;
                }
            }
             
            int width;
            int height;

            int.TryParse(textBox1.Text, out width);
            int.TryParse(textBox2.Text, out height);

            map = new Map();
            map.SetSize(width, height);
            map.Location = new Point(panel1.Location.X + panel1.Size.Width + 50, panel1.Location.Y);

            var size = new Size(map.Location.X + map.Size.Width, map.Location.Y + map.Size.Height);

            if (Size.Width < size.Width || Size.Height < size.Height)
            {
                Size = new Size(size.Width, size.Height);
            }

            map.Show();
            Controls.Add(map);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZoneCounter zoneCounter = new ZoneCounter();
            zoneCounter.Init(map);
            var zone = zoneCounter.Solve();
            lblResultValue.Text = zone.ToString();

            lblLabelMap.Text = zoneCounter.GetLabelMap();
            Size = new Size(Size.Width + lblLabelMap.Size.Width + 50, Size.Height);
            lblLabelMap.Location = new Point(map.Location.X + map.Size.Width, map.Location.Y);
        }
    }
}
