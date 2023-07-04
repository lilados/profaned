using System;
using UnityEngine;

public class AnimationEventHelper : MonoBehaviour
{
   public bool s;
   private void Update()
   {
      if (GameObject.Find("Melee").GetComponent<MeleeAttack>()._weapon != null && !gameObject.GetComponent<PolygonCollider2D>())
      {
         PolygonCollider2D pol = gameObject.AddComponent<PolygonCollider2D>();
         pol.isTrigger = true;
      }else if (GameObject.Find("Melee").GetComponent<MeleeAttack>()._weapon == null)
      {
         Destroy(gameObject.GetComponent<PolygonCollider2D>());
      }

      if (GameObject.Find("Melee").GetComponent<MeleeAttack>()._weapon != null && !s)
      {
         SetPolygonShape.SetColliderFromSprite(gameObject);
         
         
         s = true;
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      Debug.Log("jej");
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      OnTriggerEnter2D(other);
   }
}
