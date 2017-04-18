using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Battle_Ground
{
    /// <summary>
    /// Written by Harrison
    /// </summary>
    public sealed partial class TitlePage : Page
    {

        //private StreamReader scorefile;
        //Contains the list of rules for this game;
        private string rules;
        private string _scoreFile;

        public TitlePage()
        {
            this.InitializeComponent();
            loadRules();

        }

        private void loadRules()
        {
            rules = $"The rules of this game are as follows\n 1.Choose 1 or 2 players, if 1 player you will be matched against the PC\n 2.Select a character for each player, or choose one at random.\n 3.Each player will choose an attack. \n 4.Attacks will be executed after both players have chosen an attack.\n 5.First player who's character's health reaches 0 loses.";
        }

        private void _playBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainMenu));
        }

        /// <summary>
        /// Displays the scoreboard for this application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void showScoreBoard(object sender, RoutedEventArgs e)
        {
            readBattleLogs();

            ContentDialog scoreBoard = new ContentDialog
            {
                Title = "Score Board",
                Content = $"{_scoreFile}",
                PrimaryButtonText = "Exit Scoreboard",



            };
            await scoreBoard.ShowAsync();
            _scoreFile = "";


        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
        /// <summary>
        /// Reads battle logs to display how many times each character has won a game
        /// </summary>
        public void readBattleLogs()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "BattleLogs");
            string[] logs;
            if (Directory.Exists(path))
            {
                logs = Directory.GetFiles(path);
                foreach (string log in logs)
                    using (StreamReader reader = new StreamReader(new FileStream(log, FileMode.Open)))
                    {
                        if (log.Contains("NumSaves.dat") != true)
                        {
                            _scoreFile += $"{reader.ReadLine()}\n{reader.ReadLine()}\n\n";
                        }
                    }
            }







        }
    }
}
