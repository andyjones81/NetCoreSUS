using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreSUS.Models.BusinessModels;

namespace NetCoreSUS.Models.PageModels
{
    public class ResponsesModel
    {
        public Survey Survey { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public SurveyResponse SurveyResponse { get; set; }
    }
}
