using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSUS.Models.BusinessModels
{
    public class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SurveyId { get; set; }
        public string ServiceName { get; set; }
        public string SurveyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
        public virtual ICollection<ServiceHistory> ServiceHistory { get; set; }
    }
}
