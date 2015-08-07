using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyPlaceholder : MonoBehaviour
    {

        private Color selectedColor = Color.red;
        private Color defaultColor;
        private Material mat;

        public BaseEnemy EnemyInstance
        {
            get;
            set;
        }

        /// <summary>
        /// Event Handler for touch input down
        /// </summary>
        public event EventHandler EnemyPlaceholderHitDown;

        /// <summary>
        /// Event Handler for touch input up
        /// </summary>
        public event EventHandler EnemyPlaceholderHitUp;


        

        void Start()
        {
            mat = GetComponent<Renderer>().material;
            defaultColor = mat.color;
        }

        void SpawnEnemy()
        {

        }







        void OnTouchDown()
        {
            OnEnemyPlaceholderHitDown();
            Select();
        }

        void OnTouchUp()
        {
            Unselect();
            OnEnemyPlaceholderHitUp();
        }

        void OnTouchStay()
        {
            Select();
        }

        void OnTouchExit()
        {
            Unselect();
        }


        private void Select()
        {
            mat.color = selectedColor;
        }

        private void Unselect()
        {
            mat.color = defaultColor;
        }

        protected virtual void OnEnemyPlaceholderHitDown()
        {
            if (EnemyPlaceholderHitDown != null)
                EnemyPlaceholderHitDown(this, EventArgs.Empty);
        }

        protected virtual void OnEnemyPlaceholderHitUp()
        {
            if (EnemyPlaceholderHitUp != null)
                EnemyPlaceholderHitUp(this, EventArgs.Empty);
        }



    }
}