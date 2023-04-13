using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MagicProjectileMan : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public MagicAttack attack;
    public HealthManager enemyHealth;
    public MagicWeapon _weapon;
    public int damage;
    public Projectile_Magic magic;


    private void Start()
    {
        attack = GameObject.Find("Mage").GetComponent<MagicAttack>();
        magic = attack.weapon.magic;
        Destroy(gameObject, 20f);
        GetComponent<SpriteRenderer>().sprite = magic.sprite;
    }

    private void FixedUpdate()
    {
        
        if(GameObject.Find("Mage") != null){
            attack = GameObject.Find("Mage").GetComponent<MagicAttack>();
        }
        _weapon = attack.weapon;
        
        if (_weapon != null)
        {
            magic = _weapon.magic;
            damage = _weapon.damage;
            rb.velocity = transform.right * magic.velocity;
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        magic.OnHit(GameObject.Find("Mage"), col.gameObject, gameObject);
        
    }
    
    
}