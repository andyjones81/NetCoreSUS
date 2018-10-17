using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreSUS.Models;
using NetCoreSUS.Models.BusinessModels;
using NetCoreSUS.Models.Data;
using Newtonsoft.Json;
using Notify.Client;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace NetCoreSUS.Controllers
{
    public class SurveyController : Controller
    {
        private readonly DataContext _context;
        private HtmlEncoder _htmlEncoder;
        private TelemetryClient _telemetry;
        IConfiguration configuration;


        public IActionResult ListAll()
        {
            return View(_context.Survey.ToList());
        }

        public SurveyController(DataContext context, HtmlEncoder htmlEncoder, IConfiguration configuration)
        {
            this.configuration = configuration;
            _context = context;
            _htmlEncoder = htmlEncoder;
            _telemetry = new TelemetryClient();
    }

        public IActionResult R(string id)
        {
            //Create a session for this survey completion
            ////Clear session first of all
            _telemetry.TrackEvent("Survey Get - Start");

            if (!Guid.TryParse(id, out var surveyId))
            {
                return RedirectToAction("Index", "Home");
            }
            _telemetry.TrackEvent("Guid: " + surveyId);

            var survey = _context.Survey.FirstOrDefault(x => x.SurveyId == surveyId);
          
            if (survey == null)
            {
                _telemetry.TrackEvent("Survey not found");
                return RedirectToAction("Index", "Home");
            }

            var model = new SessionStateViewModel
            {
                Start = DateTime.Now,
                Q1 = null,
                Q2 = null,
                Q3 = null,
                Q4 = null,
                Q5 = null,
                Feedback = "",
                SurveyId = survey.SurveyId,
                SurveyName = survey.ServiceName
            };

            _telemetry.TrackEvent("Created Model");

            HttpContext.Session.SetObjectAsJson("surveyModel", model);

            
            _telemetry.TrackEvent(HttpContext.Session.GetObjectFromJson<SessionStateViewModel>("surveyModel").SurveyId.ToString());
            return RedirectToAction("Start");
        }

        public IActionResult Index(string id)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Start()
        {
            //Does a session exist?
            _telemetry.TrackEvent(HttpContext.Session.GetString("surveyModel"));
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));
           
            return View(model);
        }

        public IActionResult Statement1()
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            return View(model);
        }

        public IActionResult Statement2()
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            return View(model);
        }

        public IActionResult Statement3()
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            return View(model);
        }

        public IActionResult Statement4()
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            return View(model);
        }

        public IActionResult Statement5()
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            return View(model);
        }

        public IActionResult Feedback()
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            return View(model);
        }

        public IActionResult Check()
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            return View(model);
        }

        public IActionResult Complete()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Statement1(IFormCollection form)
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            if (string.IsNullOrEmpty(form["q1"]))
            {
                ModelState.AddModelError("q1", "Please select a response");
                return View(model);
            }

            int.TryParse(form["q1"], out var answer);

            model.Q1 = answer;
            HttpContext.Session.SetString("surveyModel", JsonConvert.SerializeObject(model));

            model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));
            if (model.CYA)
            {
                return RedirectToAction("Check");
            }

            return RedirectToAction("Statement2");
        }

        [HttpPost]
        public IActionResult Statement2(IFormCollection form)
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            if (string.IsNullOrEmpty(form["q2"]))
            {
                ModelState.AddModelError("q2", "Please select a response");
                return View(model);
            }

            int.TryParse(form["q2"], out var answer);

            model.Q2 = answer;
            HttpContext.Session.SetString("surveyModel", JsonConvert.SerializeObject(model));

            model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));
            if (model.CYA)
            {
                return RedirectToAction("Check");
            }
            return RedirectToAction("Statement3");
        }

        [HttpPost]
        public IActionResult Statement3(IFormCollection form)
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            if (string.IsNullOrEmpty(form["q3"]))
            {
                ModelState.AddModelError("q3", "Please select a response");
                return View(model);
            }

            int.TryParse(form["q3"], out var answer);

            model.Q3 = answer;
            HttpContext.Session.SetString("surveyModel", JsonConvert.SerializeObject(model));

            model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));
            if (model.CYA)
            {
                return RedirectToAction("Check");
            }
            return RedirectToAction("Statement4");
        }

        [HttpPost]
        public IActionResult Statement4(IFormCollection form)
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            if (string.IsNullOrEmpty(form["q4"]))
            {
                ModelState.AddModelError("q4", "Please select a response");
                return View(model);
            }

            int.TryParse(form["q4"], out var answer);

            model.Q4 = answer;
            HttpContext.Session.SetString("surveyModel", JsonConvert.SerializeObject(model));

            model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));
            if (model.CYA)
            {
                return RedirectToAction("Check");
            }
            return RedirectToAction("Statement5");
        }

        [HttpPost]
        public IActionResult Statement5(IFormCollection form)
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            if (string.IsNullOrEmpty(form["q5"]))
            {
                ModelState.AddModelError("q5", "Please select a response");
                return View(model);
            }

            int.TryParse(form["q5"], out var answer);

            model.Q5 = answer;
            HttpContext.Session.SetString("surveyModel", JsonConvert.SerializeObject(model));

            model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));
            if (model.CYA)
            {
                return RedirectToAction("Check");
            }
            return RedirectToAction("Feedback");
        }

        [HttpPost]
        public IActionResult Feedback(IFormCollection form)
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));
            
            model.Feedback = form["feedback"];
            model.CYA = true;
            HttpContext.Session.SetString("surveyModel", JsonConvert.SerializeObject(model));
        
            return RedirectToAction("Check");
        }

        [HttpPost]
        public IActionResult Check(IFormCollection form)
        {
            //Does a session exist?
            if (HttpContext.Session.GetString("surveyModel") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = JsonConvert.DeserializeObject<SessionStateViewModel>(HttpContext.Session.GetString("surveyModel"));

            //Save to the database

           

            var newResponse = new SurveyResponse
            {
                Q1 = int.Parse(model.Q1.ToString()),
                Q2 = int.Parse(model.Q2.ToString()),
                Q3 = int.Parse(model.Q3.ToString()),
                Q4 = int.Parse(model.Q4.ToString()),
                Q5 = int.Parse(model.Q5.ToString()),
                Comment = _htmlEncoder.Encode(model.Feedback),
                StartDate = DateTime.Parse(model.Start.ToString()),
                EndDate = DateTime.Now,
                SurveyId = model.SurveyId
            };

            
            _context.SurveyResponses.Add(newResponse);
            _context.SaveChanges();

       
            HttpContext.Session.Remove("surveyModel");
            var score = (newResponse.Q1 + newResponse.Q2 + newResponse.Q3 + newResponse.Q4 + newResponse.Q5) * 5;

            var client = new NotificationClient(configuration["notifySurveyAPI"]);

            var personalisation = new Dictionary<string, dynamic>
            {
                {"feedback",newResponse.Comment},
                {"surveyname",model.SurveyName},
                {"score",score.ToString()}
            };

            client.SendEmail("ajones@gamblingcommission.gov.uk", configuration["surveyResponseTemplateId"],
                personalisation, null, null);


            return RedirectToAction("Complete");
        }
    }
}