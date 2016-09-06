using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Veikkausliigapalvelu.Models;

namespace Veikkausliigapalvelu.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Gets default rss feed (iltasanomat) and returns it to index page after application started or navbar frontpage link pressed.
        /// </summary>
        /// <returns>Default rss feed</returns>
        public ActionResult Index()
        {
            return View(GetRssFeed(Properties.Resources.url_IS));
        }

        /// <summary>
        /// Gets selected rss feed and returns it as a partial view after feed providers link pressed.
        /// </summary>
        /// <param name="rss_source">Selected rss source</param>
        /// <returns>Rss feed</returns>
        public PartialViewResult PartialRssFeed(string rss_source)
        {
            string url = string.Empty;
            if (rss_source.Equals(Properties.Resources.IS))
            {
                url = Properties.Resources.url_IS;
            }
            else if (rss_source.Equals(Properties.Resources.IL))
            {
                url = Properties.Resources.url_IL;
            }
            else if (rss_source.Equals(Properties.Resources.MTV))
            {
                url = Properties.Resources.url_MTV;
            }
            return PartialView(GetRssFeed(url));
        }

        /// <summary>
        /// Deserializes rss feed.
        /// </summary>
        /// <param name="url">Providers url</param>
        /// <returns>FrontPageModel</returns>
        [NonAction]
        private static object GetRssFeed(string url)
        {
            List<RssFeed> rssFeed = new List<RssFeed>();
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            string imageUrl = feed.ImageUrl.ToString();
            int feedCount = 0;
            foreach (SyndicationItem feedItem in feed.Items)
            {
                feedCount++;
                RssFeed rf = new RssFeed();
                rf.Title = feedItem.Title.Text;
                rf.Link = feedItem.Links[0].Uri.ToString();
                rf.Date = feedItem.PublishDate.DateTime.ToString();

                if (feedItem.Summary != null)
                {
                    rf.Description = feedItem.Summary.Text;
                }

                // Check if feed contains image url.
                if (feedItem.Links.Count > 1)
                {
                    rf.Enclosure = feedItem.Links[1].Uri.ToString();
                }
                else
                {
                    rf.Enclosure = string.Empty;
                }
                rssFeed.Add(rf);
                if (feedCount == 20)
                {
                    break;
                }
            }
            return new FrontPageModel { Feed = rssFeed, FeedImgUrl = imageUrl, Slider = GetSliders() };
        }

        /// <summary>
        /// Loads slider images.
        /// </summary>
        /// <returns>Slider list</returns>
        [NonAction]
        private static List<Slider> GetSliders()
        {
            string[] filePaths = Directory.GetFiles(Path.Combine(HttpRuntime.AppDomainAppPath, Properties.Resources.SlidersPath));
            List<Slider> files = new List<Slider>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new Slider
                {
                    title = fileName.Split('.')[0].ToString(),
                    src = "../Content/Sliders/" + fileName
                });
            }
            return files;
        }
    }
}