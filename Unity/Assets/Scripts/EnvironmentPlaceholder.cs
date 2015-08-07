using UnityEngine;
using System;
using System.Runtime.Remoting;
using System.Collections;

namespace Level
{
    /// <summary>
    /// Handles the Placeholder for the hole game
    /// </summary>
    public class EnvironmentPlaceholders
    {
        /// <summary>
        /// GameObject that serves as placeholder
        /// </summary>
        private static GameObject _GO;
        public static GameObject GO
        {
            get
            {
                if (_GO == null)
                {
                    // TODO: depois que finalizar o carregamento, salvar o GameObject como prefab e decomentar as linhas abaixo, apagando a ultima dentro do if
                    //GameObject temp = (GameObject)Resources.Load("/Prefabs/EnvironmentPlaceholder");
                    //if (temp != null)
                    //{
                    //    _environmentPlaceholder = temp;
                    //}
                    _GO = GameObject.Find("EnvironmentPlaceholder");
                }
                return _GO;
            }
        }

        bool backgroundLoaded = false;
        string currentBackground;

        public void DrawBackground(string asset)
        {
            if (currentBackground != asset) // only loads if the current background differs from the one to be loaded
            {
                // loads the texture
                Texture2D backgroundTexture = (Texture2D)Resources.Load("Backgrounds/"+ asset);

                if (backgroundTexture != null)
                {
                    GameObject backgroundPlaceholder = GameObject.Find("EnvironmentPlaceholder/Background");

                    // if there are a previous loaded background, then we duplicate the backgroundPlaceholder
                    // to animate the transition between backgrounds
                    if (backgroundLoaded)
                    {

                    }
                    // render the texture on a given GameObject instance
                    Material material = backgroundPlaceholder.GetComponent<Renderer>().material;
                    material.mainTexture = backgroundTexture;

                    // setting the current background to the new loaded background
                    currentBackground = asset;
                }
                else
                {
                    // TODO: melhorar tratamento de erro
                    Debug.Log("FUJA BINO!");
                }
            }
        }
    }   
}