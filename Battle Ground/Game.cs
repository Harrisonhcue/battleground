using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Character Laloor = new Character();
            Laloor.CharImage = "Assets/Laloor.png";
            Laloor.CharName = $"Laloor";
            Character character2 = new Character();
            character2.CharImage = "Assets/char1.png";
            character2.CharName = "Dest";
            _characterList.Add(Laloor);
            _characterList.Add(character2);

        }




    }
}