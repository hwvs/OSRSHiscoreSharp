using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp.Data
{
    public class HiscoreDataParserUtility
    {


        public static HiscoreCompletePlayerResult CreatePlayerRecordFromCSV(string csvString)
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

        private static HiscoreCompletePlayerResult ConvertListOfRecordsToPlayerRecord(List<HiscoreSingleRecord> singleRecords)
        {
            HiscoreCompletePlayerResult result = new HiscoreCompletePlayerResult();

            // What we're doing is loading everything into a queue (FIFO) and then reading them one-by-one into the arrays for
            // the player. This has the effect of loading everything in the CSV from top-to-bottom, with each row being loaded
            // in as a HiscoreSingleRecord object.
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
            dequeueViaArray(result.Records.Skills, HiscoreConstants.SKILL_NAMES);
            // Load Leaguepoints
            result.Records.LeaguePoints = queue.Dequeue();
            // Load all BountyHunter
            dequeueViaArray(result.Records.BountyHunter, HiscoreConstants.BOUNTY_HUNTER);
            // Load all clues
            dequeueViaArray(result.Records.Clues, HiscoreConstants.CLUE_NAMES);
            // Load all minigames
            dequeueViaArray(result.Records.Minigames, HiscoreConstants.MINIGAME_NAMES);
            // Load all bosses
            dequeueViaArray(result.Records.Bosses, HiscoreConstants.BOSS_NAMES);


            return result;
        }

    }
}
