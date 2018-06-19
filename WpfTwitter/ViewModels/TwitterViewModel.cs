using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;
using WpfTwitter.Models;


namespace WpfTwitter.ViewModels
{
   public class TwitterViewModel
    {   
        private API myApi;
        private void InitializeApi()
        {
            string Access_token = "2986044068-0BZcqTQvAIZOX4u9XUaXFPTjEaFXpZzSERoernX";
            string secret = "7bXroR3xvenRGKVDuvish2DVO7Pamx1EKIKQFluPHHx6g";
            string consume_secret = "5rMsKDdaVrjgApnN2GZtyYZD70OOMcTds9B1SFW7RN7S0IAOrM";
            string consumer_key = "YtW4h9NMR8CHfpJ7SkJBq3zrJ";

            this.myApi = new API(Access_token, secret, consumer_key, consume_secret);
        }
        public List<TweetInfo> Get(string hashtag)
        {
            InitializeApi();
            var tag = String.Format("https://api.twitter.com/1.1/search/tweets.json?q={0}&result_type=recent", hashtag);
            var res = myApi.Get(tag);
            List<TweetInfo> list = new List<TweetInfo>();
            foreach (var item in (JArray)res[0].ToList()[0].Value)
            {
                TweetInfo info;
                info = new TweetInfo(item["user"]["screen_name"].Value<string>(), item["user"]["profile_image_url"].Value<string>(), item["text"].Value<string>());
                list.Add(info);

            } return list;
           
        }
    }
}
