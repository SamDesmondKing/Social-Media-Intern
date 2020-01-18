using System;
using System.Security.AccessControl;
using Windows.ApplicationModel.Store.Preview.InstallControl;

namespace SocialMediaIntern
{
    public sealed class Tweet
    {

        private string _content;
        private string _URL;
        private string _hashtags;

        

        public Tweet()
        {

            //Get content and URL from google sheets
            //Get hashtags from google sheets


        }

        public string ToString()
        {
            return this._content + " " + this._URL + " " + this._hashtags;
        }

        public string GetURL()
        {
            return this._URL;
        }

    }
}