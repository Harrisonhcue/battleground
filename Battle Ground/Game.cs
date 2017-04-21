using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battle_Ground.Presentation;
using Battle_Ground.Characters;
using System.IO;

namespace Battle_Ground
{
    /// <summary>
    /// Game Class Written by Harrison
    /// </summary>
    class Game
    {
        //Field Variable for player 1
        private Player _player1;
        //Field variable for player 2 
        private Player _player2;
        /// <summary>
        /// Character Lists field variables
        /// </summary>
        private List<Character> _characterList1;
        private List<Character> _characterList2;
        private bool _isHuman;

        /// <summary>
        /// Game default constructor
        /// </summary>
        public Game()
        {
            _player1 = null;
            _player2 = null;
            setCharacterList1();
            setCharacterList2();
        }

        /// <summary>
        /// Player 1 accessor
        /// </summary>
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
        /// <summary>
        /// Player2 accessor 
        /// </summary>
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

        /// <summary>
        /// Read only character list
        /// </summary>
        internal List<Character> CharacterList1
        {
            get
            {

                return _characterList1;

            }


        }
        /// <summary>
        /// Read only character List2
        /// </summary>
        internal List<Character> CharacterList2
        {
            get
            {

                return _characterList1;

            }


        }

        /// <summary>
        /// Bool representing type of player
        /// </summary>
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

        /// <summary>
        ///Methond which sets character list
        /// </summary>
        private void setCharacterList1()
        {
            _characterList1 = new List<Character>();
            Character char1 = new BlueLizard();
            Character char2 = new Adventurer();
            Character char3 = new SkeletonKnight();
            Character char4 = new RedSeal();
            Character char5 = new Mage();
            _characterList1.Add(char1);
            _characterList1.Add(char2);
            _characterList1.Add(char3);
            _characterList1.Add(char4);
            _characterList1.Add(char5);


        }
        /// <summary>
        /// Method to set second character list view
        /// </summary>
        private void setCharacterList2()
        {
            _characterList2 = new List<Character>();
            Character char1 = new BlueLizard();
            Character char2 = new Adventurer();
            Character char3 = new SkeletonKnight();
            Character char4 = new RedSeal();
            Character char5 = new Mage();
            _characterList2.Add(char1);
            _characterList2.Add(char2);
            _characterList2.Add(char3);
            _characterList2.Add(char4);
            _characterList2.Add(char5);

        }

        // Saves the information of the game into a file. Written by Sohail
        internal void Save(StreamWriter writer, string winner)
        {
            // Save the game details

            // Check if player 2 is a human to save information appropriately.
            if (_isHuman == true)
            {
                writer.WriteLine("Player vs Player");
            }
            else if (_isHuman == false)
            {
                writer.WriteLine("Player vs PC");
            }

            // Save player nicknames and character choices
            writer.WriteLine($"{_player1.Nickname} as {_player1.Character.CharName} VS {_player2.Nickname} as {_player2.Character.CharName}");

            if (winner == "Tie")
            {
                writer.WriteLine("Tie");
            }
            else
            {
                // Save the winner of the game
                writer.WriteLine($"Winner: {winner}");
            }
        }
    }
}