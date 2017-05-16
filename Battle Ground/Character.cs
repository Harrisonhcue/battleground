using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Battle_Ground
{
    /// <summary>
    /// Basic character outline that each character type will derive from. Written by Sohail.
    /// </summary>
    class Character
    {
        #region Variables
        // Variables that store the character's image source, name, attack, special attack, defense, special defense, 
        // health, and damage. Will be overriden by the derived character type classes.
        protected string _charImageSource;
        protected string _charName;
        protected double _attk = 0;
        protected double _health = 0;
        protected double _dmg = 0;
        protected double _spAttack = 0;
        protected double _defense = 0;
        protected double _spDefense = 0;

        // Stores whether character's attack hit or missed.
        protected bool _attackHit;

        // Variables that store the name of each of the derived character's attacks.
        protected string _attk1Name = "";
        protected string _attk2Name = "";
        protected string _attk3Name = "";
        protected string _attk4Name = "";
        #endregion

        #region Properties
        // Property to allow other classes to access, and alter, the character's image source
        public string CharImageSource
        {
            get { return _charImageSource; }
            set { _charImageSource = value; }
        }

        // Property to allow other classes to access, and alter, the character's name
        public string CharName
        {
            get { return _charName; }
            set { _charName = value; }
        }

        // Property to allow other classes to get, but not set, the character's first attack name
        public string DamageDealt
        {
            get { return _dmg.ToString(); }
        }

        // Property to allow other classes to get, but not set, the character's first attack name
        public string Attack1Name
        {
            get { return _attk1Name; }
        }

        // Property to allow other classes to get, but not set, the character's second attack name
        public string Attack2Name
        {
            get { return _attk2Name; }
        }

        // Property to allow other classes to get, but not set, the character's third attack name
        public string Attack3Name
        {
            get { return _attk3Name; }
        }

        // Property to allow other classes to get, but not set, the character's fourth attack name
        public string Attack4Name
        {
            get { return _attk4Name; }
        }

        // Property to allow other classes to access the character's health
        public double Health
        {
            get { return _health; }
            set { _health = value; }
        }
        #endregion

        #region Attacks
        /// All attacks available to all characters, take the paramaters of the player that is attacking and the player that is being attack
        // Beast Attacks
        public void Bite(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = Math.Round(_playerAttacking.Character._attk / _playerAttacked.Character._defense * 15);
            _playerAttacked.Character._health -= _dmg;
        }

        public void Stomp(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = Math.Round(_playerAttacking.Character._attk / _playerAttacked.Character._defense * 13);
            _playerAttacked.Character._health -= _dmg;
        }
        public void Thrash(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = Math.Round(_playerAttacking.Character._attk / _playerAttacked.Character._defense * 14);
            _playerAttacked.Character._health -= _dmg;
        }

        // Warrior attacks
        public void Stab(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = Math.Round(_playerAttacking.Character._attk / _playerAttacked.Character._defense * 13);
            _playerAttacked.Character._health -= _dmg;
        }

        public void Slash(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = Math.Round(_playerAttacking.Character._attk / _playerAttacked.Character._defense * 15);
            _playerAttacked.Character._health -= _dmg;
        }

        // Special attacks
        public void Fireball(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = Math.Round(_playerAttacking.Character._spAttack / _playerAttacked.Character._spDefense * 17);
            _playerAttacked.Character._health -= _dmg;
        }

        public void WaterCannon(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = Math.Round(_playerAttacking.Character._spAttack / _playerAttacked.Character._spDefense * 16);
            _playerAttacked.Character._health -= _dmg;
        }
        public void Thunder(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = Math.Round(_playerAttacking.Character._spAttack / _playerAttacked.Character._spDefense * 15);
            _playerAttacked.Character._health -= _dmg;
        }
        public void Void(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = Math.Round(_playerAttacking.Character._spAttack / _playerAttacked.Character._spDefense * 14);
            _playerAttacked.Character._health -= _dmg;
        }
        #endregion

        #region Methods
        // Virtual attack methods that are overriden by each character type with one of the attacks denoted by the derived character type class.
        public virtual void Attack1(Player _playerAttacking, Player _playerAttacked)
        {
        }
        public virtual void Attack2(Player _playerAttacking, Player _playerAttacked)
        {
        }
        public virtual void Attack3(Player _playerAttacking, Player _playerAttacked)
        {
        }
        public virtual void Attack4(Player _playerAttacking, Player _playerAttacked)
        {
        }
        #endregion
    }
}
