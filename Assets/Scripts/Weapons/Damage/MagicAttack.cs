using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MagicAttack : MonoBehaviour
{
    [SerializeField] Transform hand;
    public MagicWeapon weapon;
    public GameObject objectWeapon;
    
    public GameObject projectile;

    [HideInInspector]public Helm defaultHelm;
    public float mana = 100;
    public int maxMana = 100;

    public int regenRate = 1;
    public float reloadTime = 2;
    public float timeLeft;
    
    
    [HideInInspector] public float softCap = 0.25f;
    
    public Slider manaBarSlider;

    public bool manaBlocked;

    private void Start()
    {
        manaBarSlider = GameObject.Find("SpecialRatio").GetComponent<Slider>();
    }

    private void Update()
    {
        if (weapon != null)
        {
            objectWeapon.GetComponent<SpriteRenderer>().sprite = weapon.Icon;
            Rotate();
            reloadTime = (float)(2 - 0.02 * weapon.castSpeed);            
            if (reloadTime <= 0) reloadTime = softCap;
        }
        if (weapon == null) objectWeapon.gameObject.GetComponent<SpriteRenderer>().sprite = null;

        if ( gameObject.transform.Find("Head").GetComponent<SpriteRenderer>().sprite == null) gameObject.transform.Find("Head").GetComponent<SpriteRenderer>().sprite = defaultHelm.sprite;
        
        manaBarSlider.maxValue = maxMana;
        manaBarSlider.value = mana;

        if (mana < maxMana && !manaBlocked)
        {
            RegenMana();   
        }

        if (mana > maxMana)
        {
            mana = maxMana;
        }
        
        DecreaseReloadTime();

        if (mana < 0) mana = 0;

        if (weapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (mana > weapon.manaCost && timeLeft == 0)
                {
                    MagicAttackS();
                    mana -= weapon.manaCost;
                }
            }
        }
    }


    void Rotate()
    {
        float angle = Utility.AngleTowardsMouse(hand.position);
        hand.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - weapon.DegreeOffset));
    }

    public void RegenMana()
    {
        mana += Time.deltaTime * regenRate;
    }

    public void DecreaseReloadTime()
    {
        
        timeLeft -= Time.deltaTime;
        

        if (timeLeft < 0) timeLeft = 0;
    }

    public void MagicAttackS()
    {
        weapon.WeaponEffect(objectWeapon);
        timeLeft = reloadTime;
    }
}
