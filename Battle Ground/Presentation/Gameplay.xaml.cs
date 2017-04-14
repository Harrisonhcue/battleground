using Battle_Ground.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private bool _player1AttackChosen;
        private bool _player2AttackChosen;
        private int _player1AttackNum = 0;
        private int _player2AttackNum = 0;

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
        /// Allows users to pick an attack, disables other buttons for a player after they have clicked one, updates the health of each character and displays it accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAttackChosen(object sender, RoutedEventArgs e)
        {
            // Determines which player has chosen an attack.
            if (sender == _btnPlayer1Attack1 || sender == _btnPlayer1Attack2 || sender == _btnPlayer1Attack3 || sender == _btnPlayer1Attack4)
            {
                // Determines which attack the player has chosen. Call method that waits until both characters have chosen an attack and then executes both at the same time.
                if (sender == _btnPlayer1Attack1)
                {
                    // Sends information of which player has chosen an attack, and which attack they have chosen.
                    BattleState(1, 1);
                }
                else if (sender == _btnPlayer1Attack2)
                {
                    BattleState(1, 2);
                }
                else if (sender == _btnPlayer1Attack3)
                {
                    BattleState(1, 3);
                }
                else if (sender == _btnPlayer1Attack4)
                {
                    BattleState(1, 4);
                }

                // Updates the health of the characters
                UpdateLabels();
            }

            if (sender == _btnPlayer2Attack1 || sender == _btnPlayer2Attack2 || sender == _btnPlayer2Attack3 || sender == _btnPlayer2Attack4)
            {
                // Determines which attack the player has chosen. Call method that waits until both characters have chosen an attack and then executes both at the same time.
                if (sender == _btnPlayer2Attack1)
                {
                    // Sends information of which player has chosen an attack, and which attack they have chosen.
                    BattleState(2, 1);
                }
                else if (sender == _btnPlayer2Attack2)
                {
                    BattleState(2, 2);
                }
                else if (sender == _btnPlayer2Attack3)
                {
                    BattleState(2, 3);
                }
                else if (sender == _btnPlayer2Attack4)
                {
                    BattleState(2, 4);
                }

                // Updates the health of the characters
                UpdateLabels();
            }
        }

        /// <summary>
        /// Method that waits until both characters have chosen an attack and then executes both at the same time. Reenables the attack buttons.
        /// </summary>
        /// <param name="playerNum"></param>
        /// <param name="attackNum"></param>
        public void BattleState(int playerNum, int attackNum)
        {
            // Provides information to local variables based on which player has chosen their attack. Disables attack buttons for player that has chosen an attack.
            if (playerNum == 1)
            {
                // Disables all attack buttons for player 1
                ChangeButtonState(1, false);
                _player1AttackChosen = true;
                _player1AttackNum = attackNum;
            }
            else if (playerNum == 2)
            {
                // Disables all attack buttons for player 2
                ChangeButtonState(2, false);
                _player2AttackChosen = true;
                _player2AttackNum = attackNum;
            }
            
            // If both players have chosen an attack, call method that executes each player's attack chosen.
            if (_player1AttackChosen == true & _player2AttackChosen == true)
            {
               switch(_player1AttackNum)
                {
                    case 1:
                        _game.Player1.Character.Attack1(_game.Player1, _game.Player2);
                        break;
                    case 2:
                        _game.Player1.Character.Attack2(_game.Player1, _game.Player2);
                        break;
                    case 3:
                        _game.Player1.Character.Attack3(_game.Player1, _game.Player2);
                        break;
                    case 4:
                        _game.Player1.Character.Attack4(_game.Player1, _game.Player2);
                        break;
                }

                switch (_player2AttackNum)
                {
                    case 1:
                        _game.Player2.Character.Attack1(_game.Player2, _game.Player1);
                        break;
                    case 2:
                        _game.Player2.Character.Attack2(_game.Player2, _game.Player1);
                        break;
                    case 3:
                        _game.Player2.Character.Attack3(_game.Player2, _game.Player1);
                        break;
                    case 4:
                        _game.Player2.Character.Attack4(_game.Player2, _game.Player1);
                        break;
                }

                CheckWin();

                // Return both attacks to unchosen.
                _player1AttackChosen = false;
                _player2AttackChosen = false;

                // Reenables both player's attack buttons after they have both chosen an attack and their attacks have been executed.
                ChangeButtonState(1, true);
                ChangeButtonState(2, true);
            }
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
        /// Returns outcome of the game if either character's health has reached 0.
        /// </summary>
        /// <returns></returns>
        public void CheckWin()
        {
            string winner = "";
            if (_game.Player1.Character.Health <= 0 & _game.Player2.Character.Health <= 0)
            {
                winner = "Tie";
                EndGame(winner);
            }

            else if (_game.Player1.Character.Health <=0)
            {
                winner = "Player 2";
                EndGame(winner);
            }

            else if (_game.Player2.Character.Health <= 0)
            {
                winner = "Player 1";
                EndGame(winner);
            }
            /*else if (_game.Player1.Character.Health > 0 & _game.Player2.Character.Health > 0)
            {
            }*/
        }

        public void EndGame(string winner)
        {
            if (winner == "Tie")
            {
            }
            else if (winner == "Player 1")
            {
            }
            else if (winner =="Player 2")
            {
            }
        }
    }
}
