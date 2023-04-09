using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormDeserializer.Models
{
    public class Response
    {
        public virtual SurveySection SurveySection { get; set; }
        public Guid SurveySectionId { get; set; }
        public virtual SurveyUser SurveyUser { get; set; }
        public Guid SurveyUserId { get; set; }
        public virtual QuestionOption QuestionOption { get; set; }
        public Guid QuestionOptionId { get; set; }
    }
}
