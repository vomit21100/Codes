using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace RoyalDeckMaker.Control
{
    internal class Cards
    {
        public string Type { get; set; }
        public string Rarity { get; set; }
        public string Name { get; set; }
        public int Elixir { get; set; }
        public bool Display {  get; set; }
        public string Image_Path { get; set; }
        public PictureBox PictureBox { get; set; }
        public Cards(string type, string rarity, string name, int elixir)
        {
            Type = type;
            Name = name;
            Rarity = rarity;
            Elixir = elixir;
            Display = true;
            PictureBox = new PictureBox 
            {
                Name = Name,
                Size = new Size(80, 100),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            PictureBox.MouseHover += Cards_PictureBoxs_MouseHover;
            PictureBox.MouseLeave += Cards_PictureBoxs_MouseLeave;
        }
        public Cards(string type, string rarity, string name, int elixir, string image_Path, PictureBox pictureBox)
        {
            Type = type;
            Name = name;
            Rarity = rarity;
            Elixir = elixir;
            Display = false;        //Default set to false to no show after copy
            Image_Path = image_Path;
            PictureBox = new PictureBox 
            {
                Name = Name,
                Size = pictureBox.Size,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = pictureBox.Image
            };
            PictureBox.MouseHover += Cards_PictureBoxs_MouseHover;
            PictureBox.MouseLeave += Cards_PictureBoxs_MouseLeave;
        }
        public Cards copy()
        {
            return new Cards(Type, Rarity, Name, Elixir, Image_Path, PictureBox);
        }
        public override string ToString()
        {
            return Type + " " + Rarity + " " + Name + " " + Elixir + " " + Display + " " + Image_Path;
        }
        private void Cards_PictureBoxs_MouseHover(object sender, EventArgs e)
        {
            PictureBox.BackColor = ColorTranslator.FromHtml("#B3B3B3");
        }
        private void Cards_PictureBoxs_MouseLeave(object sender, EventArgs e)
        {
            PictureBox.BackColor = Color.Transparent;
        }
        
    }
}
