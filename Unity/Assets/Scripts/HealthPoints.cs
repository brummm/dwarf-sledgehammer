using System;

namespace Player
{
    class Health
    {

        /// <summary>
        /// How much life points the character got
        /// </summary>
        private int healthPoints;
        public int HealthPoints
        {
            get
            {
                return healthPoints;
            }
            set
            {
                if (value > Slots)
                {
                    value = Slots;
                }
                else if (value < 0)
                {
                    value = 0;
                }
                healthPoints = value;
            }
        }

        /// <summary>
        /// How much life points a player can get
        /// </summary>
        private int slots;
        public int Slots
        {
            get
            {
                return slots;
            }
            set
            {
                slots = value;
            }
        }


        public Health()
        {

        }

        public void AddHealthPoint(int amount)
        {
            HealthPoints = HealthPoints + amount;
        }

        public void RemoveHealthPoint(int amount)
        {
            HealthPoints = HealthPoints - amount;
        }

        public void Restore()
        {
            HealthPoints = Slots;
        }

        public bool GotToDie()
        {
            return HealthPoints == 0;
        }
    }
}
