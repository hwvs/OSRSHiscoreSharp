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


        public override string ToString()
        {
            return $"Name: {Name}\nGamemode: {Gamemode}\n\n-- Skills --\n{String.Join("\n",Skills.Keys.Select(k=> $"{k}: {Skills[k].ToString()}").ToArray())}";
        }
    }
}
