using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace SocialMediaIntern
{
    public sealed class Intern
    {

        private List<Tweet> _tweetHistory = new List<Tweet>();

        //Google authentication here

        //Twitter auth here

        public Intern()
        {
            while (true)
            { 
                try
                {
                    this.ComposeTweet();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error: " + e.ToString());
                    //Could even send a tweet with error message here while using throwaway
                }
                Thread.Sleep(120000);
            }
        }

        public void ComposeTweet()
        {
            var uniqueTweet = false;

            //Try to compose and send a unique tweet,
            //will loop until successful.
            while (!uniqueTweet)
            { 
                //Give google auth here
                var tweet = new Tweet();
                uniqueTweet = true;

                //Only checks for duplicate URL.
                foreach (var oldTweet in this._tweetHistory.Where(oldTweet => oldTweet.GetURL() == tweet.GetURL()))
                {
                    uniqueTweet = false;
                }

                if (!uniqueTweet) continue;
                this.SendTweet(tweet);
                this.SaveTweet(tweet);
            }
        }

        public void SendTweet(Tweet tweet)
        {
            //Tweet that shit
        }

        public void SaveTweet(Tweet tweet)
        {
            this._tweetHistory.Add(tweet);

            if (this._tweetHistory.Count > 10)
            {
                this._tweetHistory.RemoveAt(0);
            }
        }
    }
}