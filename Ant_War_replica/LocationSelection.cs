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
    public partial class LocationSelection : Form
    {
        private RadioButton[] radio_list;
        private Label[] location_name_list;

        public LocationSelection(ref GameState instate)
        {
            InitializeComponent();

            int[] indices = { 0, 1, 2 };
            CreateLocationRadio(indices, 10, 10);

            Button ok_button = new Button();
            ok_button.Location = new Point(50, 500);
            ok_button.Text = "OK";
            ok_button.Size = new Size(100, 25);
            this.Controls.Add(ok_button);

            Button cancel_button = new Button();
            cancel_button.Location = new Point(100, 500);
            cancel_button.Text = "Cancel";
            cancel_button.Size = new Size(100, 25);
            cancel_button.Click += CancelClick;
            this.Controls.Add(cancel_button);
        }

        private void CreateLocationRadio(int[] index_list, int to_right, int to_down)
        {
            for (int i=0; i<index_list.Length; ++i)
            {
                RadioButton rb = new RadioButton();
                rb.Location = new Point(40, 50 + 40 * i);
                rb.Size = new Size(30, 30);
                this.Controls.Add(rb);

                Label rl = new Label();
                rl.Location = new Point(80, 50 + 40 * i);
                rl.Text = Ant_War_replica.Location.LocationName[i];
                this.Controls.Add(rl);
            }
        }

        private void CancelClick(object o, EventArgs e)
        {
            this.Close();
        }
    }
}
