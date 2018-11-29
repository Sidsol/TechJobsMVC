using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        //static public List<Dictionary<string, string>> searchResults;
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        //[HttpPost]
        [Route("/Search/Results")]
        public IActionResult Search(string searchType, string searchTerm)
        {
            List<Dictionary<String, String>> jobs;
            if (searchType.Equals("all"))
            {
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
            }

            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Jobs with " + ListController.columnChoices[searchType] + ": " + searchTerm;
            
            return View("Index");
        }

    }
}
