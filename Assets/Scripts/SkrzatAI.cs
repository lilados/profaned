using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SkrzatAI : EnemyController
{
    public int damage;
    public float spearVelocity;
    public GameObject weaponPrefab;
    [SerializeField] public GameObject hand;

    public UnityEvent launchProjectile;

    public override void Start()
    {
        base.Start();
    }

    public void LaunchProjectile()
    {
        launchProjectile?.Invoke();
    }


    public void Attack()
    {

        GameObject pla = Utility.GetClosestEnemy(GameObject.FindGameObjectsWithTag("Player"), gameObject.transform);

        float angle = Utility.AngleTowardsMouse(pla.transform.position);
        hand.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f ,hand.transform.rotation.z));
        
        
        Instantiate(weaponPrefab, hand.transform.GetChild(0).transform.position, rot);
    }
}
