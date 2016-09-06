using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Veikkausliigapalvelu.App_Start;
using Veikkausliigapalvelu.Models;

namespace Veikkausliigapalvelu.Controllers
{
    public class LeagueTableController : Controller
    {
        private LeagueDbEntities db = new LeagueDbEntities();

        /// <summary>
        /// Gets league table data from database.
        /// </summary>
        /// <returns>Sorted league table data.</returns>
        public ActionResult LeagueTableDb()
        {
            return View(GetFromDatabase());
        }

        /// <summary>
        /// Gets league table data from json.
        /// </summary>
        /// <returns>League table data.</returns>
        public ActionResult LeagueTableJson()
        {
            return View(GetLeagueTableJson.Instance.GetFromJson());
        }

        /// <summary>
        /// Updates league table database.
        /// </summary>
        /// <param name="editedData">Edited league table data</param>
        /// <returns>Updated league table data</returns>
        public ActionResult UpdateDatabase(List<LeagueTable> editedData)
        {
            LeagueTable teamStats;

            // Return to view without updating if field validation fails.
            if (!ModelState.IsValid)
            {
                return View("LeagueTableDb", GetFromDatabase());
            }  

            // Find team by TeamID from the database and modify data.
            foreach (LeagueTable editedItem in editedData)
            {                             
                teamStats = db.LeagueTable.Find(editedItem.TeamID); ;
                teamStats.TeamName = editedItem.TeamName;
                teamStats.Matches = editedItem.Wins + editedItem.Draws + editedItem.Loses;
                teamStats.Wins = editedItem.Wins;
                teamStats.Draws = editedItem.Draws;
                teamStats.Loses = editedItem.Loses;
                teamStats.GoalsFor = editedItem.GoalsFor;
                teamStats.GoalsAgaints = editedItem.GoalsAgaints;
                teamStats.GoalDifference = editedItem.GoalsFor - editedItem.GoalsAgaints;
                teamStats.Points = (editedItem.Wins * 3) + (editedItem.Draws * 1);
                db.Entry(teamStats).State = EntityState.Modified;                             
            }
            // Try to save each table row to the database.
            try
            {                          
                db.SaveChanges();   
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(Properties.Resources.Exception + ex.Message);
            }
            return View("LeagueTableDb", GetFromDatabase());
        }

        /// <summary>
        /// Gets league table data from database and sorts it by points, then by goal difference and finally by goals made.
        /// </summary>
        /// <returns>Sorted league table data.</returns>
        [NonAction]
        private List<LeagueTable> GetFromDatabase()
        {
            List<LeagueTable> leagueTableDb = null;
            try
            {
                leagueTableDb = db.LeagueTable.OrderByDescending(o => o.Points).ThenByDescending(o => o.GoalDifference).ThenByDescending(o => o.GoalsFor).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return leagueTableDb;
        }
    }
}