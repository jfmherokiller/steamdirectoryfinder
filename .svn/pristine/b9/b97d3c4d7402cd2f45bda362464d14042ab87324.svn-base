using Steam4Net;
using System;

namespace steamdirectoryfinder
{
    public static class Steamstuff
    {
        private static int Pipe { get; set; }

        public static SteamApps005 SteamApps { get; private set; }

        public static SteamApps001 SteamApps2 { get; private set; }

        private static SteamClient009 SteamClient { get; set; }

        public static SteamUser016 SteamUser { get; private set; }

        private static int User { get; set; }

        public static void InitClient()
        {
            if (!Steamworks.Load())
            {
                throw new SteamException("Unable to load steamclient library.");
            }
            if (!Steamworks.LoadSteam())
            {
                throw new SteamException("Unable to load steam.");
            }
            SetupSteamInterfaces();
        }

        public static void InitServer(string loadpath)
        {
            if (!Steamworks.LoadSteamClientF(loadpath))
            {
                throw new SteamException("Unable to load steamclient library.");
            }
            if (!Steamworks.LoadSteamF(loadpath))
            {
                throw new SteamException("Unable to load steam.");
            }
            SetupSteamInterfaces();
        }

        public static void Shutdown()
        {
            CallbackDispatcher.StopDispatchThread(Pipe);

            if (SteamClient != null && User != 0)
            {
                SteamClient.ReleaseUser(Pipe, User);
            }

            if (SteamClient != null && Pipe != 0)
            {
                SteamClient.BReleaseSteamPipe(Pipe);
            }
        }

        private static void SetupSteamInterfaces()
        {
            if (SteamClient == null)
            {
                SteamClient = Steamworks.CreateInterface<SteamClient009>();

                if (SteamClient == null)
                {
                    throw new SteamException("Unable to get ISteamClient interface.");
                }
            }

            if (Pipe == 0)
            {
                Pipe = SteamClient.CreateSteamPipe();

                if (Pipe == 0)
                {
                    throw new SteamException("Unable to create steam pipe.");
                }
            }

            if (User == 0)
            {
                User = SteamClient.ConnectToGlobalUser(Pipe);

                if (User == 0)
                {
                    throw new SteamException("Unable to connect to global user.");
                }
            }
            if (SteamApps == null)
            {
                SteamApps = SteamClient.GetISteamApps<SteamApps005>(User, Pipe);

                if (SteamApps == null)
                {
                    throw new SteamException("Unable to get ISteamApps interface.");
                }
            }
            if (SteamApps2 == null)
            {
                SteamApps2 = SteamClient.GetISteamApps<SteamApps001>(User, Pipe);

                if (SteamApps2 == null)
                {
                    throw new SteamException("Unable to get ISteamApps interface.");
                }
            }
            SteamUser = SteamClient.GetISteamUser<SteamUser016>(User, Pipe);
            if (SteamUser == null)
            {
                Console.WriteLine(@"steamuser is null !");
            }
        }
    }

    [Serializable]
    internal class SteamException : Exception
    {
        public SteamException(string msg)
            : base(msg)
        {
        }
    }
}