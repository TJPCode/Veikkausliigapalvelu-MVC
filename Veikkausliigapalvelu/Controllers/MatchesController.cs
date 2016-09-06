using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Veikkausliigapalvelu.App_Start;
using Veikkausliigapalvelu.Models;

namespace Veikkausliigapalvelu.Controllers
{
    public class MatchesController : Controller
    {
        /// <summary>
        /// Gets all matches from json file.
        /// </summary>
        /// <returns>All matches</returns>
        public ActionResult Matches()
        {
            List<Match> matches = MatchesJson.Instance.GetMatches();
            string searchTxt = string.Empty;
            if (matches == null)
            {
                searchTxt = Properties.Resources.Error;
            }
            return View(new ResultsModel { SearchResultTxt = searchTxt, Matches = matches });
        }
        
        /// <summary>
        /// Filters matches by start date and end date.
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Filtered matches</returns>
        public ActionResult FilteredMatches(string startDate, string endDate)
        {
            string searchTxt = string.Empty;
            List<Match> matches = MatchesJson.Instance.GetMatches();
            List<Match> filteredMatches = new List<Match>();

            foreach (Match r in matches)
            {
                DateTime date = Convert.ToDateTime(r.MatchDate);
                if (date >= Convert.ToDateTime(startDate) && date <= Convert.ToDateTime(endDate))
                {
                    filteredMatches.Add(r);
                }
            }
            matches = filteredMatches;

            if (matches.Count == 0)
            {
                searchTxt = Properties.Resources.NotFound + String.Format("{0:d.M.yyyy}", startDate) + Properties.Resources.Hyphen + String.Format("{0:d.M.yyyy}", endDate);
            }
            else
            {
                searchTxt = "Löydettiin " + matches.Count + " ottelua päiviltä " + String.Format("{0:d.M.yyyy}", startDate) + Properties.Resources.Hyphen + String.Format("{0:d.M.yyyy}", endDate);
            }
            return View("Matches", new ResultsModel { SearchResultTxt = searchTxt, Matches = matches });
        }   
       
        /// <summary>
        /// Uses matchId parameter to find match details.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns>Found match details</returns>
        public ActionResult MatchDetails(int matchId)
        {
            List<Match> matches = MatchesJson.Instance.GetMatches();         
            Match matchDetails = matches.Find(x => x.Id == matchId); 
            return View(matchDetails);
        }
    }
}