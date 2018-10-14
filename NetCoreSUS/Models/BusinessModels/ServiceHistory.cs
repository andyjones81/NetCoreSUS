using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSUS.Models.BusinessModels
{
    public class ServiceHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ServiceHistoryId { get; set; }
        public Guid ServiceId { get; set; }

        public DateTime When { get; set; }

        public string Lede { get; set; }
        public string What { get; set; }

        public Survey Survey { get; set; }
    }
}
