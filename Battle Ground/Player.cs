using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Ground
{
    
    public class Player
    {
        string _nickname;
       // Character _character;

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

       /* public Character Character
        {
            get
            {
                return _character;
            }

            set
            {
                _character = value;
            }
        }*/

        //Creates a new instance of a Player and initializes Variables
        public Player(string nickname)
        {
            _nickname = nickname;
        }
    }
}
