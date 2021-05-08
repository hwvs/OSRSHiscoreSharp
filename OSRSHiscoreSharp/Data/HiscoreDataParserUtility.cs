using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp.Data
{
    public class HiscoreDataParserUtility
    {


        public static HiscoreCompletePlayerRecord CreatePlayerRecordFromCSV(string csvString)
        {
            var list = HiscoreDataParserUtility.ParseDataIntoList(csvString);
            var player = HiscoreDataParserUtility.ConvertListOfRecordsToPlayerRecord(list);

            return player;
        }


        private static List<HiscoreSingleRecord> ParseDataIntoList(string csvString)
        {
            // Split it by each newline, then for each row create a new HiscoreSingleRecord object into a list which is returned
            return csvString.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(row => HiscoreSingleRecord.FromString(row))
                .ToList();
        }

        private static HiscoreCompletePlayerRecord ConvertListOfRecordsToPlayerRecord(List<HiscoreSingleRecord> singleRecords)
        {
            HiscoreCompletePlayerRecord result = new HiscoreCompletePlayerRecord();

            var queue = new Queue<HiscoreSingleRecord>(singleRecords);

            Func<Dictionary<string, HiscoreSingleRecord>, string[], bool> dequeueViaArray = (target,source) =>
            {
                foreach (string key in source)
                {
                    target[key] = queue.Dequeue();
                }
                return true;
            };

            // Load all skills
            dequeueViaArray(result.Skills, HiscoreConstants.SKILL_NAMES);
            // Load Leaguepoints
            result.LeaguePoints = queue.Dequeue();
            // Load all BountyHunter
            dequeueViaArray(result.BountyHunter, HiscoreConstants.BOUNTY_HUNTER);
            // Load all clues
            dequeueViaArray(result.Clues, HiscoreConstants.CLUE_NAMES);
            // Load all minigames
            dequeueViaArray(result.Minigames, HiscoreConstants.MINIGAME_NAMES);
            // Load all bosses
            dequeueViaArray(result.Bosses, HiscoreConstants.BOSS_NAMES);


            return result;
        }

    }
}
