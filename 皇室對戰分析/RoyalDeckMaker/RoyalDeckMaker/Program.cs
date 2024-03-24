using System.Collections;
using System.IO;
using RoyalDeckMaker.Control;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RoyalDeckMaker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    partial class Form1
    {
        private List<Cards> Get_Cards_Image()
        {
            string[] BaseFilePaths = Directory.GetFiles("data/Cards/Cards Image");
            List<Cards> cards;
            int i = 0;

            using (var reader = new StreamReader("data/Cards/cards.csv"))
            {
                string headerLine = reader.ReadLine();      //First line of csv, need skip
                cards = new List<Cards>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    cards.Add(new Cards(values[0], values[1], values[2], int.Parse(values[3])));
                }
            }
            while(i < cards.Count)
            {
                String Image_Path = "data/Cards/Cards Image/" + cards[i].Name + ".png";

                if(File.Exists(Image_Path))
                {
                    cards[i].Image_Path = Image_Path;
                    cards[i].PictureBox.Image = Image.FromFile(Image_Path);
                    i++;
                }
                else
                {
                    cards.Remove(cards[i]);
                }
            }

            return cards;
        }
        private void Set_Cards_Image_Pos(System.Windows.Forms.Control parent, List<Cards> cards, int start_x, int start_y, int interval_x, int interval_y)
        {
            if (cards == null) 
                return;

            int i = 0;

            foreach(var card in cards) 
            {
                if (card.Selected) 
                {
                    card.PictureBox.Visible = false;
                    continue;
                }

                int x = start_x + (i % 9) * interval_x;
                int y = start_y + (i / 9) * interval_y;

                card.PictureBox.Parent = parent;
                card.PictureBox.Location = new Point(x, y);
                card.PictureBox.Visible = true;

                i++;
            }
        }
    }
}