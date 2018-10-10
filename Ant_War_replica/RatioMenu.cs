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
    public partial class RatioMenu : Form
    {
        private GameState state = null;
        private Button[,] change_ratio_buttons = new Button[4,4];
        private Label[] ratio_labels = new Label[5];
        private List<Label> static_label_list = new List<Label>();
        private EventHandler[,] change_ratio_event = new EventHandler[4,4];
        private Label[] num_labels = new Label[4];

        public RatioMenu(ref GameState instate)
        {
            this.state = instate;

            InitializeComponent();
            CreateRatioTable(10, 10);
            foreach (Button item in change_ratio_buttons)
            {
                this.Controls.Add(item);
            }
            foreach (Label item in ratio_labels)
            {
                this.Controls.Add(item);
            }
            foreach (Label item in static_label_list)
            {
                this.Controls.Add(item);
            }
            foreach (Label item in num_labels)
            {
                this.Controls.Add(item);
            }

        }
        private void CreateRatioTable(int to_right, int origin_to_down)
        {
            int horizon_space = 30;
            int vertical_space = 75;
            String[] names = { "gatherer", "breeder", "builder", "solder" };
            String[] labels = { "-10", "-5", "+5", "+10" };
            int[] change_rate = { -10, -5, 5, 10 };
            for (int i = 0; i<4; ++i)
            {
                String name = names[i];
                int to_down = origin_to_down + horizon_space * i;
                Label line_label = new Label();
                line_label.Location = new System.Drawing.Point(to_right, to_down);
                line_label.Text = name;
                static_label_list.Add(line_label);

                Label value = new Label();
                value.Location = new System.Drawing.Point(to_right + 100, to_down);
                value.Text = state.ratio[i].ToString();
                ratio_labels[i] = (value);


                for (int j = 0; j < 4; ++j)
                {
                    Button button = new Button();
                    button.Location = new System.Drawing.Point(to_right + 200 + vertical_space * j, to_down);
                    button.Name = i.ToString() + "_" + labels[j];
                    button.Size = new System.Drawing.Size(50, 25);
                    button.Text = labels[j];

                    button.Click += delegate(object o, EventArgs e) { Change_Ratio(o, e, button.Name); };
                    button.Click += Change_Ratio_Click;
                    button.UseVisualStyleBackColor = true;
                    change_ratio_buttons[i,j] = (button);
                }

                

            }
            Label remain = new Label();
            remain.Location = new System.Drawing.Point(to_right + 100, origin_to_down + 4 * horizon_space);
            remain.Text = (100 - state.ratio.Sum()).ToString();
            remain.ForeColor = Color.Green;
            ratio_labels[4] = (remain);

            Label food = new Label();
            food.Location = new System.Drawing.Point(to_right + 200 + vertical_space * 4, origin_to_down);
            food.Text = state.num_food.ToString();
            num_labels[0] = food;

            Label ant = new Label();
            ant.Location = new System.Drawing.Point(to_right + 200 + 75 * 4, origin_to_down + horizon_space);
            ant.Text = state.num_ant.ToString();
            num_labels[1] = ant;

            Label nest = new Label();
            nest.Location = new System.Drawing.Point(to_right + 200 + 75 * 4, origin_to_down + 2 * horizon_space);
            nest.Text = state.num_nest.ToString();
            num_labels[2] = nest;

            Label strength = new Label();
            strength.Location = new System.Drawing.Point(to_right + 200 + 75 * 4, origin_to_down + 3 * horizon_space);
            strength.Text = (state.num_ant * 3 + state.num_nest).ToString();
            num_labels[3] = strength;
        }

        private void Change_Ratio(object o, EventArgs e, String button_name)
        {
            String[] component = button_name.Split('_');
            int type;
            int.TryParse(component[0], out type);
            int num;
            int.TryParse(component[1], out num);
            state.ratio[type] += num;
        }

        private void Change_Ratio_Click(object o, EventArgs e)
        {
            for (int i = 0; i < ratio_labels.Length-1; ++i)
            {
                ratio_labels[i].Text = state.ratio[i].ToString();
            }
            ratio_labels[4].Text = (100 - state.ratio.Sum()).ToString();
            if (100 - state.ratio.Sum() < 0) {
                ratio_labels[4].ForeColor = Color.Red;
            }
            else if (100 - state.ratio.Sum() > 0)
            {
                ratio_labels[4].ForeColor = Color.Black;
            }
            else
            {
                ratio_labels[4].ForeColor = Color.Green;
            }


        }

        private void update_num_label()
        {
            num_labels[0].Text = state.num_food.ToString();
            num_labels[1].Text = state.num_ant.ToString();
            num_labels[2].Text = state.num_nest.ToString();
            num_labels[3].Text = (state.num_ant * 3 + state.num_nest).ToString();
        }
        
        private void next_button_Click(object sender, EventArgs e)
        {
            if (100 - state.ratio.Sum() == 0)
            {
                state.next_state();
                update_num_label();
            }
            else
            {
                Color temp = ratio_labels[4].BackColor;
                for (int i =0; i<100; ++i)
                {
                    Task.Delay(5000);
                    ratio_labels[4].BackColor = ratio_labels[4].BackColor == Color.Red ? Color.Green : Color.Red;
                }
                ratio_labels[4].BackColor = temp;
            }
        }

        private void LocationButton_Click(object sender, EventArgs e)
        {
            LocationSelection location_form = new LocationSelection(ref this.state);
            location_form.Show();
        }
    }
}
