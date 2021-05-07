using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp.Data
{
    internal class HiscoreConstants
    {
        internal const string URL_HISCORES_PREFIX = "https://secure.runescape.com/m=hiscore_oldschool";
        internal const string URL_HISCORES_PATH = "/index_lite.ws";
        internal const string URL_HISCORES_PARAM = "player";
        

        internal static readonly string[] SKILL_NAMES = new string[] {
            "overall",
            "attack",
            "defence",
            "strength",
            "hitpoints",
            "ranged",
            "prayer",
            "magic",
            "cooking",
            "woodcutting",
            "fletching",
            "fishing",
            "firemaking",
            "crafting",
            "smithing",
            "mining",
            "herblore",
            "agility",
            "thieving",
            "slayer",
            "farming",
            "runecraft",
            "hunter",
            "construction",
        };
    }
}
