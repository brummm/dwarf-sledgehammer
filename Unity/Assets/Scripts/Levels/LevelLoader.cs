using UnityEngine;
using System;
using System.Runtime.Remoting;
using System.Collections;

namespace Level
{
    /// <summary>
    /// Responsible for loading and unloading the levels
    /// </summary>
    public class LevelLoader
    {

        private int maximumLevel = 2;

        public BaseLevel Load(int index)
        {
            String levelName = AssemblyLevelName(index);
            Type mt = Type.GetType(levelName);
            if (mt != null)
            {
                BaseLevel instance = (BaseLevel)Activator.CreateInstance(Type.GetType(levelName));
                return instance;
            }
            else
            {
                return null;
            }
        }

        private String AssemblyLevelName(int index)
        {
            String str = "Level.Level" + index.ToString("D4");
            return str;
        }


        bool IsLevelIndexValid(int index)
        {
            if (index > maximumLevel) return false;
            else return true;
        }

    }   
}