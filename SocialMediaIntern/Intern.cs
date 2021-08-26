using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using TweetSharp;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace SocialMediaIntern
{
    public sealed class Intern
    {

        private List<Tweet> _tweetHistory = new List<Tweet>();

        const string _customerKey = "";
        const string _customerKeySecret = "";
        const string _accessToken = "";
        const string _accessTokenSecret = "";
        private static readonly TwitterService _service = new TwitterService(_customerKey, _customerKeySecret, _accessToken, _accessTokenSecret);

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
                    Debug.WriteLine("Error: " + e.GetBaseException());
                }
                //Sleep for 24 hours
                Thread.Sleep(86400000);
            }
        }

        public void ComposeTweet()
        {
            var uniqueTweet = false;

            //Try to compose and send a unique tweet,
            //will loop until successful.
            while (!uniqueTweet)
            {
                var tweet = new Tweet();
                uniqueTweet = true;

                //Only checks for duplicate URL.
                foreach (var oldTweet in this._tweetHistory.Where(oldTweet => oldTweet.GetURL() == tweet.GetURL()))
                {
                    uniqueTweet = false;
                }

                if (!uniqueTweet) continue;
                SendTweet(tweet);
                this.SaveTweet(tweet);
            }
        }

        //Sender that takes tweet as tweet object
        private static void SendTweet(Tweet myTweet)
        {

            var status = myTweet.ToString();

            _service.SendTweet(new SendTweetOptions { Status = status }, (tweet, response) =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    FormattableString message =
                        $"{status} - SENT. Time: {DateTime.Today}";
                    Debug.WriteLine(message);
                }
                else
                {
                    FormattableString message = $"{status} - FAILED. HTTP response: {response.Error.Message} Time: {DateTime.Today}";
                    Debug.WriteLine(message);
                }
            });
        }


        //Sender that takes tweet as String
        private static void SendTweet(string status)
        {

            _service.SendTweet(new SendTweetOptions { Status = status }, (tweet, response) =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    FormattableString message =
                        $"{status} - SENT. Time: {DateTime.Today}";
                    Debug.WriteLine(message);
                }
                else
                {
                    FormattableString message = $"{status} - FAILED. HTTP response: {response.Error.Message} Time: {DateTime.Today}";
                    Debug.WriteLine(message);
                }
            });
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
