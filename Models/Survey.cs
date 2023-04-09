using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormDeserializer.Models
{
    public class Survey
    {
        [JsonProperty("formId")]
        public string SurveyId { get; set; }

        [JsonProperty("info.title")]
        public string Title { get; set; }

        [JsonProperty("info.description")]
        public string Description { get; set; }
        //public Info info { get; set; }

        [JsonProperty("items")]
        public List<SurveySection> Sections { get; set; }
    }

    public class SurveySection
    {
        [JsonProperty("itemId")]
        public string SurveySectionId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("questionItem.question")]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual Survey Survey { get; set; }

        [JsonIgnore]
        public Guid SurveyId { get; set; }
    }

    //public class Info
    //{
    //    public string title { get; set; }
    //    public string description { get; set; }
    //}
}
