# OSRSHiscoreSharp
Easy-to-use async C# package to lookup OSRS player hiscores. If you use this in your project, please ⭐star this repo and include a link in your credits ❤️

[![.NET](https://github.com/hwvs/OSRSHiscoreSharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hwvs/OSRSHiscoreSharp/actions/workflows/dotnet.yml)

Usage:
```csharp
// (Inside try-catch block)
{
  // Lookup the player on the hiscores
  var player = await HiscoreLookup.LookupPlayerStats("dedwilson", HiscoreGamemode.NORMAL);
  // Grab the total level of the player
  var totalLevel = player.Records.Skills["overall"].Value;
}
```

Check `OSRSHiscoreSharp.Data.HiscoreConstants` for record index values

```csharp

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
            "runecrafting",
            "hunter",
            "construction",
        };

        public static readonly string[] LEAGUE_NAMES = new string[] {
            "leaguePoints"
        };

        public static readonly string[] BOUNTY_HUNTER_NAMES = new string[] {
            "bhHunter",
            "bhRogue",
        };

        public static readonly string[] MINIGAME_NAMES = new string[] {
            "lms",
            "soulwars",
        };

        public static readonly string[] CLUE_NAMES = new string[] {
            "clueAll",
            "clueBeginner",
            "clueEasy",
            "clueMedium",
            "clueHard",
            "clueElite",
            "clueMaster"
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
```
