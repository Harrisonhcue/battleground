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
        private List<Character> _characterList1;
        private List<Character> _characterList2;
        private bool _isHuman;

        public Game()
        {
            _player1 = null;
            _player2 = null;
            setCharacterList1();
            setCharacterList2();
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

        internal List<Character> CharacterList1
        {
            get
            {

                return _characterList1;

            }


        }
        internal List<Character> CharacterList2
        {
            get
            {

                return _characterList1;

            }


        }

        public bool IsHuman
        {
            get
            {
                return _isHuman;
            }
            set
            {
                _isHuman = value;
            }
        }

        private void setCharacterList1()
        {
            _characterList1 = new List<Character>();
            Character char1 = new BlueLizard();
            Character char2 = new Adventurer();
            //Character cha3 = new;
            _characterList1.Add(char1);
            _characterList1.Add(char2);

        }
        private void setCharacterList2()
        {
            _characterList2 = new List<Character>();
            Character char1 = new BlueLizard();
            Character char2 = new Adventurer();
            //Character cha3 = new;
            _characterList2.Add(char1);
            _characterList2.Add(char2);
        }




    }
}