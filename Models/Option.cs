using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormDeserializer.Models
{
    public class OptionGroups
    {
        public Guid OptionGroupsId { get; set; }
        public string GroupsText { get; set; }
        public List<OptionChoices> OptionChoices { get; set; }
    }
    public class OptionChoices
    {
        public Guid QuestionsChoiceId { get; set; }
        public virtual OptionGroups OptionGroup { get; set; }
        public List<QuestionOption> QuestionOptions { get; set; }
    }
}
