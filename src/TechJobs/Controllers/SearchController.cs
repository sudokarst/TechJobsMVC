using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.searchType = "all";
            return View();
        }

        [Route("/Search/Results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (ListController.columnChoices.ContainsKey(searchType))
            {
                if (searchType == "all")
                {
                    ViewBag.jobs = JobData.FindByValue(searchTerm);
                }
                else
                {
                    ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
            }
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.searchType = searchType;
            return View("Index");
        }

    }
}
