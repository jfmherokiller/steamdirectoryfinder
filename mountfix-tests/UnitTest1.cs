using Microsoft.VisualStudio.TestTools.UnitTesting;
using steamdirectoryfinder.serverpart.code;

namespace mountfix_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDownloadCode()
        {
 //           System.Tuple<string, string> downloadurls = DownloadTheLatestSourceModAndMetamod.DownloadPAges();
            //check sourcemod url
//            Assert.IsTrue(downloadurls.Item1.Contains("windows.zip"));
            //check metamod url
//            Assert.IsTrue(downloadurls.Item2.Contains("windows.zip"));
        }

        [TestMethod]
        public void TestClientPart()
        {
            //test without any mounts
            //steamdirectoryfinder.Program.Main(new[] { "-client", "-n", "\"hl2, ep1, lostcoast, ep2, hl1, css, dod\"" });
            //test with hl2
            //steamdirectoryfinder.Program.Main(new[] { "-client", "-n", "ep1, lostcoast, ep2, hl1, css, dod" });
            //test with hl2,ep1
            //steamdirectoryfinder.Program.Main(new[] { "-client", "-n", "lostcoast, ep2, hl1, css, dod" });
            //test with hl2,ep1,localhost
            //steamdirectoryfinder.Program.Main(new[] { "-client", "-n", "ep2, hl1, css, dod" });
            //test with hl2,ep1,localhost,ep2
            //steamdirectoryfinder.Program.Main(new[] { "-client", "-n", "hl1, css, dod" });
            //test with hl2,ep1,localhost,ep2,hl1
            //steamdirectoryfinder.Program.Main(new[] { "-client", "-n", "css, dod" });
            //test with hl2,ep1,localhost,ep2,hl1,css
            //steamdirectoryfinder.Program.Main(new[] { "-client", "-n", "dod" });
            //test with hl2,ep1,localhost,ep2,hl1,css,dod
            //steamdirectoryfinder.Program.Main(new[] { "-client", "-n", "" });
            //test using autodetect
            //steamdirectoryfinder.Program.Main(new[] { "-client", "-n" });
        }
    }
}