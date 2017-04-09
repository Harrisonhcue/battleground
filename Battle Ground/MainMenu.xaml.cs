using Battle_Ground.Presentation;
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
        private Game _game;
        public MainMenu()
        {
            this.InitializeComponent();
            _game = new Game();
            addCharactersToListViews();
            _player2Nickname.IsEnabled = false;
            _backBtn.Visibility = Visibility.Collapsed; ;
        }

        private void addCharactersToListViews()
        {
            foreach (Character character in _game.CharacterList)
            {
                _charListView.Items.Add(character);
                _charListView2.Items.Add(character);
                
            }
        }


        private void clickBackBtn(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void clickConfirmSelection(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkNickNameBoxes())
                {
                    Frame.Navigate(typeof(Gameplay), _game);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageDialog exception = new MessageDialog("You need to select a character for Player 1 and 2");
                await exception.ShowAsync();
            }

        }

        private async void togglePlayerMode(object sender, RoutedEventArgs e)
        {
            if (_playerToggle.IsOn == true)
            {
                _player2Nickname.IsEnabled = true;
                MessageDialog modeSelected = new MessageDialog("2 Player Mode Selected ", "Player Mode");
                await modeSelected.ShowAsync();
            }

        }

        private void characterSelected(object sender, ItemClickEventArgs e)
        {
            Character selection = e.ClickedItem as Character;
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
                    value = true;
                }
                else
                {
                    _game.Player2.Nickname = "Player 2";
                    value = true;
                }
            }
            else
            {
                _game.Player2.Nickname = "PC";
                value = true;
            }
            return value;
        }

    }
}
