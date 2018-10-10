using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ant_War_replica
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            GameState state = new GameState();
            RatioMenu ratio_screen = new RatioMenu(ref state);// (ref state);
            ratio_screen.Show();
            //this.Close();
        }

        private void button_load_Click(object sender, EventArgs e)
        {

        }
    }
}
