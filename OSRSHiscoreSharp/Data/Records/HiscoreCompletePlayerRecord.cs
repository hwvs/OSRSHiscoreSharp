using OSRSHiscoreSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp.Data
{
    public class HiscoreCompletePlayerRecord
    {

        public string Name { get; internal set; }
        public HiscoreGamemode Gamemode { get; internal set; }

        
        public Dictionary<string, HiscoreSingleRecord> Skills { get; set; } = new Dictionary<string, HiscoreSingleRecord>();
        public Dictionary<string, HiscoreSingleRecord> Minigames { get; set; } = new Dictionary<string, HiscoreSingleRecord>();

        public HiscoreSingleRecord LeaguePoints = new HiscoreSingleRecord();

        public Dictionary<string, HiscoreSingleRecord> BountyHunter { get; set; } = new Dictionary<string, HiscoreSingleRecord>();
        public Dictionary<string, HiscoreSingleRecord> Clues { get; set; } = new Dictionary<string, HiscoreSingleRecord>();
        public Dictionary<string, HiscoreSingleRecord> Bosses { get; set; } = new Dictionary<string, HiscoreSingleRecord>();


        public override string ToString()
        {
            Func<Dictionary<string, HiscoreSingleRecord>, string> ConvertRecordsToString = (record) =>
            {
                return String.Join("\n", record.Keys.Select(k => $"{k}: {record[k].ToString()}").ToArray());
            };

            return $"Name: {Name}\n" +
                $"Gamemode: {Gamemode}\n\n" +
                $"-- Skills --\n{ConvertRecordsToString(Skills)}\n" +
                $"-- League --\nLeague Points: {LeaguePoints.ToString()}\n" +
                $"-- Minigames --\n{ConvertRecordsToString(Minigames)}\n" +
                $"-- BountyHunter --\n{ConvertRecordsToString(BountyHunter)}\n" +
                $"-- Clues --\n{ConvertRecordsToString(Clues)}\n" +
                $"-- Bosses --\n{ConvertRecordsToString(Bosses)}\n" +
                "";
        }


    }
}
