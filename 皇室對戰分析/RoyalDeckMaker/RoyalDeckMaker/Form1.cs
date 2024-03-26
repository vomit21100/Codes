using System.Runtime.InteropServices;
using RoyalDeckMaker.Properties;
using RoyalDeckMaker.Control;
using System.Drawing.Drawing2D;
using RoyalDeckMaker.Control.Custom.Extension;
using System.Drawing;
using Bunifu.Utils;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace RoyalDeckMaker
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            //Initialize not control(view) variables
            Cards = Get_Cards_Image();
            Selections = new List<Cards>();
            Excludes = new List<Cards>();
            Evolution = 0;
            Champion = 0;
            Update_Exclude_Arrow_Status();

            for (int i = 0; i < Cards.Count; i++)
            {
                Selections.Add(Cards[i].copy());
                Excludes.Add(Cards[i].copy());

                Cards[i].PictureBox.MouseClick += Cards_PictureBoxs_Click;
                Selections[i].PictureBox.MouseClick += Selections_PictureBoxs_Click;
                Excludes[i].PictureBox.MouseClick += Excludes_PictureBoxs_Click;
            }

            //Initialize All_cards Panel
            All_cards = new Panel
            {
                Parent = this,
                BackColor = ColorTranslator.FromHtml("#FFE6CC"),
                Size = new Size(Selection_Panel.Width, 350),
                AutoScroll = true,
                Visible = false
            };

            //Initialize all cards picture box
            Set_Cards_Image_Pos(All_cards, Cards, 35, 20, 86, 116);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            CustomBorder.ReleaseCapture();
            CustomBorder.SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miniButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Button Caller = (Button)sender;

            if (Caller.Text == "Edit" & All_cards.Visible == false)
            {
                Point pos;

                Caller.Text = "Done";
                Caller.BackColor = ColorTranslator.FromHtml("#66B2FF");
                if (Caller.Name == "Edit1")
                {
                    pos = Point.Add(Selection_Panel.Location, new Size(0, Selection_Panel.Height + border.Height));
                }
                else
                {
                    pos = Point.Add(Exclude_Panel.Location, new Size(0, Exclude_Panel.Height + border.Height));
                }
                All_cards.Location = pos;
                All_cards.Visible = true;
                All_cards.BringToFront();
            }
            else if (Caller.Text == "Done")
            {
                Caller.Text = "Edit";
                Caller.BackColor = ColorTranslator.FromHtml("#FE8206");

                All_cards.Visible = false;
            }
        }

        private void Text_Panel_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            Panel caller = (Panel)sender;
            using (Pen pen = new Pen(Color.WhiteSmoke, 3))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawLine(pen, 0, caller.Height, caller.Width, caller.Height);
            }
        }
        private void Cards_PictureBoxs_Click(object sender, EventArgs e)
        {
            PictureBox Caller_Picture = (PictureBox)sender;
            int pos = Cards.FindIndex(x => x.Name == Caller_Picture.Name);

            if (All_cards.Top - Exclude_Panel.Top < 0 && Select_count <= 8)
            {
                Select_count++;
                Selections[pos].Display = true;
                Set_Cards_Image_Pos(Selection_Panel, Selections, 35, 5, 86, 0);

                Cards[pos].Display = false;
                Set_Cards_Image_Pos(All_cards, Cards, 35, 20, 86, 116);
            }
            else if (All_cards.Top - Exclude_Panel.Top > 0)
            {
                Exclude_count++;
                Excludes[pos].Display = true;
                Set_Cards_Image_Pos(Exclude_Panel, Excludes, 35, 5, 86, 116, Exclude_display_index);

                Cards[pos].Display = false;
                Set_Cards_Image_Pos(All_cards, Cards, 35, 20, 86, 116);

                Update_Exclude_Arrow_Status();
            }
        }

        private void Selections_PictureBoxs_Click(object sender, EventArgs e)
        {
            PictureBox Caller_Picture = (PictureBox)sender;
            int pos = Cards.FindIndex(x => x.Name == Caller_Picture.Name);

            Selections[pos].Display = false;
            Set_Cards_Image_Pos(Selection_Panel, Selections, 35, 5, 86, 0);

            Cards[pos].Display = true;
            Set_Cards_Image_Pos(All_cards, Cards, 35, 20, 86, 116);

            Select_count--;
        }

        private void Excludes_PictureBoxs_Click(object sender, EventArgs e)
        {
            PictureBox Caller_Picture = (PictureBox)sender;
            int pos = Cards.FindIndex(x => x.Name == Caller_Picture.Name);

            Excludes[pos].Display = false;
            Set_Cards_Image_Pos(Exclude_Panel, Excludes, 35, 5, 86, 116, Exclude_display_index);

            Cards[pos].Display = true;
            Set_Cards_Image_Pos(All_cards, Cards, 35, 20, 86, 116);

            Exclude_count--;

            Update_Exclude_Arrow_Status();
        }

        private void Update_Exclude_Arrow_Status()
        {
            if (Exclude_display_index == 0)
            {
                Exclude_left_button.Visible = false;
            }
            else
            {
                Exclude_left_button.Visible = true;
            }

            if (Exclude_display_index + 9 < Exclude_count && Exclude_count > 9)
            {
                Exclude_right_button.Visible = true;
            }
            else
            {
                Exclude_right_button.Visible = false;
            }
        }

        private void Exclude_right_button_Click(object sender, EventArgs e)
        {
            Exclude_display_index += 9;
            Update_Exclude_Arrow_Status();
            Set_Cards_Image_Pos(Exclude_Panel, Excludes, 35, 5, 86, 116, Exclude_display_index);
        }

        private void Exclude_left_button_Click(object sender, EventArgs e)
        {
            Exclude_display_index -= 9;
            Update_Exclude_Arrow_Status();
            Set_Cards_Image_Pos(Exclude_Panel, Excludes, 35, 5, 86, 116, Exclude_display_index);
        }
    }
}