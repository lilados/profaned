using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Weapons;

public class RangedProjectileMan : MonoBehaviour
{
    [HideInInspector] public float arrowVelocity;
    [SerializeField] private Rigidbody2D rb;
    public RangedAttack attack;
    public HealthManager enemyHealth;
     public RangedWeapon weapon;
    public int damage;
    public Projectile_Ranged projectileRanged;

    private void Start()
    {
        attack = GameObject.Find("Ranger").GetComponent<RangedAttack>();
        projectileRanged = attack._weapon.ammo;
        Destroy(gameObject, 20f);
        arrowVelocity = projectileRanged.velocity;
        GetComponent<SpriteRenderer>().sprite = projectileRanged.Sprite;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * arrowVelocity;
        weapon = attack._weapon;
        damage = weapon.damage;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        projectileRanged.OnHit(GameObject.Find("Ranger"), col.gameObject, gameObject);
    }
}
