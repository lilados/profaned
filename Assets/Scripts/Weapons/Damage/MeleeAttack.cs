using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] Transform hand;
    public MeleeWeapon _weapon;
    public GameObject object_weapon;
    public PlayerController playerController;
    public Animator animator;
    public float delay;
    public float waitFor;
    private bool attackBlocked;
    private bool isAttacking;
    public Transform circle;
    public float radius = 3;
    public float critChance;
    public float critDmg;

    public Slider meleeExhaust;
    [Header("Melee Stats")] public int meleeDamage;
    public float meleeDamageMult;
    public float meleeCritChance;
    public float meleeCritDamage;
    public float meleeCritChanceMult;
    public float meleeCritDamageMult;

    private void Start()
    {
        meleeExhaust = GameObject.Find("SpecialRatio").GetComponent<Slider>();
        meleeExhaust.transform.GetChild(0).GetComponent<Image>().color = Color.gray;
        meleeExhaust.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(0.66f, 0.66f, 0.66f);
        playerController = gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        meleeExhaust.maxValue = 1;
        meleeExhaust.value = 1;
        if (_weapon != null)
        {
            meleeDamage = (int)((_weapon.damage + playerController.baseDamage) * (1 + playerController.baseDamageMult + meleeDamageMult)) +playerController.flatDamage;
            meleeExhaust.maxValue = delay;
            meleeExhaust.value = delay;
            
            object_weapon.GetComponent<SpriteRenderer>().sprite = _weapon.Icon;
            if (isAttacking == false)
            {
                Rotate();
                waitFor = delay;
            }else if (isAttacking && waitFor > 0)
            {
                waitFor -= Time.deltaTime;
                
                meleeExhaust.value = delay - waitFor;
            }
            radius = _weapon.radius;
            delay = (float)(2 - 0.05 * _weapon.attackSpeed);
            object_weapon.GetComponent<Animator>().runtimeAnimatorController = _weapon.animator;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }

            
            
            
        }

        if (_weapon == null)
        {
            object_weapon.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            object_weapon.GetComponent<Animator>().runtimeAnimatorController = null;

        }
    }

    private void OnValidate()
    {
        if (_weapon != null)
        {
            radius = _weapon.radius;
            delay = (float)(2 - 0.05 * _weapon.attackSpeed);
            object_weapon.GetComponent<Animator>().runtimeAnimatorController = _weapon.animator;
            if (_weapon == null) object_weapon.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    void Rotate()
    {
        float angle = Utility.AngleTowardsMouse(hand.position);
        hand.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - _weapon.DegreeOffset));
        
    }

    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        attackBlocked = true;
        isAttacking = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Vector3 position = circle == null ? Vector3.zero : circle.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circle.position, radius))
        {
            if (collider.CompareTag("Enemy") || collider.CompareTag("Mineral"))
            {
                _weapon.WeaponEffect( gameObject, collider.gameObject);
            } 
        }
    }

    
}
