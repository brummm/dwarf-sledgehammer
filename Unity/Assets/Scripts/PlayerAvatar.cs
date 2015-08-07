using System;
using UnityEngine;
using Enemy;


namespace Player
{
    public class PlayerAvatar : MonoBehaviour
    {

        private Health healthInstance;
        private float touchDownUpTimeDiference;

        public void OnEnemyPlaceholderHitDown(object source, EventArgs e)
        {
            StartChargedAttack();
        }

       

        public void OnEnemyPlaceholderHitUp(object source, EventArgs e)
        {
            FinishChargedAttack();
        }

        private void StartChargedAttack()
        {
            touchDownUpTimeDiference = Time.realtimeSinceStartup;
            throw new NotImplementedException();
        }

        private void FinishChargedAttack()
        {
            //Time.realtimeSinceStartup - touchDownUpTimeDiference;
            throw new NotImplementedException();
        }

        void Awake()
        {
            // TODO: localizar o loader do default level e dar um instanciaX.GetComponent<BaseLevel>()

            healthInstance = new Health();
        }


        void Start()
        {
        }

        

        void GetHit(int force)
        {
            healthInstance.RemoveHealthPoint(force);
            if (healthInstance.GotToDie())
            {
                Die();
            }
        }

        void Die()
        {
        }

        void Atack(Vector2 position)
        {
            // usar SmoothDamp para mover o anão do ponto a ao ponto b "suavemente"

        }
    }

    

}


