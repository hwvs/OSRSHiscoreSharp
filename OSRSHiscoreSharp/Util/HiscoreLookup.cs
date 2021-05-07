using OSRSHiscoreSharp;
using OSRSHiscoreSharp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp.Util
{
    public class HiscoreGamemode
    {
        public static HiscoreGamemode NORMAL = new HiscoreGamemode("");
        public static HiscoreGamemode IRONMAN = new HiscoreGamemode("_ironman");
        public static HiscoreGamemode IRONMAN_ULTIMATE = new HiscoreGamemode("_ultimate");
        public static HiscoreGamemode IRONMAN_HARDCORE = new HiscoreGamemode("_hardcore_ironman");
        public static HiscoreGamemode DMM = new HiscoreGamemode("_deadman");
        public static HiscoreGamemode DMM_SEASONAL = new HiscoreGamemode("_seasonal");
        public static HiscoreGamemode DMM_TOURNAMENT = new HiscoreGamemode("_tournament");

        public string URL { get; private set; }
        public HiscoreGamemode(string URL)
        {
            this.URL = URL;
        }
    }
    public class HiscoreLookup
    {
        /// <summary>
        /// Performs a lookup a player and returns the results as an HiscoreCompletePlayerRecord object
        /// </summary>
        /// <param name="playername">The name of the player as a string</param>
        /// <param name="gamemode">The type of account to lookup, as a HiscoreGamemode object</param>
        /// <returns>Returns HiscoreCompletePlayerRecord on success, null on failure, throws exception if error</returns>
        public async static Task<HiscoreCompletePlayerRecord> LookupPlayerStats(string playername, HiscoreGamemode gamemode = null)
        {
            if (gamemode == null)
                gamemode = HiscoreGamemode.NORMAL;

            string uri = $"{HiscoreConstants.URL_HISCORES_PREFIX}{gamemode.URL}{HiscoreConstants.URL_HISCORES_PATH}?{HiscoreConstants.URL_HISCORES_PARAM}={Uri.EscapeDataString(playername)}";
            string data;
            try
            {
                data = await Web.GETRequest(uri);

                // Extra sanity check
                if (data.Length == 0 || data.Contains("<html>"))
                {
                    System.Diagnostics.Debugger.Break();
                    throw new Exception();
                }
            }
            catch (System.Net.WebException ex)
            {
                if(ex.Message.Contains("404"))
                    return null;
                else
                    throw new Exception("Error looking up user, either network error or player doesn't exist");
            }

            var list = HiscoreDataParserFactory.ParseDataIntoList(data);
            var player = HiscoreDataParserFactory.ConvertListOfRecordsToPlayerRecord(list);

            return player;
        }
    }
}
