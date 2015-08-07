using UnityEngine;
using System.Collections;

namespace Weapon
{
    public class BaseWeapon
    {

        protected int _strength;
        public int Strength
        {
            get;
            set;
        }

        protected float _timeBeforeChargedAttack;
        public float TimeBeforeChargedAttack
        {
            get;
            set;
        }
    }
}