using Battle_Ground.Characters;
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

namespace Battle_Ground.Presentation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Gameplay : Page
    {
        private Game _game;
        public Gameplay()
        {
            this.InitializeComponent();
            // Initalize navigation context variable
            _game = null;

            // Create character classes
            Adventurer _aventurer = new Adventurer();
            BlueLizard _blueLizard = new BlueLizard();

            // Set character images based on character type sources
            _imgChar1.Source = new BitmapImage(new Uri(_aventurer.CharImageSource));
            _imgChar2 .Source= new BitmapImage(new Uri(_blueLizard.CharImageSource));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Navigation context variable
            _game = e.Parameter as Game;

            // Display text of chosen nicknames and character names
            _txtPlayer1Name.Text = _game.Player1.Nickname;
            _txtPlayer2Name.Text = _game.Player2.Nickname;
            _txtChar1Name.Text = _game.Player1.Character.CharName;
            _txtChar2Name.Text = _game.Player2.Character.CharName;
            
        }

        /// <summary>
        /// Allows usesr to pick an attack, disables other buttons for a player after they have clicked one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAttackChosen(object sender, RoutedEventArgs e)
        {
            // Disables all attack buttons for player 1 except the one chosen.
            if (sender == _btnPlayer1Attack1 || sender == _btnPlayer1Attack2 || sender == _btnPlayer1Attack3 || sender == _btnPlayer1Attack4)
            {
                _btnPlayer1Attack1.IsEnabled = false;
                _btnPlayer1Attack2.IsEnabled = false;
                _btnPlayer1Attack3.IsEnabled = false;
                _btnPlayer1Attack4.IsEnabled = false;

                if (sender == _btnPlayer1Attack1)
                {
                }
                else if (sender == _btnPlayer1Attack2)
                {
                }
                else if (sender == _btnPlayer1Attack3)
                {
                }
                else if (sender == _btnPlayer1Attack4)
                {
                }
            }


            // Disables all attack buttons for player 2 except the one chosen.
            if (sender == _btnPlayer2Attack1 || sender == _btnPlayer2Attack2 || sender == _btnPlayer2Attack3 || sender == _btnPlayer2Attack4)
            {
                _btnPlayer2Attack1.IsEnabled = false;
                _btnPlayer2Attack2.IsEnabled = false;
                _btnPlayer2Attack3.IsEnabled = false;
                _btnPlayer2Attack4.IsEnabled = false;

                // Calls method that correspond to the chosen characters attack denoted by the button selected.
                if (sender == _btnPlayer2Attack1)
                {
                    _game.Player1.Character.Bite(_game.Player1, _game.Player2);
                }
                else if (sender == _btnPlayer2Attack2)
                {
                }
                else if (sender == _btnPlayer2Attack3)
                {
                }
                else if (sender == _btnPlayer2Attack4)
                {
                }
            }
        }
    }
}
