using UnityEngine;
using UnityEngine.UI;
using Weapons;

public class RangedAttack : MonoBehaviour
{
   [SerializeField] Transform hand;
   public RangedWeapon _weapon;
   public Slider BowPowerSlider;
   public GameObject object_weapon;
   [Range(0, 30)] public float BowPower;

   [Range(0, 10)] public float MaxBowCharge;
   public float bowSpeed = 1f;

   private float BowCharge;
   private bool CanFire = true;

   

   private void Start()
   {
      BowPowerSlider.value = 0f;
   }

   private void Update()
   {
      
      if (_weapon != null)
      {
         object_weapon.GetComponent<SpriteRenderer>().sprite = _weapon.Icon;
         bowSpeed = _weapon.bowSpeed;
         MaxBowCharge = _weapon.bowMaxCharge;
         BowPower = _weapon.bowPower;
         Rotate();
      }

      if (_weapon == null) object_weapon.gameObject.GetComponent<SpriteRenderer>().sprite = null;
      
      BowPowerSlider.maxValue = MaxBowCharge;
      if (_weapon != null)
      {
         BowPowerSlider.gameObject.SetActive(true);
      }
      else
      {  
         BowPowerSlider.gameObject.SetActive(false);
      }

      if (_weapon == null)
      {
         BowCharge = 0;
      }
      if (_weapon != null)
      {
         if (Input.GetMouseButton(0) && CanFire)
         {
            ChargeBow();
         }

         else if (Input.GetMouseButtonUp(0) && CanFire && BowCharge >= MaxBowCharge)
         {
            FireBow();
         }
         else if(Input.GetMouseButtonUp(0) && CanFire && BowCharge <= MaxBowCharge)
         {
            
         }
         else
         {
            if (BowCharge > 0f)
            {
               BowCharge -= bowSpeed * Time.deltaTime;
            }
            else
            {
               BowCharge = 0f;
               CanFire = true;
            }

            BowPowerSlider.value = BowCharge;
         }
         
      }
   }

         void ChargeBow()
         {
            BowCharge += bowSpeed * Time.deltaTime;
            BowPowerSlider.value = BowCharge;
            if (BowCharge > MaxBowCharge)
            {
               BowPowerSlider.value = MaxBowCharge;
            }
         }
         void FireBow()
         {
            if (BowCharge > MaxBowCharge) BowCharge = MaxBowCharge;

            _weapon.WeaponEffect(object_weapon);
            CanFire = false;
         }    
         
         void Rotate()
         {
            float angle = Utility.AngleTowardsMouse(hand.position);
            hand.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - _weapon.DegreeOffset));
         } 
}

