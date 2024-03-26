using RoyalDeckMaker.Control.Custom.Extension;
using Bunifu.Utils;
using RoyalDeckMaker.Control;

namespace RoyalDeckMaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            border = new Panel();
            miniButton = new Button();
            exitButton = new Button();
            Edit1 = new Button();
            label2 = new Label();
            Edit2 = new Button();
            BasePanel = new Panel();
            panel1 = new Panel();
            Evolution_textBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            Champion_textBox_panel = new Panel();
            Champion_textBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            Exclude_Panel = new SPanel_Grey();
            Exclude_left_button = new Button();
            Exclude_right_button = new Button();
            Selection_Panel = new SPanel_Grey();
            border.SuspendLayout();
            BasePanel.SuspendLayout();
            panel1.SuspendLayout();
            Champion_textBox_panel.SuspendLayout();
            Exclude_Panel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(57, 61, 66);
            label1.Font = new Font("微软雅黑", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(51, 33);
            label1.Name = "label1";
            label1.Size = new Size(92, 27);
            label1.TabIndex = 0;
            label1.Text = "指定卡牌";
            // 
            // border
            // 
            border.BackColor = Color.Black;
            border.Controls.Add(miniButton);
            border.Controls.Add(exitButton);
            border.Dock = DockStyle.Top;
            border.Location = new Point(0, 0);
            border.Name = "border";
            border.Size = new Size(940, 30);
            border.TabIndex = 1;
            border.MouseDown += panel1_MouseDown;
            // 
            // miniButton
            // 
            miniButton.BackgroundImage = Properties.Resources.Minus;
            miniButton.BackgroundImageLayout = ImageLayout.Zoom;
            miniButton.Dock = DockStyle.Right;
            miniButton.FlatAppearance.BorderSize = 0;
            miniButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            miniButton.FlatStyle = FlatStyle.Flat;
            miniButton.Location = new Point(870, 0);
            miniButton.Name = "miniButton";
            miniButton.Size = new Size(35, 30);
            miniButton.TabIndex = 4;
            miniButton.UseVisualStyleBackColor = true;
            miniButton.Click += miniButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackgroundImage = Properties.Resources.Close;
            exitButton.BackgroundImageLayout = ImageLayout.Zoom;
            exitButton.Dock = DockStyle.Right;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            exitButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Location = new Point(905, 0);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(35, 30);
            exitButton.TabIndex = 2;
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // Edit1
            // 
            Edit1.BackColor = Color.FromArgb(254, 130, 6);
            Edit1.FlatAppearance.BorderSize = 0;
            Edit1.FlatStyle = FlatStyle.Flat;
            Edit1.Font = new Font("Microsoft JhengHei UI", 12F);
            Edit1.Location = new Point(818, 33);
            Edit1.Name = "Edit1";
            Edit1.Size = new Size(71, 27);
            Edit1.TabIndex = 2;
            Edit1.Text = "Edit";
            Edit1.UseVisualStyleBackColor = false;
            Edit1.Click += Edit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(57, 61, 66);
            label2.Font = new Font("微软雅黑", 15F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(51, 375);
            label2.Name = "label2";
            label2.Size = new Size(92, 27);
            label2.TabIndex = 5;
            label2.Text = "指定卡牌";
            // 
            // Edit2
            // 
            Edit2.BackColor = Color.FromArgb(254, 130, 6);
            Edit2.FlatAppearance.BorderSize = 0;
            Edit2.FlatStyle = FlatStyle.Flat;
            Edit2.Font = new Font("Microsoft JhengHei UI", 12F);
            Edit2.Location = new Point(818, 375);
            Edit2.Name = "Edit2";
            Edit2.Size = new Size(71, 27);
            Edit2.TabIndex = 6;
            Edit2.Text = "Edit";
            Edit2.UseVisualStyleBackColor = false;
            Edit2.Click += Edit_Click;
            // 
            // BasePanel
            // 
            BasePanel.BackColor = Color.FromArgb(57, 61, 66);
            BasePanel.Controls.Add(panel1);
            BasePanel.Controls.Add(label5);
            BasePanel.Controls.Add(label6);
            BasePanel.Controls.Add(Champion_textBox_panel);
            BasePanel.Controls.Add(label4);
            BasePanel.Controls.Add(label3);
            BasePanel.Controls.Add(Edit1);
            BasePanel.Controls.Add(Edit2);
            BasePanel.Controls.Add(Exclude_Panel);
            BasePanel.Controls.Add(label2);
            BasePanel.Controls.Add(Selection_Panel);
            BasePanel.Controls.Add(label1);
            BasePanel.Location = new Point(0, 26);
            BasePanel.Name = "BasePanel";
            BasePanel.Size = new Size(940, 640);
            BasePanel.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(Evolution_textBox);
            panel1.Location = new Point(152, 284);
            panel1.Name = "panel1";
            panel1.Size = new Size(42, 28);
            panel1.TabIndex = 13;
            panel1.Paint += Text_Panel_Paint;
            // 
            // Evolution_textBox
            // 
            Evolution_textBox.BackColor = Color.FromArgb(57, 61, 66);
            Evolution_textBox.BorderStyle = BorderStyle.None;
            Evolution_textBox.Font = new Font("Microsoft JhengHei UI", 13F);
            Evolution_textBox.ForeColor = Color.WhiteSmoke;
            Evolution_textBox.Location = new Point(0, 2);
            Evolution_textBox.Name = "Evolution_textBox";
            Evolution_textBox.Size = new Size(42, 23);
            Evolution_textBox.TabIndex = 7;
            Evolution_textBox.Text = "0";
            Evolution_textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Microsoft JhengHei UI", 13F);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(192, 286);
            label5.Name = "label5";
            label5.Size = new Size(28, 23);
            label5.TabIndex = 12;
            label5.Text = "張";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Microsoft JhengHei UI", 13F);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(51, 286);
            label6.Name = "label6";
            label6.Size = new Size(104, 23);
            label6.TabIndex = 11;
            label6.Text = "進化卡數量:";
            // 
            // Champion_textBox_panel
            // 
            Champion_textBox_panel.BackColor = Color.Transparent;
            Champion_textBox_panel.Controls.Add(Champion_textBox);
            Champion_textBox_panel.Location = new Point(152, 222);
            Champion_textBox_panel.Name = "Champion_textBox_panel";
            Champion_textBox_panel.Size = new Size(42, 28);
            Champion_textBox_panel.TabIndex = 10;
            Champion_textBox_panel.Paint += Text_Panel_Paint;
            // 
            // Champion_textBox
            // 
            Champion_textBox.BackColor = Color.FromArgb(57, 61, 66);
            Champion_textBox.BorderStyle = BorderStyle.None;
            Champion_textBox.Font = new Font("Microsoft JhengHei UI", 13F);
            Champion_textBox.ForeColor = Color.WhiteSmoke;
            Champion_textBox.Location = new Point(0, 2);
            Champion_textBox.Name = "Champion_textBox";
            Champion_textBox.Size = new Size(42, 23);
            Champion_textBox.TabIndex = 7;
            Champion_textBox.Text = "0";
            Champion_textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft JhengHei UI", 13F);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(192, 224);
            label4.Name = "label4";
            label4.Size = new Size(28, 23);
            label4.TabIndex = 9;
            label4.Text = "張";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft JhengHei UI", 13F);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(51, 224);
            label3.Name = "label3";
            label3.Size = new Size(104, 23);
            label3.TabIndex = 8;
            label3.Text = "英雄卡數量:";
            // 
            // Exclude_Panel
            // 
            Exclude_Panel.BackColor = Color.FromArgb(255, 179, 102);
            Exclude_Panel.Controls.Add(Exclude_left_button);
            Exclude_Panel.Controls.Add(Exclude_right_button);
            Exclude_Panel.Location = new Point(51, 430);
            Exclude_Panel.Margin = new Padding(0);
            Exclude_Panel.Name = "Exclude_Panel";
            Exclude_Panel.Size = new Size(838, 110);
            Exclude_Panel.TabIndex = 1;
            // 
            // Exclude_left_button
            // 
            Exclude_left_button.BackColor = Color.Transparent;
            Exclude_left_button.FlatAppearance.BorderSize = 0;
            Exclude_left_button.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 217, 179);
            Exclude_left_button.FlatStyle = FlatStyle.Flat;
            Exclude_left_button.Image = Properties.Resources.Back;
            Exclude_left_button.Location = new Point(0, 25);
            Exclude_left_button.Name = "Exclude_left_button";
            Exclude_left_button.Size = new Size(30, 64);
            Exclude_left_button.TabIndex = 15;
            Exclude_left_button.UseVisualStyleBackColor = false;
            Exclude_left_button.Click += Exclude_left_button_Click;
            // 
            // Exclude_right_button
            // 
            Exclude_right_button.BackColor = Color.Transparent;
            Exclude_right_button.FlatAppearance.BorderSize = 0;
            Exclude_right_button.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 217, 179);
            Exclude_right_button.FlatStyle = FlatStyle.Flat;
            Exclude_right_button.Image = Properties.Resources.Forward;
            Exclude_right_button.Location = new Point(805, 25);
            Exclude_right_button.Name = "Exclude_right_button";
            Exclude_right_button.Size = new Size(30, 64);
            Exclude_right_button.TabIndex = 14;
            Exclude_right_button.UseVisualStyleBackColor = false;
            Exclude_right_button.Click += Exclude_right_button_Click;
            // 
            // Selection_Panel
            // 
            Selection_Panel.BackColor = Color.FromArgb(255, 179, 102);
            Selection_Panel.Location = new Point(51, 81);
            Selection_Panel.Margin = new Padding(0);
            Selection_Panel.Name = "Selection_Panel";
            Selection_Panel.Size = new Size(838, 110);
            Selection_Panel.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(102, 255, 102);
            BackgroundImage = Properties.Resources.FormBackgroundImage;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(940, 980);
            Controls.Add(border);
            Controls.Add(BasePanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            TransparencyKey = Color.FromArgb(102, 255, 102);
            border.ResumeLayout(false);
            BasePanel.ResumeLayout(false);
            BasePanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            Champion_textBox_panel.ResumeLayout(false);
            Champion_textBox_panel.PerformLayout();
            Exclude_Panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel All_cards;
        private List<Cards> Cards;
        private List<Cards> Selections;
        private int Select_count = 0;
        private List<Cards> Excludes;
        private int Exclude_count = 0;
        private int Exclude_display_index = 0;
        private int Evolution;
        private int Champion;

        private Panel border;
        private Button exitButton;
        private Button miniButton;
        private Label label1;
        private Label label2;
        private Button Edit1;
        private Button Edit2;
        private Panel BasePanel;
        private SPanel_Grey Selection_Panel;
        private SPanel_Grey Exclude_Panel;
        private Label label3;
        private TextBox Champion_textBox;
        private Label label4;
        private Panel Champion_textBox_panel;
        private TextBox Evolution_textBox;
        private Panel panel1;
        private Label label5;
        private Label label6;
        private Button Exclude_right_button;
        private Button Exclude_left_button;
    }
}
