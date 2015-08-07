using UnityEngine;
using System;
using System.Runtime.Remoting;
using System.Collections;
using System.Collections.Generic;

namespace Level
{
    /// <summary>
    /// Might Mother of all levels
    /// </summary>
    public class BaseLevel
    {
        // All level classes must declare this variables
        public List<KeyValuePair<BaseEnemy, int>> enemyList;
        public int minAvailableTime = 2;
        public int maxAvailableTime = 10;
        


        private bool _levelEnded = false;
        public void Finish()
        {
            _levelEnded = true;
        }

        public bool IsFinished()
        {
            return _levelEnded;
        }


        /// <summary>
        /// Stores the name of the Level's Environment Placeholder Prefab
        /// They are stored in "/Resources/Prefabs/EnvironmentPlaceholders/"
        /// and the name below is a prefab under this path
        /// </summary>
        protected string _environmentPlaceholderPrefabName = "Base";
        public string EnvironmentPlaceholderPrefabName
        {
            get {
                return _environmentPlaceholderPrefabName;
            }
            set
            {
                _environmentPlaceholderPrefabName = value;
            }
        }

        /// <summary>
        /// Starts the current Level, it's should only be acessed from this class children
        /// </summary>
        virtual public void StartLevel()
        {
            _levelEnded = false;
        }
    }

}