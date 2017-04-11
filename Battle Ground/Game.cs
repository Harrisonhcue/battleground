using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battle_Ground.Presentation;
using Battle_Ground.Characters;

namespace Battle_Ground
{
    class Game
    {
        private Player _player1;
        private Player _player2;
        private List<Character> _characterList;
        public Game()
        {
            _player1 = null;
            _player2 = null;
            setCharacterList();
        }

        public Player Player1
        {
            get
            {
                return _player1;
            }

            set
            {
                _player1 = value;
            }
        }

        public Player Player2
        {
            get
            {
                return _player2;
            }

            set
            {
                _player2 = value;
            }
        }

        internal List<Character> CharacterList
        {
            get
            {

                return _characterList;

            }


        }

        private void setCharacterList()
        {
            _characterList = new List<Character>();
            Character char1 = new BlueLizard();
            char1.CharImageSource = "Assets/BlueLizard.png";
            char1.CharName = $"BlueLizard";
            Character char2 = new Adventurer();
            char2.CharImageSource = "Assets/Adventurer.png";
            char2.CharName = "Adventurer";
            _characterList.Add(char1);
            _characterList.Add(char2);

        }




    }
}