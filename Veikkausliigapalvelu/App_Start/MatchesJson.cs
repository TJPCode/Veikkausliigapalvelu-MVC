using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
using Veikkausliigapalvelu.Models;

namespace Veikkausliigapalvelu.App_Start
{
    public class MatchesJson
    {
        private List<Match> allMatches;
        public static MatchesJson Instance = new MatchesJson();

        /// <summary>
        /// Deserializes matches json file.
        /// </summary>
        public MatchesJson()
        {
            try
            {
                string dataPath = Path.Combine(HttpRuntime.AppDomainAppPath, Properties.Resources.MatchesJsonPath);
                string json = File.ReadAllText(dataPath, Encoding.Default);
                allMatches = JsonConvert.DeserializeObject<List<Match>>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(Properties.Resources.Exception + ex.Message);
            }
        }

        /// <summary>
        /// Gets all matches
        /// </summary>
        /// <returns></returns>
        public List<Match> GetMatches()
        {
            return allMatches;
        }
    }
}