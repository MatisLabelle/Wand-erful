using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiAi : MonoBehaviour
{

// public NavMeshAgent ennemi;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Transform spawnFlech;
    
   // public float health;


    //Attaque
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //Zone
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        //player = GameObject.Find("XR Origin (XR Rig)").transform;
        //ennemi = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //trouve et tir
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    public IEnumerator attaque()
    {
         if (!alreadyAttacked)
        {
            //Lorsqu'il attaque
            Rigidbody rb = Instantiate(projectile, new Vector3(spawnFlech.position.x, spawnFlech.position.y, spawnFlech.position.z), Quaternion.identity).GetComponent<Rigidbody>();
           rb.AddForce(transform.forward * -1, ForceMode.Impulse);
            // rb.AddForce(transform.up * 2, ForceMode.Impulse);
              
            //
            alreadyAttacked = true;
            //yield return new WaitForSeconds(1f);
            //Destroy(rb.gameObject);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
        }
        

        yield break; 
    }

    private void AttackPlayer()
    {
        StartCoroutine("attaque");
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
