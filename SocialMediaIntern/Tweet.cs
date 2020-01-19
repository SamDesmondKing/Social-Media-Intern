using System;
using System.Security.AccessControl;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace SocialMediaIntern
{
    public sealed class Tweet
    {

        private string _content;
        private string _URL;
        private string _hashtags;

        public Tweet()
        {

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(
                    @"https://script.google.com/macros/s/AKfycbwOOmvw-VXFojjxW0EC1n2mFB0GZ-U5hsCBiT-h0tbyMGldHQ/exec");

                Debug.WriteLine(json);
            }



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