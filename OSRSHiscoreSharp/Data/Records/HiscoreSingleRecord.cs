﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp.Data
{
    public class HiscoreSingleRecord
    {
        public long Rank { get; set; } = -1;
        public long Value { get; set; } = -1;
        public long Extra { get; set; } = -1;

        public static HiscoreSingleRecord FromString(string row)
        {
            HiscoreSingleRecord result = new HiscoreSingleRecord();

            var cols = row.Split(',');

            if (cols.Length < 2)
            {
                throw new Exception("(FromString) Cannot create HiscoreSingleRecord from row - not enough parameters");
            }

            result.Rank = Convert.ToInt64(cols[0]);
            result.Value = Convert.ToInt64(cols[1]);
            if (cols.Length > 2)
                result.Extra = Convert.ToInt64(cols[2]);

            return result;

        }

        public override string ToString()
        {
            return $"Rank={Rank}, Value={Value}, Extra={(Extra==-1?"N/A":Extra.ToString())}";
        }
    }
}