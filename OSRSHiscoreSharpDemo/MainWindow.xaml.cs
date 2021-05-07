using System;
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
using OSRSHiscoreSharp.Util;


namespace OSRSHiscoreSharpDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnClickLookup(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                string username = tbUsername.Text;
                HiscoreGamemode gamemode = HiscoreGamemode.NORMAL;

                var player = await HiscoreLookup.LookupPlayerStats(username, gamemode);

                if (player == null)
                {
                    lbStatus.Text = $"Error: Player \"{username}\" cannot be found for this gamemode";
                }
                else
                {
                    lbDebug.Text = player.ToString();

                    lbStatus.Text = $"Lookup completed in {sw.ElapsedMilliseconds} ms";
                }

            }
            catch (Exception ex)
            {
                lbStatus.Text = $"Error: {ex.Message}";
            }
        }
    }
}
