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
    /// XAML and business logic for the screen on which the game is played. Written by Sohail
    /// </summary>
    public sealed partial class Gameplay : Page
    {
        // Stores navigation context for the game.
        private Game _game;

        // Store whether player 1 and 2 have chosen their attacks.
        private bool _player1AttackChosen;
        private bool _player2AttackChosen;

        // Store which atttacks player 1 and 2 have chosen.
        private int _player1AttackNum = 0;
        private int _player2AttackNum = 0;

        // Generates random numbers.
        private Random _randNum = new Random();

        // Store the path for where the data will be saved.
        private string _dataDirPath;
        private string _filePathBattleLogs;

        // Stores the number of Battle Log save files already created.
        private int _numSaves;

        public Gameplay()
        {
            // Initalize navigation context variable and set it to null.
            _game = null;
            this.InitializeComponent();

            // Create the path necessary to save the files in the the appropriate folder
            _dataDirPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "BattleLogs");

            // Check if directory exists and create it if it does not
            if (Directory.Exists(_dataDirPath) == false)
            {
                Directory.CreateDirectory(_dataDirPath);
            }

            // Calls method to determine number of Battle Log save files.
            LoadNumSaves();
        }

        /// <summary>
        /// Sets basic screen information, and provides information to navigation context variable when page is navigated to.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Provide information to context variable
            _game = e.Parameter as Game;

            // Make reset button invisible
            _btnReset.Visibility = Visibility.Collapsed;

            // Display text of chosen nicknames and character names
            _txtPlayer1Name.Text = _game.Player1.Nickname;
            _txtPlayer2Name.Text = _game.Player2.Nickname;
            _txtChar1Name.Text = _game.Player1.Character.CharName;
            _txtChar2Name.Text = _game.Player2.Character.CharName;

            // Set player's health bars based on characters chosen
            _uiPlayer1HealthBar.Maximum = _game.Player1.Character.Health;
            _uiPlayer1HealthBar.Value = _game.Player1.Character.Health;
            _uiPlayer2HealthBar.Maximum = _game.Player2.Character.Health;
            _uiPlayer2HealthBar.Value = _game.Player2.Character.Health;

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
                if (sender == _btnPlayer2Attack1)
                {
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
        /// Method that waits until both characters have chosen an attack and then executes both at the same time. 
        /// Disables attack buttons when an attack is selected, and re-enables the attack buttons after the attacks are executed..
        /// </summary>
        /// <param name="playerNum"></param>
        /// <param name="attackNum"></param>
        public void BattleState(int playerNum, int attackNum)
        {
            // Provides information to field variables based on which player has chosen their attack. Disables attack buttons for player that has chosen an attack. 
            if (playerNum == 1)
            {
                // Disables all attack buttons for player 1
                ChangeButtonState(1, false);

                // Stores that player has chosen an attack as well as which attack they chose.
                _player1AttackChosen = true;
                _player1AttackNum = attackNum;
            }
            else if (playerNum == 2)
            {
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
            // if character's health is negative, set the character's health bar to 0, else set it to the character's health.
            if (_game.Player1.Character.Health <= 0)
            {
                _uiPlayer1HealthBar.Value = 0;
            }
            else
            {
                _uiPlayer1HealthBar.Value = _game.Player1.Character.Health;
            }

            if (_game.Player2.Character.Health <= 0)
            {
                _uiPlayer2HealthBar.Value = 0;
            }
            else
            {
                _uiPlayer2HealthBar.Value = _game.Player2.Character.Health;
            }

            // Display which attacks each player chose as well as how much damage it dealt.
            _txtPlayer1InfoDisplay.Text = $"{_game.Player1.Character.CharName} dealt {_game.Player1.Character.DamageDealt} damage with {AttackNameToString(1)}";
            _txtPlayer2InfoDisplay.Text = $"{_game.Player2.Character.CharName} dealt {_game.Player2.Character.DamageDealt} damage with {AttackNameToString(2)}";

        }

        /// <summary>
        /// Converts the attack num of a character to a string
        /// </summary>
        /// <param name="playerNum">A player</param>
        /// <returns>String with the attack the player's character used</returns>
        public string AttackNameToString(int playerNum)
        {
            // Checks which player's attack to translate to text.
            if (playerNum == 1)
            {
                // Determine's appropriate attack name for each attack number
                switch (_player1AttackNum)
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

            // Unreachable in normal use
            return "";
        }

        /// <summary>
        /// Method that changes if the attack buttons can be clicked or not
        /// </summary>
        /// <param name="playerNum">Player who's button's states will be changed</param>
        /// <param name="buttonState">Determines whether the buttons will be disabled or enabled</param>
        public void ChangeButtonState(int playerNum, bool buttonState)
        {
            // Determine which player's button's states to change.
            if (playerNum == 1)
            {
                // Change button state to specified button state.
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
            // Local variable that stores the winner of the game as a string.
            string winner;

            // Determines if either character's health is at, or below 0. If either character's character health is at or below 0, the game is over.
            if (_game.Player1.Character.Health <= 0 || _game.Player2.Character.Health <= 0)
            {
                // Disable all attack buttons for player 1 and 2.
                ChangeButtonState(1, false);
                ChangeButtonState(2, false);

                // Determine which character's health reachde 0. If player 2's character died, player 1 wins. If player 1's character died, player 2 wins.
                // If both characters died, the game is a tie.
                if (_game.Player1.Character.Health <= 0 & _game.Player2.Character.Health <= 0)
                {
                    // Sets winner text box to the outcome of the game.
                    _txtWinnerDisplay.Text = "Tie";

                    // Sets the value of the winner string.
                    winner = "Tie";

                    // Save the results of the game. Provide a string variable with the player that one.
                    Save(winner);

                    // Make the reset button visible to the user(s).
                    _btnReset.Visibility = Visibility.Visible;
                }

                else if (_game.Player1.Character.Health <= 0)
                {

                    _txtWinnerDisplay.Text = "Player 2 Wins";
                    winner = _game.Player1.Nickname;
                    Save(winner);
                    _btnReset.Visibility = Visibility.Visible;
                }

                else if (_game.Player2.Character.Health <= 0)
                {

                    _txtWinnerDisplay.Text = "Player 1 Wins";
                    winner = _game.Player1.Nickname;
                    Save(winner);
                    _btnReset.Visibility = Visibility.Visible;
                }
            }
        }

        // Obtains the number of previous battle logs that have been created and creates a file path to a new one. 
        // If no record of previous logs exist, create a new file to store the number of BattleLog save files.
        public void LoadNumSaves()
        {
            // Try to find and read the number of BattleLogs from a file.
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream($"{_dataDirPath}/NumSaves.dat", FileMode.Open)))
                {
                    _numSaves = int.Parse(reader.ReadLine());
                }
            }
            // if file does not exist create a new one with the number of BattleLogs set at 0.
            catch (FileNotFoundException)
            {
                // Create a new file in the specified location, with the specified name.
                using (StreamWriter writer = new StreamWriter(new FileStream($"{_dataDirPath}/NumSaves.dat", FileMode.Create)))
                {
                    writer.WriteLine("0");
                }
            }
            // If file is corrupted, delete it and create a new one with the number of BattleLogs set at 0.
            catch (FormatException)
            {
                // Delete the previous file.
                File.Delete($"{_dataDirPath}/NumSaves.dat");

                // Create a new file in the specified location, with the specified name.
                using (StreamWriter writer = new StreamWriter(new FileStream($"{_dataDirPath}/NumSaves.dat", FileMode.Create)))
                {
                    writer.WriteLine("0");
                }
            }

            // Creates a filepath where the data will be saved regardless of any exception that occured.
            finally
            {
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

        // Method that returns the user to the character selection screen. Creates a new game object, discarding the old one.
        private void ResetGame(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainMenu), _game = new Game());
        }
    }
}
