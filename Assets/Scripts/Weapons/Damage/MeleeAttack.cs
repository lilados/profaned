using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] Transform hand;
    public MeleeWeapon _weapon;
    public GameObject object_weapon;
    public Animator animator;
    public float delay;
    private bool attackBlocked;
    private bool isAttacking;
    public Transform circle;
    public float radius = 3;
    
    
    private void Update()
    {
        if (_weapon != null)
        {
            object_weapon.GetComponent<SpriteRenderer>().sprite = _weapon.Icon;
            if (isAttacking == false)
            {
                Rotate();
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
