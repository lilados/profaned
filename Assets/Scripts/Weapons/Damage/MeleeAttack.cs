using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool AttackBlocked;
    private bool IsAttacking;
    public Transform circle;
    public float radius = 3;

    public Slider meleeExhaust;
    [Header("Melee Stats")] public int meleeDamage;
    public float meleeDamageMult;
    public float meleeCritChance;
    public float meleeCritDamage;
    public float meleeCritChanceMult;
    public float meleeCritDamageMult;

    public float meleeSpeed;
    public float meleeSpeedMult;

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
            delay = (float)(2 - 0.05 * _weapon.attackSpeed);
            meleeExhaust.maxValue = meleeSpeed;
            meleeExhaust.value = meleeSpeed;

            object_weapon.GetComponent<Animator>().runtimeAnimatorController = _weapon.animator;
            meleeSpeed = delay / (1 + meleeSpeedMult);
            
            
            
            object_weapon.GetComponent<SpriteRenderer>().sprite = _weapon.Icon;
            if (IsAttacking == false)
            {
                Rotate();
                waitFor = meleeSpeed;
            }else if (IsAttacking && waitFor > 0)
            {
                waitFor -= Time.deltaTime;
                
                meleeExhaust.value = meleeSpeed - waitFor;
            }
            radius = _weapon.radius;
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
        if (AttackBlocked)
            return;
        animator.SetFloat("SwingSpeed", 1 + meleeSpeedMult);
        animator.SetTrigger("Attack"); AttackBlocked = true;
        IsAttacking = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(meleeSpeed);
        AttackBlocked = false;
        IsAttacking = false;
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
