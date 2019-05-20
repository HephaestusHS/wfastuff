using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phelosphe
{
    public class Question
    {
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool IsAlreadyAsked { get; set; }
        [DefaultValue(false)]
        public bool IsHard { get; set; }
        public string Description { get; set; }
        public Group Group { get; set; }
        public List<Answer> Answers { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
