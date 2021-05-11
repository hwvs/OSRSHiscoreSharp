using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp.Data
{
    public class HiscoreConstants
    {
        internal const string URL_HISCORES_PREFIX = "https://secure.runescape.com/m=hiscore_oldschool";
        internal const string URL_HISCORES_PATH = "/index_lite.ws";
        internal const string URL_HISCORES_PARAM = "player";


        public static readonly string[] SKILL_NAMES = new string[] {
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

        public static readonly string[] BOUNTY_HUNTER = new string[] {
            "hunter",
            "rogue",
        };

        public static readonly string[] MINIGAME_NAMES = new string[] {
            "lms",
            "soulwars",
        };

        public static readonly string[] CLUE_NAMES = new string[] {
            "all",
            "beginner",
            "easy",
            "medium",
            "hard",
            "elite",
            "master"
        };

        public static readonly string[] BOSS_NAMES = new string[] {
            "abyssalSire",
            "alchemicalHydra",
            "barrows",
            "bryophyta",
            "callisto",
            "cerberus",
            "chambersOfXeric",
            "chambersOfXericChallengeMode",
            "chaosElemental",
            "chaosFanatic",
            "commanderZilyana",
            "corporealBeast",
            "crazyArchaeologist",
            "dagannothPrime",
            "dagannothRex",
            "dagannothSupreme",
            "derangedArchaeologist",
            "generalGraardor",
            "giantMole",
            "grotesqueGuardians",
            "hespori",
            "kalphiteQueen",
            "kingBlackDragon",
            "kraken",
            "kreeArra",
            "krilTsutsaroth",
            "mimic",
            "nightmare",
            "obor",
            "sarachnis",
            "scorpia",
            "skotizo",
            "tempoross",
            "gauntlet",
            "corruptedGauntlet",
            "theatreOfBlood",
            "thermonuclearSmokeDevil",
            "tzKalZuk",
            "tzTokJad",
            "venenatis",
            "vetion",
            "vorkath",
            "wintertodt",
            "zalcano",
            "zulrah",
        };

    }
}
