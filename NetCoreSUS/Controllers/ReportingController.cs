using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreSUS.Models.Data;
using NetCoreSUS.Models.PageModels;

namespace NetCoreSUS.Controllers
{

    [Authorize]
    public class ReportingController : Controller
    {
        private readonly DataContext _context;

        public ReportingController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            var model = _context.Survey.Include(x => x.SurveyResponses).ToList();
            return View(model);
        }

        public IActionResult Survey(string id)
        {
            if (!Guid.TryParse(id, out var surveyId)) return RedirectToAction("Index");
            var model = _context.Survey.Include(x => x.SurveyResponses).Include(x => x.ServiceHistory).FirstOrDefault(x => x.SurveyId == surveyId);

            return View(model);
        }


        public IActionResult Responses(string id, string month, string year)
        {
            if (!Guid.TryParse(id, out var surveyId)) return RedirectToAction("Index");

            int iYear = Int32.Parse("20" + year);
            int iMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month;
            int daysInMonth = DateTime.DaysInMonth(iYear, iMonth);

            var recordStart = new DateTime(iYear, iMonth, 1);
            var recordEnd = new DateTime(iYear, iMonth, daysInMonth);

            var serviceModel = new ResponsesModel
            {
                Survey = _context.Survey.Include(x => x.SurveyResponses).FirstOrDefault(y => y.SurveyId == surveyId),
                Month = month,
                Year = year,
                Start = recordStart,
                End = recordEnd
            };

            return View(serviceModel);

        }

        public IActionResult Response(string id, string month, string year)
        {
            if (!Guid.TryParse(id, out var surveyResponseId)) return RedirectToAction("Index");

            var surveyResponse = _context.SurveyResponses.FirstOrDefault(x => x.SurveyResponseId == surveyResponseId);

            int iYear = Int32.Parse("20" + year);
            int iMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month;
            int daysInMonth = DateTime.DaysInMonth(iYear, iMonth);

            var recordStart = new DateTime(iYear, iMonth, 1);
            var recordEnd = new DateTime(iYear, iMonth, daysInMonth);

            var serviceModel = new ResponsesModel
            {
                SurveyResponse = surveyResponse,
                Survey = _context.Survey.FirstOrDefault(y => y.SurveyId == surveyResponse.SurveyId),
                Month = month,
                Year = year,
                Start = recordStart,
                End = recordEnd
            };

            return View(serviceModel);

        }

        public IActionResult Guidance()
        {
            return View();
        }
    }
}