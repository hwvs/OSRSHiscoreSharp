﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OSRSHiscoreSharp.Data;
using OSRSHiscoreSharp.Util;


namespace OSRSHiscoreSharpDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HiscoreGamemode Gamemode = HiscoreGamemode.NORMAL;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void UpdateView(HiscoreCompletePlayerResult player)
        {
            var listResource = (StatsList)this.FindResource("StatsListData");

            // Clear list
            if (player == null)
            {
                foreach (var record in listResource)
                {
                    record.Value = -1;
                    record.Rank = -1;
                    record.Extra = -1;
                }
            }
            else
            {

                Func<HiscoreSingleRecordView.RecordCategory, Dictionary<string, HiscoreSingleRecord>, bool> updateCategory = (category, records) =>
                {
                    foreach (var record in listResource.Where(r => r.Category == category))
                    {
                        var newRecord = records[record.PropertyName];
                        record.Value = newRecord.Value;
                        record.Rank = newRecord.Rank;
                        record.Extra = newRecord.Extra;
                    }

                    return true;
                };

                // Update each individual category
                updateCategory(HiscoreSingleRecordView.RecordCategory.Skills, player.Records.Skills);
                updateCategory(HiscoreSingleRecordView.RecordCategory.Bounty_Hunter, player.Records.BountyHunter);
                updateCategory(HiscoreSingleRecordView.RecordCategory.League, player.Records.League);
                updateCategory(HiscoreSingleRecordView.RecordCategory.Clues, player.Records.Clues);
                updateCategory(HiscoreSingleRecordView.RecordCategory.Minigames, player.Records.Minigames);
                updateCategory(HiscoreSingleRecordView.RecordCategory.Bosses, player.Records.Bosses);
            }
        }

        private async void OnClickLookup(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait; // set the cursor to loading spinner
            Stopwatch sw = new Stopwatch();
            sw.Start();
            HiscoreCompletePlayerResult player = null;
            try
            {
                string username = tbUsername.Text;

                player = await HiscoreLookup.LookupPlayerStats(username, this.Gamemode);

                if (player == null)
                {
                    lbStatus.Text = $"Error: Player \"{username}\" cannot be found for this gamemode";
                }
                else
                {
                    //lbDebug.Text = player.ToString();

                    lbStatus.Text = $"Lookup completed in {sw.ElapsedMilliseconds} ms";
                }

            }
            catch (Exception ex)
            {
                lbStatus.Text = $"Error: {ex.Message}";
            }

            UpdateView(player);

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow; // set the cursor back to arrow
        }

        private void OnClickGamemode(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string code = (string)button.Tag;

            var newGamemode = HiscoreGamemode.ALL.FirstOrDefault(g => g.Tag.Equals(code));
            Debug.Assert(newGamemode != null);

            Gamemode = newGamemode;
            lbGamemode.Content = newGamemode.Name;

        }
    }
}
