using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Battle_Ground
{
    class Character
    {
        private string _charImage;
        private string _charName;

        public string CharImage
        {
            get
            {
                return _charImage;
            }

            set
            {
                _charImage = value;
            }
        }

        public string CharName
        {
            get
            {
                return _charName;
            }

            set
            {
                _charName = value;
            }
        }
    }
}
