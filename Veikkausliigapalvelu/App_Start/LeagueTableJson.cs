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
    public class GetLeagueTableJson
    {
        private List<LeagueTable> leagueTableData;
        public static GetLeagueTableJson Instance = new GetLeagueTableJson();

        /// <summary>
        /// Deserializes league table json file.
        /// </summary>
        public GetLeagueTableJson()
        {
            try
            {
                string dataPath = Path.Combine(HttpRuntime.AppDomainAppPath, Properties.Resources.LeagueTableJsonPath);
                string json = System.IO.File.ReadAllText(dataPath, Encoding.Default);
                leagueTableData = JsonConvert.DeserializeObject<List<LeagueTable>>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(Properties.Resources.Exception + ex.Message);
            }
        }

        /// <summary>
        /// Gets league table.
        /// </summary>
        /// <returns>League table data</returns>
        public List<LeagueTable> GetFromJson()
        {
            return leagueTableData;
        }
    }
}