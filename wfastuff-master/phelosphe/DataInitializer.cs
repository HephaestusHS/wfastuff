using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phelosphe
{
    //public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    //{
    //    protected override void Seed(DataContext context)
    //    {
    //        List<Group> groups = new List<Group>()
    //        {
    //            new Group {HardDifficultyQuestionCount = 0},
    //            new Group {HardDifficultyQuestionCount = 0}
    //        };
    //        List<Question> questions = new List<Question>()
    //        {
    //            new Question {Description = "20. yy.'ın felsefecileri arasında olan S.H'nin arkasında resmi bulunan türk bilim adamı kimdir?", Group = groups[0]},
    //            new Question {Description = "Bu ikinci sorunun descriptionının placeholderıdır.", Group = groups[0]},
    //            new Question {Description = "Bu üçüncü sorunun descriptionının placeholderıdır.", Group = groups[1]}
    //        };
    //        List<Answer> answers = new List<Answer>()
    //        {
    //            new Answer {IsCorrect = true, Text = "Aydın Sayılı", Question = questions[0]},
    //            new Answer {IsCorrect = false, Text = "Mimar Kemalettin", Question = questions[0]},
    //            new Answer {IsCorrect = false, Text = "Cahit Arf", Question = questions[0]},
    //            new Answer {IsCorrect = false, Text = "Ayberk Akın", Question = questions[0]},
    //            new Answer {IsCorrect = false, Text = "Ilk cevap", Question = questions[1]},
    //            new Answer {IsCorrect = false, Text = "Ikinci cevap", Question = questions[1]},
    //            new Answer {IsCorrect = false, Text = "Üçüncü cevap", Question = questions[1]},
    //            new Answer {IsCorrect = true, Text = "Dördüncü cevap", Question = questions[1]},
    //            new Answer {IsCorrect = false, Text = "Ilk cevap", Question = questions[2]},
    //            new Answer {IsCorrect = true, Text = "Ikinci cevap", Question = questions[2]},
    //            new Answer {IsCorrect = false, Text = "Üçüncü cevap", Question = questions[2]},
    //            new Answer {IsCorrect = false, Text = "Dördüncü cevap", Question = questions[2]}
    //        };
    //        foreach (Group group in groups)
    //        {
    //            context.Groups.Add(group);
    //        }
    //        foreach (Question question in questions)
    //        {
    //            foreach (Answer answer in answers)
    //            {
    //                if (answer.Question == question)
    //                {
    //                    question.Answers.Add(answer);
    //                }
    //            }
    //            context.Questions.Add(question);
    //        }
    //        foreach (Answer answer in answers)
    //        {
    //            context.Answers.Add(answer);
    //        }
    //        context.SaveChanges();
    //        base.Seed(context);
    //    }
    //}
}
