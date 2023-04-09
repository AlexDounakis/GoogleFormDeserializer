using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormDeserializer.Models
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string Title { get; set; }
        public string QuestionType { get; set; }
        public List<QuestionOption> Options { get; set; }
    }
    public class QuestionType
    {
        public Guid QuestionId { get; set; }
        public string QuestionTypeName { get; set; }
    }
    public class QuestionOption
    {
        public Guid AnswerId { get; set; }
        public virtual Question Question { get; set; }
        public Guid QuestionId { get; set; }
        public virtual OptionChoices OptionChoice { get; set; }
        public Guid OptionChoiceId { get; set; }
    }
}
