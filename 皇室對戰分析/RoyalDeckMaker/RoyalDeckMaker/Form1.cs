using System.Runtime.InteropServices;
using RoyalDeckMaker.Properties;
using RoyalDeckMaker.Control;
using System.Drawing.Drawing2D;
using RoyalDeckMaker.Control.Custom.Extension;
using System.Drawing;
using Bunifu.Utils;

namespace RoyalDeckMaker
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            //Initialize not control(view) variables
            Cards = Get_Cards_Image();
            Selections = new List<Cards>();
            Excludes = new List<Cards>();
            Evolution = 0;
            Champion = 0;

            //Initialize Selections_PictureBoxs and Excludes_PictureBoxs
            /*
            Excludes_PictureBoxs = new List<PictureBox>();
            Selections_PictureBoxs = new PictureBox[8];
            for (int i = 0; i < 8; i++)
            {
                int x = i * 86 + 35;
                int y = 5;

                Selections_PictureBoxs[i] = new PictureBox
                {
                    Parent = Selection_Panel,
                    BackColor = Color.Transparent,
                    Size = new Size(80, 100),
                    Location = new Point(x, y),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(Cards[i].Image_Path)
                };
            }*/

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

            AllocConsole();
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

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

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
    }
}