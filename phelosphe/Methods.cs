using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phelosphe
{
    public static class Methods
    {
        public static void PaintPanel(this Panel panel, string hexCode)
        {
            panel.BackColor = ColorTranslator.FromHtml(hexCode);
        }
        public static void GiveLocationToPanel(this Panel panel, Form1 form)
        {
            panel.Height = form.Height;
            panel.Location = new Point(1620, 0);
            panel.Width = 300;
        }
        public static void CreateMoneyLabels(this Panel sidePanel)
        {
            List<Label> labels = new List<Label>();
            string[] moneyArray = new string[] { "1000", "2000", "5000", "10000", "20000", "50000", "100000", "250000", "500000", "1000000" };
            int LblHeight = 980;
            for (byte i = 0; i < 10; i++)
            {
                Label lbl = new Label()
                {
                    Name = "MoneyLabel" + i.ToString(),
                    ForeColor = ColorTranslator.FromHtml("#fff"),
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.None,
                    Location = new Point(45, LblHeight),
                    Text = moneyArray[i],
                    TabIndex = 1,
                    Font = new Font("segoe ui", 20, FontStyle.Bold),
                    Height = 50,
                    Width = 200,
                    TextAlign = ContentAlignment.TopCenter,
                    Parent = sidePanel,
                };
                lbl.BringToFront();
                sidePanel.Controls.Add(lbl);
                sidePanel.Controls.SetChildIndex(lbl, 600);
                LblHeight -= 105;
            }
        }
        public static void CreateAPanel(this Panel panel, Form1 form, int x, int y, int width, int height)
        {
            panel.Height = height;
            panel.Width = width; 
            panel.Location = new Point(x, y);
            panel.BackColor = Color.Transparent;
            panel.Parent = form;
        }
        public static void GiveBgImage(this Panel panel, string imagePath, int x, int y, int width, int height)
        {
            Bitmap bgImage = new Bitmap(imagePath);
            Bitmap newBgImage = new Bitmap(bgImage.Width, bgImage.Height);
            Graphics graphics = Graphics.FromImage(newBgImage);
            graphics.DrawImage(bgImage, x, y, width, height);
            panel.BackgroundImage = newBgImage;
        }
        public static void CreateLabelforPanel(this Panel panel, string text, int x, int y, int width, int height)
        {
            Label label = new Label();
            label.Parent = panel;
            label.Location = new Point(x, y);
            label.Text = text;
            label.Height = height;
            label.Width = width;
            label.Font = new Font("segoe ui", 25, FontStyle.Bold);
            label.ForeColor = Color.White;
            panel.Controls.Add(label);
        }
    }
}
