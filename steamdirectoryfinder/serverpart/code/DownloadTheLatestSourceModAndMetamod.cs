using System;
using System.Net;

namespace steamdirectoryfinder.serverpart.code
{
    public static class DownloadTheLatestSourceModAndMetamod
    {
        private const string Sourcemodlink = "https://www.sourcemod.net/downloads.php?branch=1.10-dev";
        private const string Metamodlink = "https://www.sourcemm.net/downloads.php?branch=1.10-dev";

        private static string DownloadString(string address)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(address);
            }
        }

        //construct the download links from the pages
        public static Tuple<string, string> DownloadPAges()
        {
            string sourcemodPageData = DownloadString(Sourcemodlink);
            string metamodPageData = DownloadString(Metamodlink);
            //select the fist download link
            string linkbegin = sourcemodPageData.Substring(sourcemodPageData.IndexOf("https://sm.alliedmods.net/smdrop/1.10/sourcemod-1.10.0-git6545-windows.zip", StringComparison.Ordinal));
            string sourcemodstring = linkbegin.Substring(0, linkbegin.IndexOf('\''));
            //select the first download link
            linkbegin = metamodPageData.Substring(metamodPageData.IndexOf("https://mms.alliedmods.net/mmsdrop/1.10/mmsource-1.10.7-git971-windows.zip", StringComparison.Ordinal));
            string metamodstring = linkbegin.Substring(0, linkbegin.IndexOf('\''));

            return new Tuple<string, string>(metamodstring, sourcemodstring);
        }
    }
}