using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp.Data
{
    public class HiscoreDataParserFactory
    {
        public static List<HiscoreSingleRecord> ParseDataIntoList(string csvString)
        {
            // Split it by each newline, then for each row create a new HiscoreSingleRecord object into a list which is returned
            return csvString.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(row => HiscoreSingleRecord.FromString(row))
                .ToList();
        }

        public static HiscoreCompletePlayerRecord ConvertListOfRecordsToPlayerRecord(List<HiscoreSingleRecord> singleRecords)
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

            return result;
        }

    }
}
