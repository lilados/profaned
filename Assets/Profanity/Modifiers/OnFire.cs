using UnityEngine;

namespace SOs.Modifiers
{
    public class OnFire : Modifier
    {
        private void OnEnable()
        {
            modName = "On Fire!";
            modId = 1;
            maxLevel = 2;
        }

        public int playerHealthBefore;  
        public override void AddEffect(GameObject entity)
        {
            base.AddEffect(entity);
            if (entity.CompareTag("Player"))
            {
                playerHealthBefore = entity.GetComponent<PlayerHealth>().amountHealed;
                
                switch (level)
                {
                    case 1: entity.GetComponent<PlayerHealth>().amountHealed += 20;
                        break;
                
                    case 2: entity.GetComponent<PlayerHealth>().amountHealed += 40;
                        break;
                }
            }
            else if (entity.CompareTag("Enemy"))
            {
                playerHealthBefore = entity.GetComponent<HealthManager>().amountHealed;
                
                switch (level)
                {
                    case 1: entity.GetComponent<HealthManager>().amountHealed += 20;
                        break;
                
                    case 2: entity.GetComponent<HealthManager>().amountHealed += 40;
                        break;
                }
            }
        }

        public override void RemoveEffect(GameObject entity)
        {
            base.RemoveEffect(entity);
            if (entity.CompareTag("Enemy"))
            {
                entity.GetComponent<HealthManager>().amountHealed = playerHealthBefore;
            }
            if (entity.CompareTag("Player"))
            {
                entity.GetComponent<PlayerHealth>().amountHealed = playerHealthBefore;
            }
        }
    }
}

