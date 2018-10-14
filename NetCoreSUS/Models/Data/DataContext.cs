using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreSUS.Models.BusinessModels;

namespace NetCoreSUS.Models.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<Survey> Survey { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }


    }
}
