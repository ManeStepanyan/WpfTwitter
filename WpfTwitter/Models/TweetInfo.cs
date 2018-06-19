using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTwitter.Models
{
    public class TweetInfo
    {
        
        public string Username { get; set; }
        public string Tweet { get; set; }
        public string ProfilePic { get; set; }
        public TweetInfo(string screen_name, string profile_image_url, string text)
        {
            this.Username = screen_name;
            this.ProfilePic = profile_image_url;
            this.Tweet = text;
        }
    }
}
