using Battle_Ground.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        private Random _randNum = new Random();
        private string _dataDirPath;
        private string _filePathBattleLogs;
        private int _numSaves;
        private int _turnNum = 0;

        public Gameplay()
        {
            // Initalize navigation context variable
            _game = null;
            this.InitializeComponent();

            // Create the path necessary to save the files in the the appropriate folder
            _dataDirPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ResultsData", "BattleLogs");

            //Check if directory exists and create it if not
            if (Directory.Exists(_dataDirPath) == false)
            {
                Directory.CreateDirectory(_dataDirPath);
            }

            LoadNumSaves();
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

            // Changes the name of the attack buttons based on which character is chosen
            _btnPlayer1Attack1.Content = _game.Player1.Character.Attack1Name;
            _btnPlayer1Attack2.Content = _game.Player1.Character.Attack2Name;
            _btnPlayer1Attack3.Content = _game.Player1.Character.Attack3Name;
            _btnPlayer1Attack4.Content = _game.Player1.Character.Attack4Name;
            _btnPlayer2Attack1.Content = _game.Player2.Character.Attack1Name;
            _btnPlayer2Attack2.Content = _game.Player2.Character.Attack2Name;
            _btnPlayer2Attack3.Content = _game.Player2.Character.Attack3Name;
            _btnPlayer2Attack4.Content = _game.Player2.Character.Attack4Name;

            // Set character images based on character type sources
            _imgChar1.Source = new BitmapImage(new Uri(_game.Player1.Character.CharImageSource));
            _imgChar2.Source = new BitmapImage(new Uri(_game.Player2.Character.CharImageSource));

            // If player 2 is a PC, produce a random attack.
            if (_game.IsHuman == false)
            {
                BattleState(2, _randNum.Next(1, 5));
            }
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
            }
        }

        /// <summary>
        /// Method that waits until both characters have chosen an attack and then executes both at the same time. Reenables the attack buttons.
        /// </summary>
        /// <param name="playerNum"></param>
        /// <param name="attackNum"></param>
        public void BattleState(int playerNum, int attackNum)
        {
            _turnNum += 1;

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
                switch (_player1AttackNum)
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

                // Return both attacks to unchosen.
                _player1AttackChosen = false;
                _player2AttackChosen = false;

                // Re-enables both player's attack buttons after they have both chosen an attack and their attacks have been executed.
                ChangeButtonState(1, true);

                // If player 2 is a PC, produce a random attack.
                if (_game.IsHuman == false)
                {
                    BattleState(2, _randNum.Next(1, 5));
                }
                else if (_game.IsHuman == true)
                {
                    ChangeButtonState(2, true);
                }

                // Calls a method that checks if either character's health is below 0.
                CheckWin();

                // Updates the health of the characters and which attacks they chose
                UpdateLabels();
                
            }
        }

        /// <summary>
        /// Displays the updated health of each character as well as which attack they chose and how much damage it dealt.
        /// </summary>
        public void UpdateLabels()
        {
            _txtChar1Health.Text = _game.Player1.Character.Health.ToString();
            _txtChar2Health.Text = _game.Player2.Character.Health.ToString();
            _txtPlayer1InfoDisplay.Text = $"{_game.Player1.Character.CharName} dealt {_game.Player1.Character.DamageDealt} damage with {AttackNameToString(1)}";
            _txtPlayer2InfoDisplay.Text = $"{_game.Player2.Character.CharName} dealt {_game.Player2.Character.DamageDealt} damage with {AttackNameToString(2)}";
        }

        /// <summary>
        /// converts the attack num of a character to a string
        /// </summary>
        /// <param name="playerNum">A player</param>
        /// <returns>String with the attack the player's character used</returns>
        public string AttackNameToString(int playerNum)
        {
            if (playerNum == 1)
            {
                switch(_player1AttackNum)
                {
                    case 1:
                        return _game.Player1.Character.Attack1Name;
                    case 2:
                        return _game.Player1.Character.Attack2Name;
                    case 3:
                        return _game.Player1.Character.Attack3Name;
                    case 4:
                        return _game.Player1.Character.Attack4Name;
                }
            }
            else if (playerNum == 2)
            {
                switch (_player2AttackNum)
                {
                    case 1:
                        return _game.Player2.Character.Attack1Name;
                    case 2:
                        return _game.Player2.Character.Attack2Name;
                    case 3:
                        return _game.Player2.Character.Attack3Name;
                    case 4:
                        return _game.Player2.Character.Attack4Name;
                }
            }
                Debug.Assert(false, "Invalid attack number or player number given");
                return "";
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
            string winner;

            if (_game.Player1.Character.Health <= 0 || _game.Player2.Character.Health <= 0)
            {
                ChangeButtonState(1, false);
                ChangeButtonState(2, false);

                if (_game.Player1.Character.Health <= 0 & _game.Player2.Character.Health <= 0)
                {
                    _game.Player1.Character.Health = 0;
                    _game.Player2.Character.Health = 0;
                    _txtWinnerDisplay.Text = "Tie";
                    winner = "Tie";
                    Save(winner);
                }

                else if (_game.Player1.Character.Health <= 0)
                {
                    _game.Player1.Character.Health = 0;
                    _txtWinnerDisplay.Text = "Player 2 Wins";
                    winner = _game.Player1.Nickname;
                    Save(winner);
                }

                else if (_game.Player2.Character.Health <= 0)
                {
                    _game.Player2.Character.Health = 0;
                    _txtWinnerDisplay.Text = "Player 1 Wins";
                    winner = _game.Player1.Nickname;
                    Save(winner);
                }
            }
        }

        // Obtains the number of previous battle logs that have been created and creates a file path to a new one.
        public void LoadNumSaves()
        {
            using (StreamReader reader = new StreamReader(new FileStream($"{_dataDirPath}/NumSaves.dat", FileMode.Open)))
            {
                _numSaves = int.Parse(reader.ReadLine());
                // Create a filepath where the data will be saved
                _filePathBattleLogs = $"{_dataDirPath}/Battle Log {_numSaves}.dat";
            }
        }

        // Saves the game informaiton to a file
        public void Save(string winner)
        {
            // Create a file stream with a stream reader to update the number of BattleLog files. Overwrites previous file.
            using (StreamWriter writer = new StreamWriter(new FileStream($"{_dataDirPath}/NumSaves.dat", FileMode.Create)))
            {
                writer.WriteLine(_numSaves += 1);
            }

            // Create a file stream with a stream reader to store data into the file
            using (StreamWriter writer = new StreamWriter(new FileStream(_filePathBattleLogs, FileMode.Create)))
            {
                _numSaves += 1;
                _game.Save(writer, winner);
            }
        }
    }
}
