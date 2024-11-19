using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cible : MonoBehaviour
{
    public GameObject particules;

    public compteTir script;
    private bool stop;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boulet" && stop == false)
        {
            stop = true;
            StartCoroutine("burst");
        }

    }

    IEnumerator burst()
    {

        particules.SetActive(true);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        script.compte();
        yield return new WaitForSeconds(1f);


        yield break;
    }

   
}
