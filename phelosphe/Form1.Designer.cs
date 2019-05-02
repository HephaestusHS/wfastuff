using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace phelosphe
{
    public class MoneyPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(ColorTranslator.FromHtml("#fff"), 3);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(pen, 0, this.Height / 2, 20, this.Height / 2);
            e.Graphics.DrawLine(pen, 20, this.Height / 2, 50, 0);
            e.Graphics.DrawLine(pen, 20, this.Height / 2, 50, this.Height);
            e.Graphics.DrawLine(pen, 50, 0, this.Width - 50, 0);
            e.Graphics.DrawLine(pen, 50, this.Height, this.Width - 50, this.Height);
            e.Graphics.DrawLine(pen, this.Width - 50, 0, this.Width - 20, this.Height / 2);
            e.Graphics.DrawLine(pen, this.Width - 50, this.Height, this.Width - 20, this.Height / 2);
            e.Graphics.DrawLine(pen, this.Width - 20, this.Height / 2, this.Width, this.Height / 2);
            base.OnPaint(e);
        }
    }
    public class AnswerPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(ColorTranslator.FromHtml("#fff"), 3);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(pen, 0, this.Height / 2, 80, this.Height / 2);
            e.Graphics.DrawLine(pen, 80, this.Height / 2, 120, 0);
            e.Graphics.DrawLine(pen, 80, this.Height / 2, 120, this.Height);
            e.Graphics.DrawLine(pen, 120, 0, this.Width - 120, 0);
            e.Graphics.DrawLine(pen, 120, this.Height, this.Width - 120, this.Height);
            e.Graphics.DrawLine(pen, this.Width - 120, 0, this.Width - 80, this.Height / 2);
            e.Graphics.DrawLine(pen, this.Width - 120, this.Height, this.Width - 80, this.Height / 2);
            e.Graphics.DrawLine(pen, this.Width - 80, this.Height / 2, this.Width, this.Height / 2);
            base.OnPaint(e);
        }
    }
    public class JokerPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(ColorTranslator.FromHtml("#fff"), 3);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(pen, 3, 10, this.Width - 5, this.Height - 12);
            base.OnPaint(e);
        }
    }
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sidePanel = new System.Windows.Forms.Panel();
            this.JokerPanelOne = new phelosphe.JokerPanel();
            this.QuePnl = new phelosphe.AnswerPanel();
            this.AnswerPanelFour = new phelosphe.AnswerPanel();
            this.AnswerPanelThree = new phelosphe.AnswerPanel();
            this.AnswerPanelOne = new phelosphe.AnswerPanel();
            this.moneyPanel = new phelosphe.MoneyPanel();
            this.AnswerPanelTwo = new phelosphe.AnswerPanel();
            this.JokerPanelThree = new JokerPanel();
            this.JokerPanelTwo = new JokerPanel();
            this.sidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.moneyPanel);
            this.sidePanel.Location = new System.Drawing.Point(1516, -3);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(397, 1055);
            this.sidePanel.TabIndex = 0;
            // 
            // JokerPanelOne
            // 
            this.JokerPanelOne.Location = new System.Drawing.Point(50, 30);
            this.JokerPanelOne.Name = "JokerPanelOne";
            this.JokerPanelOne.Size = new System.Drawing.Size(645, 38);
            this.JokerPanelOne.TabIndex = 4;
            // 
            // QuePnl
            // 
            this.QuePnl.Location = new System.Drawing.Point(312, 113);
            this.QuePnl.Name = "QuePnl";
            this.QuePnl.Size = new System.Drawing.Size(1071, 8);
            this.QuePnl.TabIndex = 3;
            // 
            // AnswerPanelFour
            // 
            this.AnswerPanelFour.Location = new System.Drawing.Point(626, 206);
            this.AnswerPanelFour.Name = "AnswerPanelFour";
            this.AnswerPanelFour.Size = new System.Drawing.Size(9, 405);
            this.AnswerPanelFour.TabIndex = 1;
            // 
            // AnswerPanelThree
            // 
            this.AnswerPanelThree.Location = new System.Drawing.Point(384, 366);
            this.AnswerPanelThree.Name = "AnswerPanelThree";
            this.AnswerPanelThree.Size = new System.Drawing.Size(206, 43);
            this.AnswerPanelThree.TabIndex = 2;
            // 
            // AnswerPanelOne
            // 
            this.AnswerPanelOne.Location = new System.Drawing.Point(373, 535);
            this.AnswerPanelOne.Name = "AnswerPanelOne";
            this.AnswerPanelOne.Size = new System.Drawing.Size(200, 100);
            this.AnswerPanelOne.TabIndex = 1;
            // 
            // moneyPanel
            // 
            this.moneyPanel.Location = new System.Drawing.Point(3, 896);
            this.moneyPanel.Name = "moneyPanel";
            this.moneyPanel.Size = new System.Drawing.Size(394, 100);
            this.moneyPanel.TabIndex = 0;
            // 
            // AnswerPanelTwo
            // 
            this.AnswerPanelTwo.Location = new System.Drawing.Point(1, 1);
            this.AnswerPanelTwo.Name = "AnswerPanelTwo";
            this.AnswerPanelTwo.Size = new System.Drawing.Size(200, 100);
            this.AnswerPanelTwo.TabIndex = 1;
            // 
            // JokerPanelThree
            // 
            this.JokerPanelThree.Location = new System.Drawing.Point(237, 177);
            this.JokerPanelThree.Name = "JokerPanelThree";
            this.JokerPanelThree.Size = new System.Drawing.Size(10, 100);
            this.JokerPanelThree.TabIndex = 5;
            // 
            // JokerPanelTwo
            // 
            this.JokerPanelTwo.Location = new System.Drawing.Point(123, 122);
            this.JokerPanelTwo.Name = "JokerPanelTwo";
            this.JokerPanelTwo.Size = new System.Drawing.Size(134, 33);
            this.JokerPanelTwo.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1912, 1050);
            this.Controls.Add(this.JokerPanelTwo);
            this.Controls.Add(this.JokerPanelThree);
            this.Controls.Add(this.JokerPanelOne);
            this.Controls.Add(this.QuePnl);
            this.Controls.Add(this.AnswerPanelFour);
            this.Controls.Add(this.AnswerPanelThree);
            this.Controls.Add(this.AnswerPanelOne);
            this.Controls.Add(this.sidePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.sidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private MoneyPanel moneyPanel;
        private AnswerPanel AnswerPanelOne;
        private AnswerPanel AnswerPanelTwo;
        private AnswerPanel AnswerPanelThree;
        private AnswerPanel AnswerPanelFour;
        private AnswerPanel QuePnl;
        private JokerPanel JokerPanelOne;
        private JokerPanel JokerPanelThree;
        private JokerPanel JokerPanelTwo;
    }
}

