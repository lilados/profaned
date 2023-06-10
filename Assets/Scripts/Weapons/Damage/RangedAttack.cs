using Unity.VisualScripting;
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
      BowPowerSlider = GameObject.Find("SpecialRatio").gameObject.GetComponent<Slider>();
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
      AdjustSlider();
      if (_weapon == null)
      {
         BowCharge = 0;
         BowPowerSlider.value = 0;
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

         void AdjustSlider()
         {
            Image fill = BowPowerSlider.transform.GetChild(1).GetChild(0).GetComponent<Image>();
            if (BowPowerSlider.value < 0.2f)
            {
               fill.color = new Color(0.18f, 0.8f, 0.44f);
            } else 
            if (BowPowerSlider.value is > 0.2f and < 0.4f)
            {
               fill.color = new Color(0.72f, 1, 0);
            } else 
            if (BowPowerSlider.value is > 0.4f and < 0.6f)
            {
               fill.color = Color.yellow;
            }else 
            if (BowPowerSlider.value is > 0.6f and < 0.8f)
            {
               fill.color = new Color(1, 0.5f, 0.2f);
            }else 
            if (BowPowerSlider.value > 0.8f)
            {
               fill.color = Color.red;
            }
         }
}

