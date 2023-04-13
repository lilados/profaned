using System;
using UnityEngine;
using Weapons.Damage;

public class PlayerController : MonoBehaviour
{
    public bool facingRight = true;
    public Weapon g_weapon;
    public GameObject hand;
    public GameObject MeleeSlot;
    public GameObject RangedSlot;
    public GameObject MagicSlot;

    public Helm helmet;
    public Chest chest;
    public Leggings legs;
    public SpecialAccessory acc;
    public Hands hands;
    public Feet feetWear;
    public Arm arm;
    public Torso torso;
    public Necklace neck;
    public Character c;
    void FixedUpdate()
    {
        
        if (GameObject.Find("Melee") != null)
        {
            g_weapon = GameObject.Find("Melee").GetComponent<MeleeAttack>()._weapon;
            RangedSlot.SetActive(false);
            MagicSlot.SetActive(false);
        }
        if (GameObject.Find("Ranger") != null)
        {
            g_weapon = GameObject.Find("Ranger").GetComponent<RangedAttack>()._weapon;
            MeleeSlot.SetActive(false);
            MagicSlot.SetActive(false);
        }
        if (GameObject.Find("Mage") != null)
        {
            g_weapon = GameObject.Find("Mage").GetComponent<MagicAttack>().weapon;
            MeleeSlot.SetActive(false);
            RangedSlot.SetActive(false);
        }
        
        float horizontal1 = Input.GetAxis("Horizontal");
        if (horizontal1 > 0 && !facingRight)
        {
            Flip();
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            hand.transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal1 < 0 && facingRight) 
        {
            Flip();
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            hand.transform.localScale = new Vector3(-1, 1, 1);
            
        }
    }

    

    private void Update()
    {
        if(helmet != null){
            helmet.Equipped(c);
        }

        if(chest != null){
            chest.Equipped(c);
        }

        if(legs != null){
            legs.Equipped(c);
        }

        if (acc != null)
        {
            acc.Equipped(c);
        }

        if (hands != null)
        {
            hands.Equipped(c);
        }

        if (arm != null)
        {
            arm.Equipped(c);
        }

        if (neck != null)
        {
            neck.Equipped(c);
        }

        if (torso != null)
        {
            torso.Equipped(c);
        }

        if (feetWear != null)
        {
            feetWear.Equipped(c);
        }
    }
    
    void Flip()
    {
        facingRight = !facingRight;
    }
}
