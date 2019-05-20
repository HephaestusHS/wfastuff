using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace phelosphe
{
    public partial class Form1 : Form
    {
        DataContext db = new DataContext();
        Question question;
        Group group;
        Timer timeTimer;
        Timer JokerTimer;
        Timer MoneyPanelTransitionTimer;
        List<TimePanel> timePanels;
        List<Label> moneyLabels;
        List<Label> AnswerLabels = new List<Label>();
        Label QuestionPanelLabel;
        int[] moneyArray = new int[] { 0, 1000, 2000, 5000, 10000, 20000, 50000, 100000, 250000, 500000, 1000000 };
        int firstGroupsPoints = 0;
        int secondGroupsPoints = 0;
        byte timePerQuestion = 30;
        byte timePanelIndex = 0;
        byte timePerJoker = 45;
        byte timesPlayed = 0;
        public static byte timesAnswerdCorrectly = 0;
        byte QuestionId = 1;
        byte MarginBetweenMoneyLabels = 105;
        byte MoneyLabelIndex = 0;
        bool IsJokerActivated = false;
        bool IsQuestionAnswerd = false;
        public Form1()
        {
            InitializeComponent();
            Methods.ResetRngConditions(db);
            group = db.Groups.Where(a => a.Id == 0).FirstOrDefault();
            timesPlayed++;
            question = db.GetQuestion(group);
            this.BackColor = ColorTranslator.FromHtml("#311ebf");
            sidePanel.PaintPanel("#1c1168");
            sidePanel.GiveLocationToPanel(this);
            moneyLabels = sidePanel.CreateMoneyLabels();
            moneyLabels[MoneyLabelIndex].BringToFront();
            moneyPanel.Location = new Point(0, 960);
            moneyPanel.Parent = sidePanel;
            moneyPanel.Width = 300;
            moneyPanel.Height = 80;
            moneyPanel.BackColor = ColorTranslator.FromHtml("#1c1168");
            AnswerPanelOne.CreateAPanel(this, 0, this.Height - 300, (this.Width - 300) / 2, 110);
            Label AnswerLabelOne = AnswerPanelOne.CreateLabelForAnswerPanel("AnswerLabelOne");
            AnswerLabels.Add(AnswerLabelOne);
            AnswerPanelOne.Cursor = Cursors.Hand;
            AnswerPanelOne.Click += OnAPOClick;
            AnswerLabelOne.Click += OnAPOClick;
            AnswerPanelTwo.CreateAPanel(this, (this.Width - 300) / 2 - 1, this.Height - 300, (this.Width - 300) / 2, 110);
            Label AnswerLabelTwo = AnswerPanelTwo.CreateLabelForAnswerPanel("AnswerLabelTwo");
            AnswerLabels.Add(AnswerLabelTwo);
            AnswerPanelTwo.Cursor = Cursors.Hand;
            AnswerPanelTwo.Click += OnAPTClick;
            AnswerLabelTwo.Click += OnAPTClick;
            AnswerPanelThree.CreateAPanel(this, 0, this.Height - 160, (this.Width - 300) / 2, 110);
            Label AnswerLabelThree = AnswerPanelThree.CreateLabelForAnswerPanel("AnswerLabelThree");
            AnswerLabels.Add(AnswerLabelThree);
            AnswerPanelThree.Cursor = Cursors.Hand;
            AnswerPanelThree.Click += OnAPThreeClick;
            AnswerLabelThree.Click += OnAPThreeClick;
            AnswerPanelFour.CreateAPanel(this, (this.Width - 300) / 2 - 1, this.Height - 160, (this.Width - 300) / 2, 110);
            Label AnswerLabelFour = AnswerPanelFour.CreateLabelForAnswerPanel("AnswerLabelFour");
            AnswerLabels.Add(AnswerLabelFour);
            AnswerPanelFour.Cursor = Cursors.Hand;
            AnswerPanelFour.Click += OnAPFClick;
            AnswerLabelFour.Click += OnAPFClick;
            this.Controls.SetChildIndex(AnswerPanelThree, 999);
            this.Controls.SetChildIndex(AnswerPanelFour, 999);
            QuePnl.CreateAPanel(this, 0, this.Height - 545, this.Width - 308, 200);
            QuestionPanelLabel = QuePnl.CreateLabelForQuestionPanel();
            QuestionPanelLabel.AppendAnswerToQuestionPanel(question);
            JokerPanelOne.CreateAPanel(this, 30, 21, 90, 75);
            JokerPanelOne.GiveBgImage(@"Images\book.png", 15, 25, 60, 34);
            JokerPanelOne.Cursor = Cursors.Hand;
            JokerPanelOne.Click += GetHelpFromBook;
            JokerPanelTwo.CreateAPanel(this, 160, 21, 90, 75);
            Label JokerLabelTwo = JokerPanelTwo.CreateLabelforPanel("½", 22, 18, 50, 50);
            JokerPanelTwo.Cursor = Cursors.Hand;
            JokerPanelTwo.Click += RemoveTwoChoices;
            JokerLabelTwo.Click += RemoveTwoChoices;
            JokerPanelThree.CreateAPanel(this, 290, 21, 90, 75);
            Label JokerLabelThree = JokerPanelThree.CreateLabelforPanel("2x", 18, 18, 80, 50);
            JokerPanelThree.Cursor = Cursors.Hand;
            JokerLabelThree.Click += CanAnswerTwice;
            JokerPanelThree.Click += CanAnswerTwice;
            timePanels = this.CreateTimePanels(140, this.Height - 590, 30, 30);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            timeTimer = Methods.CreateTimer(1000, true, "timeTimer", OnTimeTimerTick);
            JokerTimer = Methods.CreateTimer(1000, false, "jokerTimer", OnJokerTimerTick);
            MoneyPanelTransitionTimer = Methods.CreateTimer(100, false, "moneyPanelTimer", OnCorrectAnswer);
            AnswerLabels.AppendAnswerToPanel(question);
        }
        private void GetHelpFromBook(object sender, EventArgs args)
        {
            if (JokerPanelOne.IsUsed == false && IsJokerActivated == false && IsQuestionAnswerd == false)
            {
                timeTimer.Stop();
                JokerPanelOne.IsUsed = true;
                JokerPanelOne.Invalidate();
                IsJokerActivated = true;
                JokerTimer.Start();
            }
        }
        private void RemoveTwoChoices(object sender, EventArgs args)
        {
            if (JokerPanelTwo.IsUsed == false && IsJokerActivated == false && IsQuestionAnswerd == false)
            {
                timeTimer.Stop();
                JokerPanelTwo.IsUsed = true;
                JokerPanelTwo.Invalidate();
                IsJokerActivated = true;
                JokerTimer.Start();
            }
        }
        private void CanAnswerTwice(object sender, EventArgs args)
        {
            if (JokerPanelThree.IsUsed == false && IsJokerActivated == false && IsQuestionAnswerd == false)
            {
                timeTimer.Stop();
                JokerPanelThree.IsUsed = true;
                JokerPanelThree.Invalidate();
                IsJokerActivated = true;
                JokerTimer.Start();
            }
        }
        private void OnAPOClick(object sender, EventArgs args)
        {
            if (IsQuestionAnswerd == false)
            {
                question.OnAnswerButtonClick(MoneyPanelTransitionTimer, timeTimer, AnswerPanelOne, 0);
                if (timesPlayed == 1)
                {
                    firstGroupsPoints += moneyArray[timesAnswerdCorrectly];
                }
                else if (timesPlayed == 2)
                {
                    secondGroupsPoints += moneyArray[timesAnswerdCorrectly];
                }
                IsQuestionAnswerd = true;
            }
        }
        private void OnAPTClick(object sender, EventArgs args)
        {
            if (IsQuestionAnswerd == false)
            {
                question.OnAnswerButtonClick(MoneyPanelTransitionTimer, timeTimer, AnswerPanelTwo, 1);
                if (timesPlayed == 1)
                {
                    firstGroupsPoints += moneyArray[timesAnswerdCorrectly];
                }
                else if (timesPlayed == 2)
                {
                    secondGroupsPoints += moneyArray[timesAnswerdCorrectly];
                }
                IsQuestionAnswerd = true;
            }
        }
        private void OnAPThreeClick(object sender, EventArgs args)
        {
            if (IsQuestionAnswerd == false)
            {
                question.OnAnswerButtonClick(MoneyPanelTransitionTimer, timeTimer, AnswerPanelThree, 2);
                if (timesPlayed == 1)
                {
                    firstGroupsPoints += moneyArray[timesAnswerdCorrectly];
                }
                else if (timesPlayed == 2)
                {
                    secondGroupsPoints += moneyArray[timesAnswerdCorrectly];
                }
                IsQuestionAnswerd = true;
            }
        }
        private void OnAPFClick(object sender, EventArgs args)
        {
            if (IsQuestionAnswerd == false)
            {
                question.OnAnswerButtonClick(MoneyPanelTransitionTimer, timeTimer, AnswerPanelFour, 3);
                if (timesPlayed == 1)
                {
                    firstGroupsPoints += moneyArray[timesAnswerdCorrectly];
                }
                else if (timesPlayed == 2)
                {
                    secondGroupsPoints += moneyArray[timesAnswerdCorrectly];
                }
                IsQuestionAnswerd = true;
            }
        }
        private void OnJokerTimerTick(object sender, EventArgs args)
        {
            timePerJoker--;
            if (timePerJoker == 0)
            {
                JokerTimer.Stop();
                timeTimer.Start();
                timePerJoker = 45;
                IsJokerActivated = false;
            }
        }
        private void OnTimeTimerTick(object sender, EventArgs args)
        {
            timePerQuestion--;
            if (timePerQuestion % 2 == 0)
            {
                timePanels[timePanelIndex].HexCode = "#311ebf";
                timePanels[timePanelIndex].Invalidate();
                timePanelIndex += 1;
            }
            if (timePerQuestion == 0)
            {
                timeTimer.Stop();
                timePerQuestion = 30;
                timePanelIndex = 0;
                IsQuestionAnswerd = true;
            }
        }
        private void OnCorrectAnswer(object sender, EventArgs args)
        {
            if (MoneyLabelIndex != 9)
            {
                MarginBetweenMoneyLabels -= 21;
                moneyPanel.BringToFront();
                moneyPanel.Location = new Point(moneyPanel.Bounds.X, moneyPanel.Bounds.Y - 21);
            }
            if (MarginBetweenMoneyLabels == 0)
            {
                MoneyPanelTransitionTimer.Stop();
                MarginBetweenMoneyLabels = 105;
                if (MoneyLabelIndex != 9)
                {
                    MoneyLabelIndex++;
                    moneyLabels[MoneyLabelIndex].BringToFront();
                }
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyValue == 17 && IsQuestionAnswerd == true)
            {
                QuestionId++;
                AnswerPanelOne.CorrectAnswer = false;
                AnswerPanelOne.WrongAnswer = false;
                AnswerPanelTwo.CorrectAnswer = false;
                AnswerPanelTwo.WrongAnswer = false;
                AnswerPanelThree.CorrectAnswer = false;
                AnswerPanelThree.WrongAnswer = false;
                AnswerPanelFour.CorrectAnswer = false;
                AnswerPanelFour.WrongAnswer = false;
                AnswerPanelOne.Invalidate();
                AnswerPanelTwo.Invalidate();
                AnswerPanelThree.Invalidate();
                AnswerPanelFour.Invalidate();
                foreach (TimePanel timePanel in timePanels)
                {
                    timePanel.Dispose();
                }
                timePanels = this.CreateTimePanels(140, this.Height - 590, 30, 30);
                if (QuestionId == 11)
                {
                    QuestionId = 1;
                    MoneyLabelIndex = 0;
                    timesAnswerdCorrectly = 0;
                    timesPlayed++;
                    moneyPanel.Location = new Point(0, 960);
                    foreach (Label moneyLabel in moneyLabels)
                    {
                        moneyLabel.BringToFront();
                    }
                    group = db.Groups.Where(a => a.Id == 1).FirstOrDefault();
                    if (timesPlayed == 3)
                    {
                        sidePanel.Visible = false;
                        foreach (TimePanel timePanel in timePanels)
                        {
                            timePanel.Visible = false;
                        }
                        JokerPanelOne.Visible = false;
                        JokerPanelTwo.Visible = false;
                        JokerPanelThree.Visible = false;
                        AnswerPanelOne.Visible = false;
                        AnswerPanelTwo.Visible = false;
                        AnswerPanelThree.Visible = false;
                        AnswerPanelFour.Visible = false;
                        QuePnl.Visible = false;
                        this.DisplayGameResults(new int[] { firstGroupsPoints, secondGroupsPoints });
                        this.DisplayNames();
                        timeTimer.Stop();
                    }
                }
                if (timesPlayed != 3)
                {
                    timePerQuestion = 0;
                    timePanelIndex = 0;
                    question.IsAlreadyAsked = true;
                    question = db.GetQuestion(group);
                    IsQuestionAnswerd = false;
                    timeTimer.Start();
                    QuestionPanelLabel.AppendAnswerToQuestionPanel(question);
                    AnswerLabels.AppendAnswerToPanel(question);
                }
            }
            base.OnKeyDown(e);
        }
    }
}