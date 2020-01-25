using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace SocialMediaIntern
{
    public sealed class Tweet
    {
        private string _title;
        private string _URL;
        private string _hashtags;

        private List<string> _titleList = new List<string>();
        private List<string> _URLlist = new List<string>();
        private List<string> _hashtagList = new List<string>();

        public Tweet()
        {

            using (WebClient wc = new WebClient())
            { 

                //Get content from google sheets as JSONs
                var contentJson = wc.DownloadString(
                    @"https://script.google.com/macros/s/AKfycbwOOmvw-VXFojjxW0EC1n2mFB0GZ-U5hsCBiT-h0tbyMGldHQ/exec");
                var hashtagJson = wc.DownloadString(
                    @"https://script.google.com/macros/s/AKfycbwP_pD-QhPSFWFxNywGZudzGE5BQzyrTKP46UbmMvTQZbjJDw/exec");

                var content = JArray.Parse(contentJson); 
                var hashtags = JArray.Parse(hashtagJson);

                //Build title and URL lists
               foreach (JObject item in content)
               {
                   this._titleList.Add(item.GetValue("Title").ToString());
                   this._URLlist.Add(item.GetValue("URL").ToString());
               }

               //Build hashtag list
               foreach (JObject item in hashtags)
               {
                   this._hashtagList.Add(item.GetValue("Hashtag").ToString());
               }

               //Assign title and URL to this tweet.
               Random random = new Random();
               int choice = random.Next(this._titleList.Count);
               this._title = this._titleList[choice];
               this._URL = this._URLlist[choice];

                //Assign 3 random unique hashtags to this tweet
                var nums = Enumerable.Range(0, this._hashtagList.Count).ToArray();

                for (int i = 0; i < 3; ++i)
                {
                    int randomIndex = random.Next(nums.Length);
                    int temp = nums[randomIndex];
                    nums[randomIndex] = nums[i];
                    nums[i] = temp;
                }

                this._hashtags = _hashtagList[nums[0]] + " " + _hashtagList[nums[1]] + " " + _hashtagList[nums[2]];
            }
        }

        public string ToString()
        {
            return this._title + " " + this._URL + " " + this._hashtags;
        }

        public string GetURL()
        {
            return this._URL;
        }
    }
}