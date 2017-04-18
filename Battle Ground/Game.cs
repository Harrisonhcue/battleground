﻿using System;
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
    /// Written by Harrison
    /// </summary>
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
            Character char3 = new SkeletonKnight();
            Character char4 = new RedSeal();
            Character char5 = new Mage();
            _characterList1.Add(char1);
            _characterList1.Add(char2);
            _characterList1.Add(char3);
            _characterList1.Add(char4);
            _characterList1.Add(char5);


        }
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