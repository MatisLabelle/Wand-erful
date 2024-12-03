using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirEnnemi : MonoBehaviour
{

    public float rotationSpeed = 1;
    public float BlastPower = 2;
   public LayerMask whatIsGround, whatIsPlayer;
    public float timeBetweenAttacks;

    public GameObject canonBall;
    public Transform shotPoint;
    private bool pret;
    bool alreadyAttacked;

    public Transform archer;

    public Transform joueur; 

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private void Update()
    {
        //trouve et tir
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange && playerInSightRange) tirer();

        if (playerInAttackRange && playerInSightRange);
    }

    public void tirer()
    {
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            // float HorizontalRotation = Input.GetAxis("Horizontal");
            // float VerticalRotation = Input.GetAxis("Vertical");

            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, HorizontalRotation * rotationSpeed, VerticalRotation * rotationSpeed));

            Vector3 direction = joueur.position - archer.position;
           // direction.y = 0;  // On ignore la rotation sur l'axe Y (évite que l'ennemi se penche en avant ou en arrière)
            archer.rotation = Quaternion.LookRotation(direction)*Quaternion.Euler(0f, 95f,0f);
           //archer.rotation = Quaternion.Slerp(archer.rotation, rotation, Time.deltaTime * 5f);  // Lerp pour un mouvement plus fluide


            StartCoroutine("Feu");
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    IEnumerator Feu()
    {
        pret = true;
        GameObject createdCanonball = Instantiate(canonBall, shotPoint.position, shotPoint.rotation);
        createdCanonball.GetComponent<Rigidbody>().velocity = shotPoint.transform.forward * BlastPower;
        yield return new WaitForSeconds(1f);
        pret = false;
        yield return new WaitForSeconds(5f);
        Destroy(createdCanonball);
        yield break;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


}
