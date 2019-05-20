using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Media;

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
        public static List<Label> CreateMoneyLabels(this Panel sidePanel)
        {
            List<Label> labels = new List<Label>();
            string[] moneyArray = new string[] { "1000", "2000", "5000", "10000", "20000", "50000", "100000", "250000", "500000", "1000000" };
            //string[] moneyArray = new string[] { "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" };
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
                sidePanel.Controls.Add(lbl);
                labels.Add(lbl);
                LblHeight -= 105;
            }
            return labels;
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
        public static Label CreateLabelforPanel(this Panel panel, string text, int x, int y, int width, int height)
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
            return label;
        }
        public static List<TimePanel> CreateTimePanels(this Form1 form, int x, int y, int width, int height)
        {
            string[] hexCodes = new string[] { "#31c906", "#45c405", "#55c107", "#8fc107", "#bbdb08", "#d3db08", "#dbdb08", "#dbd008", "#dbc508", "#dbb008", "#db9b08", "#db5108", "#db3908", "#db2e08", "#db0808" };
            List<TimePanel> panels = new List<TimePanel>();
            for (byte a = 0; a < 15; a++)
            {
                TimePanel panel = new TimePanel()
                {
                    Name = "TimePanel" + a.ToString(),
                    BackColor = Color.Transparent,
                    Location = new Point(x, y),
                    Width = width,
                    Height = height,
                    Parent = form,
                    HexCode = hexCodes[a]
                };
                form.Controls.Add(panel);
                panels.Add(panel);
                x += 66;
            }
            return panels;
        }
        public static Timer CreateTimer(int interval, bool IsEnabled, string Tag, EventHandler method)
        {
            Timer timer = new Timer()
            {
                Interval = interval,
                Enabled = IsEnabled,
                Tag = Tag
            };
            timer.Tick += method;
            return timer;
        }
        public static void PaintAnswerPanel(this PaintEventArgs e, AnswerPanel panel, string HexCode)
        {
            SolidBrush AnswerBrush = new SolidBrush(ColorTranslator.FromHtml(HexCode));
            GraphicsPath path = new GraphicsPath();
            GraphicsPath pathTwo = new GraphicsPath();
            path.AddLine(80, panel.Height / 2, 120, 0);
            path.AddLine(panel.Width - 120, 0, panel.Width - 80, panel.Height / 2);
            pathTwo.AddLine(80, panel.Height / 2, 120, panel.Height);
            pathTwo.AddLine(panel.Width - 120, panel.Height, panel.Width - 80, panel.Height / 2);
            e.Graphics.FillPath(AnswerBrush, path);
            e.Graphics.FillPath(AnswerBrush, pathTwo);
            e.Graphics.DrawLine(new Pen(ColorTranslator.FromHtml(HexCode), 4), 82, panel.Height / 2, panel.Width - 82, panel.Height / 2);
        }
        public static Label CreateLabelForQuestionPanel(this AnswerPanel answerPanel)
        {
            Label label = new Label()
            {
                Name = "QuestionPanel",
                Text = "",
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(150, 10),
                Height = 180,
                Width = 950,
                Font = new Font("segoe ui", 20, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#fff"),
            };
            answerPanel.Controls.Add(label);
            return label;
        }
        public static void AppendAnswerToQuestionPanel(this Label questionLabel, Question question)
        {
            questionLabel.Text = question.Description;
        }
        public static Label CreateLabelForAnswerPanel(this AnswerPanel answerPanel, string labelName)
        {
            Label label = new Label()
            {
                Name = labelName,
                Text = "",
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand,
                Location = new Point(150, 10),
                Height = 90,
                Width = 340,
                Font = new Font("segoe ui", 20, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#fff"),
            };
            answerPanel.Controls.Add(label);
            return label;
        }
        public static Question GetQuestion(this DataContext db, Group group)
        {
        TryAgain:
            List<Question> questions = db.Questions.Where(a => a.Group.Id == group.Id).ToList();
            if (group.HardDifficultyQuestionCount == 2)
            {
                questions = db.Questions.Where(a => a.Group.Id == group.Id).Where(a => a.IsHard == false).ToList();
            }
            Random rng = new Random();
            int randomlyGeneratedNumber = rng.Next(0, questions.Count());
            Question randomlySelectedQuestion = questions.Skip(randomlyGeneratedNumber).FirstOrDefault();
            if (randomlySelectedQuestion.IsAlreadyAsked == false)
            {
                if (randomlySelectedQuestion.IsHard)
                {
                    group.HardDifficultyQuestionCount++;
                }
                return randomlySelectedQuestion;
            }
            goto TryAgain;
        }
        public static void AppendAnswerToPanel(this List<Label> answerPanelLabels, Question question)
        {
            byte answerIndex = 0;
            foreach (Label answerPanelLabel in answerPanelLabels)
            {
                answerPanelLabel.Text = question.Answers[answerIndex].Text;
                answerIndex++;
            }
        }
        public static void OnAnswerButtonClick(this Question question, Timer animationTimer, Timer timeTimer, AnswerPanel answerPanel, byte answerIndex)
        {
            if (question.Answers[answerIndex].IsCorrect == true)
            {
                answerPanel.CorrectAnswer = true;
                Form1.timesAnswerdCorrectly++;
                animationTimer.Start();
            }
            else if (question.Answers[answerIndex].IsCorrect == false)
            {
                answerPanel.WrongAnswer = true;
            }
            timeTimer.Stop();
            answerPanel.Invalidate();
        }
        public static void ResetRngConditions(this DataContext db)
        {
            List<Question> questions = db.Questions.ToList();
            List<Group> groups = db.Groups.ToList();
            foreach (Question question in questions)
            {
                question.IsAlreadyAsked = false;
            }
            foreach (Group g in groups)
            {
                g.HardDifficultyQuestionCount = 0;
            }
        }
        public static void DisplayGameResults(this Form1 form, int[] groupPoints)
        {
            string[] groups = new string[] { "Birinci takım: ", "İkinci takım: " };
            short y = 240;
            List<Label> labels = new List<Label>();
            for (byte lc = 0; lc < 2; lc++)
            {
                Label label = new Label()
                {
                    Width = 1920,
                    Height = 200,
                    Padding = new Padding(300, 0, 0, 0),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(0, y),
                    ForeColor = ColorTranslator.FromHtml("#616263"),
                    Font = new Font("segoe ui", 55, FontStyle.Bold),
                    Text = groups[lc] + groupPoints[lc].ToString(),
                    Parent = form,
                };
                y += 200;
                form.Controls.Add(label);
                labels.Add(label);
            }
            if (groupPoints[0] > groupPoints[1])
            {
                labels[0].BackColor = ColorTranslator.FromHtml("#FFD700");
                labels[0].ForeColor = ColorTranslator.FromHtml("#8e7800");
                labels[1].BackColor = ColorTranslator.FromHtml("#C0C0C0");
            }
            else if (groupPoints[1] > groupPoints[0])
            {
                labels[0].BackColor = ColorTranslator.FromHtml("#C0C0C0");
                labels[1].BackColor = ColorTranslator.FromHtml("#FFD700");
                labels[1].ForeColor = ColorTranslator.FromHtml("#8e7800");
            }
            else if (groupPoints[0] == groupPoints[1])
            {
                labels[0].BackColor = ColorTranslator.FromHtml("#C0C0C0");
                labels[1].BackColor = ColorTranslator.FromHtml("#C0C0C0");
            }
        }
        public static void DisplayNames(this Form1 form)
        {
            short y = 760;
            string[] names = new string[] { "Özgür Toprak Önsoy", "Süalp Kömürcüoğlu", "Alper Güdücü" };
            for (byte lc = 0; lc < 3; lc++)
            {
                Label label = new Label()
                {
                    Width = 400,
                    Height = 100,
                    Location = new Point(1520, y),
                    Text = names[lc],
                    Font = new Font("segoe ui", 25, FontStyle.Bold),
                    ForeColor = ColorTranslator.FromHtml("#fff"),
                    Parent = form
                };
                y += 100;
                form.Controls.Add(label);
            }
        }
        public static void PlaySoundEffect(string soundEffectsName)
        {
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"Sounds\" + soundEffectsName;
            soundPlayer.Play();
            soundPlayer.Dispose();
        }
    }
}