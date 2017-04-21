using Battle_Ground.Characters;
using Battle_Ground.Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Battle_Ground
{
    /// <summary>
    /// Written by Harrison
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        /// <summary>
        /// The field variable game which will be used thorugh all page navigations
        /// </summary>
        private Game _game;
        private static Random _randomizer;
        /// <summary>
        /// Default contructor for the main menu.xaml page 
        /// </summary>
        public MainMenu()
        {
            this.InitializeComponent();
            _game = new Game();
            addCharactersToListViews();
            _player2Nickname.IsEnabled = false;
            _randomizer = new Random();
        }
        /// <summary>
        /// Method to show characters in the list view to the user
        /// </summary>
        private void addCharactersToListViews()
        {
            foreach (Character character in _game.CharacterList1)
            {
                _charListView.Items.Add(character);

            }
            foreach (Character character in _game.CharacterList2)
            {
                _charListView2.Items.Add(character);
            }
        }

        /// <summary>
        /// Mehtod which enables the user to navigate back on clicking the back button if possible 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickBackBtn(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TitlePage));
        }
        /// <summary>
        /// Method which is called when the user confirm selection of characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clickConfirmSelection(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkNickNameBoxes())
                {
                    Frame.Navigate(typeof(Gameplay), _game);
                }
            }
            catch (NullReferenceException)
            {
                MessageDialog exception = new MessageDialog("You need to select a character for Player 1 and 2");
                await exception.ShowAsync();
            }

        }
        /// <summary>
        /// Toggles which player mode is currently selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void togglePlayerMode(object sender, RoutedEventArgs e)
        {
            if (_playerToggle.IsOn == true)
            {
                _player2Nickname.IsEnabled = true;

            }
            else if (_playerToggle.IsOn == false)
            {
                _player2Nickname.IsEnabled = false;
            }

        }
        /// <summary>
        /// Determines which character was selected and asssigns that to the player selecting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void characterSelected(object sender, ItemClickEventArgs e)
        {
            Character selection = e.ClickedItem as Character;
            Character playerSelection = new Character();


            if (sender == _charListView)
            {
                _game.Player1 = new Player();
                _game.Player1.Character = selection;


            }

            else if (sender == _charListView2)
            {
                _game.Player2 = new Player();
                _game.Player2.Character = selection;
            }
        }
        /// <summary>
        /// Check to see if a nickname has been set by user or it defaults
        /// </summary>
        /// <returns>boolean </returns>
        private bool checkNickNameBoxes()
        {
            bool value;
            if (_player1Nickname.Text.Length != 0)
            {
                _game.Player1.Nickname = _player1Nickname.Text;
                value = true;
            }
            else
            {
                _game.Player1.Nickname = "Player 1";
                value = true;
            }
            if (_playerToggle.IsOn == true)
            {
                if (_player2Nickname.Text.Length != 0)
                {
                    _game.Player2.Nickname = _player2Nickname.Text;
                    _game.IsHuman = true;
                    value = true;
                }
                else
                {
                    _game.Player2.Nickname = "Player 2";
                    _game.IsHuman = true;
                    value = true;
                }
            }
            else
            {
                _game.Player2.Nickname = "PC";
                _game.IsHuman = false;
                value = true;
            }
            return value;
        }
        /// <summary>
        /// Method which randomizes character selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickRandomChar(object sender, RoutedEventArgs e)
        {
            //Random character chosen from current characters contained by the game object
            if (sender == _btnRandomP1)
            {

                //Assigns the random character if player 1 randomizes 
                _game.Player1 = new Player();

                _game.Player1.Character = _game.CharacterList1[_randomizer.Next(_game.CharacterList1.Count)];
                _charListView.SelectedItem = _game.Player1.Character;


            }
            else if (sender == _btnRandomP2)
            {
                //Assigns the random character if player 2 randomizes 
                _game.Player2 = new Player();
                _game.Player2.Character = _game.CharacterList2[_randomizer.Next(_game.CharacterList2.Count)];
                _charListView2.SelectedItem = _game.Player2.Character;
            }

        }

    }
}
