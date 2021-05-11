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
        // The C# style guide doesn't say constants should be capitalized, but I think they should because it enhances
        // readability. H*ck off, Microsoft.
        public readonly static HiscoreGamemode NORMAL = new HiscoreGamemode("Normal","");
        public readonly static HiscoreGamemode IRONMAN = new HiscoreGamemode("Ironman", "_ironman");
        public readonly static HiscoreGamemode IRONMAN_ULTIMATE = new HiscoreGamemode("Ultimate Ironman", "_ultimate");
        public readonly static HiscoreGamemode IRONMAN_HARDCORE = new HiscoreGamemode("Hardcore Ironman", "_hardcore_ironman");
        public readonly static HiscoreGamemode DMM = new HiscoreGamemode("Deadman Mode", "_deadman");
        public readonly static HiscoreGamemode DMM_SEASONAL = new HiscoreGamemode("Deadman Mode Seasonal", "_seasonal");
        public readonly static HiscoreGamemode DMM_TOURNAMENT = new HiscoreGamemode("Deadman Mode Tournament", "_tournament");

        public string Name { get; private set; }
        public string URL { get; private set; }
        public HiscoreGamemode(string name, string URL)
        {
            this.Name = name;
            this.URL = URL;
        }

        public override string ToString()
        {
            return Name;
        }
    }
    public class HiscoreLookup
    {
        /// <summary>
        /// Performs a lookup a player and returns the results as an HiscoreCompletePlayerRecord object
        /// </summary>
        /// <param name="playerName">The name of the player as a string</param>
        /// <param name="gamemode">The type of account to lookup, as a HiscoreGamemode object (EG: HiscoreGamemode.IRONMAN)</param>
        /// <returns>Returns HiscoreCompletePlayerRecord on success, null on failure, throws exception if error</returns>
        public async static Task<HiscoreCompletePlayerResult> LookupPlayerStats(string playerName, HiscoreGamemode gamemode = null)
        {
            if (gamemode == null)
                gamemode = HiscoreGamemode.NORMAL;

            string uri = $"{HiscoreConstants.URL_HISCORES_PREFIX}{gamemode.URL}{HiscoreConstants.URL_HISCORES_PATH}?{HiscoreConstants.URL_HISCORES_PARAM}={Uri.EscapeDataString(playerName)}";
            string data;
            try
            {
                data = await Web.GETRequest(uri);

                // Extra sanity check
                if (data.Length == 0 || data.Contains("<html>"))
                {
                    //System.Diagnostics.Debugger.Break();
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

            var player = HiscoreDataParserUtility.CreatePlayerRecordFromCSV(data);

            player.Name = playerName;
            player.Gamemode = gamemode;

            return player;
        }
    }
}
