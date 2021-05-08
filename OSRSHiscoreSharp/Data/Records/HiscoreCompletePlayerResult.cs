using OSRSHiscoreSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp.Data
{
    public class HiscoreCompletePlayerResult
    {

        public string Name { get; internal set; }
        public HiscoreGamemode Gamemode { get; internal set; }

        public HiscoreRecords Records = new HiscoreRecords();

        public class HiscoreRecords
        {
            public Dictionary<string, HiscoreSingleRecord> Skills { get; set; } = new Dictionary<string, HiscoreSingleRecord>();
            public Dictionary<string, HiscoreSingleRecord> Minigames { get; set; } = new Dictionary<string, HiscoreSingleRecord>();

            public HiscoreSingleRecord LeaguePoints = new HiscoreSingleRecord();

            public Dictionary<string, HiscoreSingleRecord> BountyHunter { get; set; } = new Dictionary<string, HiscoreSingleRecord>();
            public Dictionary<string, HiscoreSingleRecord> Clues { get; set; } = new Dictionary<string, HiscoreSingleRecord>();
            public Dictionary<string, HiscoreSingleRecord> Bosses { get; set; } = new Dictionary<string, HiscoreSingleRecord>();
        }


        public override string ToString()
        {
            Func<Dictionary<string, HiscoreSingleRecord>, string> ConvertRecordsToString = (record) =>
            {
                return String.Join("\n", record.Keys.Select(k => $"{k}: {record[k].ToString()}").ToArray());
            };

            return $"Name: {Name}\n" +
                $"Gamemode: {Gamemode}\n\n" +
                $"-- Skills --\n{ConvertRecordsToString(Records.Skills)}\n" +
                $"-- League --\nLeague Points: {Records.LeaguePoints.ToString()}\n" +
                $"-- Minigames --\n{ConvertRecordsToString(Records.Minigames)}\n" +
                $"-- BountyHunter --\n{ConvertRecordsToString(Records.BountyHunter)}\n" +
                $"-- Clues --\n{ConvertRecordsToString(Records.Clues)}\n" +
                $"-- Bosses --\n{ConvertRecordsToString(Records.Bosses)}\n" +
                "";
        }


    }
}
