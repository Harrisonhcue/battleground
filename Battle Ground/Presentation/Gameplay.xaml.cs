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
        // Variable that stores navigation context
        private Game _game;

        public Gameplay()
        {
            // Initalize navigation context variable
            _game = null;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Provide information to context variable
            _game = e.Parameter as Game;

            // Display text of chosen nicknames and character names
            _txtPlayer1Name.Text = _game.Player1.Nickname;
            _txtPlayer2Name.Text = _game.Player2.Nickname;
            _txtChar1Name.Text = _game.Player1.Character.CharName;
            _txtChar2Name.Text = _game.Player2.Character.CharName;
            _txtChar1Health.Text = _game.Player1.Character.Health.ToString();
            _txtChar2Health.Text = _game.Player2.Character.Health.ToString();

            // Set character images based on character type sources
            _imgChar1.Source = new BitmapImage(new Uri(_game.Player1.Character.CharImageSource));
            _imgChar2.Source = new BitmapImage(new Uri(_game.Player2.Character.CharImageSource));
        }

        /// <summary>
        /// Displays the updated health of each character.
        /// </summary>
        public void UpdateLabels()
        {
            _txtChar1Health.Text = _game.Player1.Character.Health.ToString();
            _txtChar2Health.Text = _game.Player2.Character.Health.ToString();
        }

        /// <summary>
        /// Changes if the attack buttons can be clicked or not
        /// </summary>
        /// <param name="playerNum">Player who's button's states will be changed</param>
        /// <param name="buttonState">Determines whether the buttons will be disabled or enabled</param>
        public void ChangeButtonState(int playerNum, bool buttonState)
        {
           if (playerNum == 1)
            {
                _btnPlayer1Attack1.IsEnabled = buttonState;
                _btnPlayer1Attack2.IsEnabled = buttonState;
                _btnPlayer1Attack3.IsEnabled = buttonState;
                _btnPlayer1Attack4.IsEnabled = buttonState;
            }
            else if (playerNum == 2)
            {
                _btnPlayer2Attack1.IsEnabled = buttonState;
                _btnPlayer2Attack2.IsEnabled = buttonState;
                _btnPlayer2Attack3.IsEnabled = buttonState;
                _btnPlayer2Attack4.IsEnabled = buttonState;
            }

        }

        /// <summary>
        /// Allows usesr to pick an attack, disables other buttons for a player after they have clicked one, updates the health of each character and displays it accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAttackChosen(object sender, RoutedEventArgs e)
        {
            // Determines which player has chosen an attack.
            if (sender == _btnPlayer1Attack1 || sender == _btnPlayer1Attack2 || sender == _btnPlayer1Attack3 || sender == _btnPlayer1Attack4)
            {
                // Disables all attack buttons for player 1
                ChangeButtonState(1, false);

                // Determines which attack the player has chosen. Calls method that correspond to the chosen characters attack denoted by the button selected.
                if (sender == _btnPlayer1Attack1)
                {
                    _game.Player1.Character.Attack1(_game.Player1, _game.Player2);
                }
                else if (sender == _btnPlayer1Attack2)
                {
                    _game.Player1.Character.Attack1(_game.Player1, _game.Player2);
                }
                else if (sender == _btnPlayer1Attack3)
                {
                    _game.Player1.Character.Attack1(_game.Player1, _game.Player2);
                }
                else if (sender == _btnPlayer1Attack4)
                {
                    _game.Player1.Character.Attack1(_game.Player1, _game.Player2);
                }

                // Updates the health of the characters
                UpdateLabels();
            }
            
            if (sender == _btnPlayer2Attack1 || sender == _btnPlayer2Attack2 || sender == _btnPlayer2Attack3 || sender == _btnPlayer2Attack4)
            {
                // Disables all attack buttons for player 2
                ChangeButtonState(2, false);

                // Determines which attack the player has chosen. Calls method that correspond to the chosen characters attack denoted by the button selected.
                if (sender == _btnPlayer2Attack1)
                {
                    _game.Player2.Character.Attack1(_game.Player2, _game.Player1);
                }
                else if (sender == _btnPlayer2Attack2)
                {
                    _game.Player2.Character.Attack2(_game.Player2, _game.Player1);
                }
                else if (sender == _btnPlayer2Attack3)
                {
                    _game.Player2.Character.Attack3(_game.Player2, _game.Player1);
                }
                else if (sender == _btnPlayer2Attack4)
                {
                    _game.Player2.Character.Attack4(_game.Player2, _game.Player1);
                }

                // Updates the health of the characters
                UpdateLabels();
            }
        }
    }
}
