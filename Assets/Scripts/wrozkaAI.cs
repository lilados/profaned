using Projectiles;
using UnityEngine;
using UnityEngine.Events;


    public class WrozkaAI : EnemyAI
    {
        public UnityEvent attack;
        

        public void Attack()
        {
            float angle = Utility.GetAngleBetweenGameObjects(gameObject, player);
            Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f ,angle));

            Instantiate(Utility.GetGameObjectWithProjectile(gameObject, ScriptableObject.CreateInstance<Star>()),
                gameObject.transform.position, rot);
        }
    }
