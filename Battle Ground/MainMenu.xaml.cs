using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Battle_Ground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {

        public MainMenu()
        {
            this.InitializeComponent();
            showCharacters();
        }

        private void showCharacters()
        {
            Character char1 = new Character();
            char1.CharImage = "Assets/char1.png";
            char1.CharName = "Character 1";
            Character char2 = new Character();
            char2.CharImage = "Assets/char1.png";
            char2.CharName = "Character 2";

            _charListView.Items.Add(char1);
            _charListView.Items.Add(char2);
            /* foreach (character in _game.CharList)
             {
                 _charListView.Items.Add(character);
             }*/
        }

        private void clickBackBtn(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void clickConfirmSelection(object sender, RoutedEventArgs e)
        {

        }

        private void togglePlayerMode(object sender, RoutedEventArgs e)
        {

        }
    }
}
