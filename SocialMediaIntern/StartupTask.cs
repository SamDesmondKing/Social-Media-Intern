using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using Windows.ApplicationModel.Background;
using ThreadStaticAttribute = System.ThreadStaticAttribute;

namespace SocialMediaIntern
{
    public sealed class StartupTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var socialMediaIntern = new Intern();

            //Improvements:
            // Increase reusability
            // Reduce hard-coding
            // Add database for history between restarts
            // Add ability to specify time for posting
        }
    }
}
