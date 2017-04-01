using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Ground
{

    public class Player
    {
        private string _nickname;
        private Character _character;


        //Creates a new instance of a Player and initializes Variables
        public Player()
        {
            _nickname = null;
            _character = null;
        }
        public string Nickname
        {
            get
            {
                return _nickname;
            }

            set
            {
                _nickname = value;
            }
        }

        internal Character Character
        {
            get
            {
                return _character;
            }

            set
            {
                _character = value;
            }
        }




    }
}
