using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tir : MonoBehaviour
{

    public float rotationSpeed = 1;
    public float BlastPower = 2;

    public GameObject canonBall;
    public Transform shotPoint;
    private bool pret;
     


    public void tirer()
    {

        float HorizontalRotation = Input.GetAxis("Horizontal");
        float VerticalRotation = Input.GetAxis("Vertical");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, HorizontalRotation * rotationSpeed, VerticalRotation * rotationSpeed));
        StartCoroutine("Feu");
    }



    IEnumerator Feu()
    {
        pret = true;
        GameObject createdCanonball = Instantiate(canonBall, shotPoint.position, shotPoint.rotation);
        createdCanonball.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * BlastPower;
        yield return new WaitForSeconds(1f);
        pret = false;
        yield return new WaitForSeconds(5f);
        Destroy(createdCanonball);
        yield break;
    }

   
}