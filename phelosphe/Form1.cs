using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phelosphe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#311ebf");
            //sidePanel.PaintPanel("#311ebf"); ---> first color
            sidePanel.PaintPanel("#1c1168");
            sidePanel.GiveLocationToPanel(this);
            sidePanel.CreateMoneyLabels();
            moneyPanel.Location = new Point(0, 960);
            moneyPanel.Parent = sidePanel;
            moneyPanel.Width = 300;
            moneyPanel.Height = 80;
            moneyPanel.BackColor = ColorTranslator.FromHtml("#1c1168");
            sidePanel.Controls.SetChildIndex(moneyPanel, 300);
            AnswerPanelOne.CreateAPanel(this, 0, this.Height - 300, (this.Width - 300) / 2, 110);
            AnswerPanelTwo.CreateAPanel(this, (this.Width - 300) / 2 - 1, this.Height - 300, (this.Width - 300) / 2, 110);
            AnswerPanelThree.CreateAPanel(this, 0, this.Height - 160, (this.Width - 300) / 2, 110);
            AnswerPanelFour.CreateAPanel(this, (this.Width - 300) / 2 - 1, this.Height - 160, (this.Width - 300) / 2, 110);
            this.Controls.SetChildIndex(AnswerPanelThree , 999);
            this.Controls.SetChildIndex(AnswerPanelFour, 999);
            //pnl.CreateQPanel(this, (this.Width - 300) / 2, this.Height - 160, 20, 10);
            //AnswerPanelThree.BackColor = Color.Black;
            QuePnl.CreateAPanel(this, 0, this.Height - 545, this.Width - 300, 200);
            JokerPanelOne.CreateAPanel(this, 30, 21, 90, 75);
            JokerPanelOne.GiveBgImage(@"Images\book.png", 15, 25, 60, 34);
            JokerPanelTwo.CreateAPanel(this, 160, 21, 90, 75);
            JokerPanelThree.CreateAPanel(this, 290, 21, 90, 75);
            JokerPanelTwo.CreateLabelforPanel("½", 22, 18, 50, 50);
            JokerPanelThree.GiveBgImage(@"Images\pfp.png", 26, 18, 40, 45);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}