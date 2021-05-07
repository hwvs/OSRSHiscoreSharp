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

            // Load all skills
            foreach (string skill in HiscoreConstants.SKILL_NAMES)
            {
                result.Skills[skill] = queue.Dequeue();
            }

            return result;
        }

    }
}
