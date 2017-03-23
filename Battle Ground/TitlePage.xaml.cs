using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.IO;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Battle_Ground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TitlePage : Page
    {
        private StreamReader scorefile;
        public TitlePage()
        {
            this.InitializeComponent();
        }

        private void _playBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainMenu));
        }

        private async void showScoreBoard(object sender, RoutedEventArgs e)
        {

            
            //Yet to implement method to show scoreboard
            MessageDialog msg = new MessageDialog("TO-DO:Show ScoreBoard");
            await msg.ShowAsync();
        }
    }
}
