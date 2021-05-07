using OSRSHiscoreSharp.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using Xunit;
using OSRSHiscoreSharp.Util;

namespace OSRSHiscoreSharp
{
    public class Testing
    {
        public static async Task Main(string[] args)
        {
            var testing = new Testing();
            await testing.TestMethod1();
            Console.ReadLine();
        }

        [Fact]
        public async Task TestMethod1()
        {
            var player = await HiscoreLookup.LookupPlayerStats("dedwilson", HiscoreGamemode.NORMAL);

            Assert.True(player.Skills.Count == 24, "Incorrect number of player skills");
            Assert.True(player.Skills["overall"].Extra == 4600000000, "Incorrect total xp");


            Debug.WriteLine(player.ToString());
            Console.WriteLine(player.ToString());
        }
    }
}
