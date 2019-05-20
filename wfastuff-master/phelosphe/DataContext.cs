using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phelosphe
{
    public class DataContext
    {
        //public DataContext() : base("philosophieDb")
        //{
        //    Database.SetInitializer(new DataInitializer());
        //}
        //public DbSet<Question> Questions { get; set; }
        //public DbSet<Answer> Answers { get; set; }
        //public DbSet<Group> Groups { get; set; }
        public List<Group> Groups;
        public List<Question> Questions;
        public List<Answer> Answers;
        public DataContext() : base()
        {
            Groups = new List<Group>()
            {
                new Group {Id = 0, HardDifficultyQuestionCount = 0},
                new Group {Id = 1, HardDifficultyQuestionCount = 0}
            };
            Questions = new List<Question>()
            {
                new Question {Id = 0, Description = "20. yy.'ın felsefecileri arasında olan S.H'nin arkasında resmi bulunan türk bilim adamı kimdir?", Group = Groups[0]},
                new Question {Id = 1, Description = "1111111Soru buraya", Group = Groups[0]},
                new Question {Id = 2, Description = "1111111Soru buraya", Group = Groups[0]},
                new Question {Id = 3, Description = "1111111Soru buraya", Group = Groups[0]},
                new Question {Id = 4, Description = "1111111Soru buraya", Group = Groups[0]},
                new Question {Id = 5, Description = "1111111Soru buraya", Group = Groups[0]},
                new Question {Id = 6, Description = "1111111Soru buraya", Group = Groups[0]},
                new Question {Id = 7, Description = "1111111Soru buraya", Group = Groups[0]},
                new Question {Id = 8, Description = "1111111Soru buraya", Group = Groups[0]},
                new Question {Id = 9, Description = "1111111Soru buraya", Group = Groups[0]},
                new Question {Id = 10, Description = "Soru buraya", Group = Groups[1]},
                new Question {Id = 11, Description = "Soru buraya", Group = Groups[1]},
                new Question {Id = 12, Description = "Soru buraya", Group = Groups[1]},
                new Question {Id = 13, Description = "Soru buraya", Group = Groups[1]},
                new Question {Id = 14, Description = "Soru buraya", Group = Groups[1]},
                new Question {Id = 15, Description = "Soru buraya", Group = Groups[1]},
                new Question {Id = 16, Description = "Soru buraya", Group = Groups[1]},
                new Question {Id = 17, Description = "Soru buraya", Group = Groups[1]},
                new Question {Id = 18, Description = "Soru buraya", Group = Groups[1]},
                new Question {Id = 19, Description = "Soru buraya", Group = Groups[1]},
            };
            Answers = new List<Answer>()
            {
                // DOĞRU CEVAPLARI TRUE YAP !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                // OYUN ÇALIŞIYO TEST ETTİM !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                new Answer {Id = 0, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[0]},
                new Answer {Id = 1, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[0]},
                new Answer {Id = 2, IsCorrect = false, Text = "Cahit Arf", Question = Questions[0]},
                new Answer {Id = 3, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[0]},

                new Answer {Id = 4, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[1]},
                new Answer {Id = 5, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[1]},
                new Answer {Id = 6, IsCorrect = false, Text = "Cahit Arf", Question = Questions[1]},
                new Answer {Id = 7, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[1]},

                new Answer {Id = 8, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[2]},
                new Answer {Id = 9, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[2]},
                new Answer {Id = 10, IsCorrect = false, Text = "Cahit Arf", Question = Questions[2]},
                new Answer {Id = 11, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[2]},

                new Answer {Id = 12, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[3]},
                new Answer {Id = 13, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[3]},
                new Answer {Id = 14, IsCorrect = false, Text = "Cahit Arf", Question = Questions[3]},
                new Answer {Id = 15, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[3]},

                new Answer {Id = 16, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[4]},
                new Answer {Id = 17, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[4]},
                new Answer {Id = 18, IsCorrect = false, Text = "Cahit Arf", Question = Questions[4]},
                new Answer {Id = 19, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[4]},

                new Answer {Id = 20, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[5]},
                new Answer {Id = 21, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[5]},
                new Answer {Id = 22, IsCorrect = false, Text = "Cahit Arf", Question = Questions[5]},
                new Answer {Id = 23, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[5]},

                new Answer {Id = 24, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[6]},
                new Answer {Id = 25, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[6]},
                new Answer {Id = 26, IsCorrect = false, Text = "Cahit Arf", Question = Questions[6]},
                new Answer {Id = 27, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[6]},

                new Answer {Id = 28, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[7]},
                new Answer {Id = 29, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[7]},
                new Answer {Id = 30, IsCorrect = false, Text = "Cahit Arf", Question = Questions[7]},
                new Answer {Id = 31, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[7]},

                new Answer {Id = 32, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[8]},
                new Answer {Id = 33, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[8]},
                new Answer {Id = 34, IsCorrect = false, Text = "Cahit Arf", Question = Questions[8]},
                new Answer {Id = 35, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[8]},

                new Answer {Id = 36, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[9]},
                new Answer {Id = 37, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[9]},
                new Answer {Id = 38, IsCorrect = false, Text = "Cahit Arf", Question = Questions[9]},
                new Answer {Id = 39, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[9]},

                new Answer {Id = 40, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[10]},
                new Answer {Id = 41, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[10]},
                new Answer {Id = 42, IsCorrect = false, Text = "Cahit Arf", Question = Questions[10]},
                new Answer {Id = 43, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[10]},

                new Answer {Id = 44, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[11]},
                new Answer {Id = 45, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[11]},
                new Answer {Id = 46, IsCorrect = false, Text = "Cahit Arf", Question = Questions[11]},
                new Answer {Id = 47, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[11]},

                new Answer {Id = 48, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[12]},
                new Answer {Id = 49, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[12]},
                new Answer {Id = 50, IsCorrect = false, Text = "Cahit Arf", Question = Questions[12]},
                new Answer {Id = 51, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[12]},

                new Answer {Id = 52, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[13]},
                new Answer {Id = 53, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[13]},
                new Answer {Id = 54, IsCorrect = false, Text = "Cahit Arf", Question = Questions[13]},
                new Answer {Id = 55, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[13]},

                new Answer {Id = 56, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[14]},
                new Answer {Id = 57, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[14]},
                new Answer {Id = 58, IsCorrect = false, Text = "Cahit Arf", Question = Questions[14]},
                new Answer {Id = 59, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[14]},

                new Answer {Id = 60, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[15]},
                new Answer {Id = 61, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[15]},
                new Answer {Id = 62, IsCorrect = false, Text = "Cahit Arf", Question = Questions[15]},
                new Answer {Id = 63, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[15]},

                new Answer {Id = 64, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[16]},
                new Answer {Id = 65, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[16]},
                new Answer {Id = 66, IsCorrect = false, Text = "Cahit Arf", Question = Questions[16]},
                new Answer {Id = 67, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[16]},

                new Answer {Id = 68, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[17]},
                new Answer {Id = 69, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[17]},
                new Answer {Id = 70, IsCorrect = false, Text = "Cahit Arf", Question = Questions[17]},
                new Answer {Id = 71, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[17]},

                new Answer {Id = 72, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[18]},
                new Answer {Id = 73, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[18]},
                new Answer {Id = 74, IsCorrect = false, Text = "Cahit Arf", Question = Questions[18]},
                new Answer {Id = 75, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[18]},

                new Answer {Id = 76, IsCorrect = false, Text = "Aydın Sayılı", Question = Questions[19]},
                new Answer {Id = 77, IsCorrect = false, Text = "Mimar Kemalettin", Question = Questions[19]},
                new Answer {Id = 78, IsCorrect = false, Text = "Cahit Arf", Question = Questions[19]},
                new Answer {Id = 79, IsCorrect = false, Text = "Ayberk Akın", Question = Questions[19]},
            };
            foreach (Answer answer in Answers)
            {
                foreach (Question question in Questions)
                {
                    if (answer.Question.Id == question.Id)
                    {
                        question.Answers.Add(answer);
                    }
                }
            }
        }
    }
}
