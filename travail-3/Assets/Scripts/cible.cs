using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cible : MonoBehaviour
{
    public GameObject particules;
    public GameObject boulet; 

    public compteTir script;
    private bool stop;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boulet" && stop == false)
        {
            stop = true;
            boulet = other.gameObject;
            StartCoroutine("burst");
        }

    }

    IEnumerator burst()
    {

        particules.SetActive(true);
        particules.GetComponent<ParticleSystem>().Play();
        Destroy(boulet);
        // gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
       
        script.compte();
        yield return new WaitForSeconds(1f);


        yield break;
    }



   
}
