using System;

namespace NetCoreSUS.Models.Data
{
    public class SessionStateViewModel
    {
        public bool CYA { get; set; }
        public DateTime? Start { get; set; }
        public int? Q1 { get; set; }
        public int?  Q2 { get; set; }
        public int?  Q3 { get; set; }
        public int?  Q4 { get; set; }
        public int? Q5 { get; set; }
        public string Feedback { get; set; }
        public Guid SurveyId { get; set; }
        public string SurveyName { get; set; }
    }
}