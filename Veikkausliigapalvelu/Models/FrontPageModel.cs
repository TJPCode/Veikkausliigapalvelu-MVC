using System.Collections.Generic;

namespace Veikkausliigapalvelu.Models
{
    public class FrontPageModel
    {
        public List<RssFeed> Feed { get; set; }
        public List<Slider> Slider { get; set; }
        public string FeedImgUrl { get; set; }      
    }

    public class RssFeed
    {
        public string Date { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Enclosure { get; set; } 
    }

    public class Slider
    {
        public string src { get; set; }
        public string title { get; set; }
    }
}