using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class compteTir : MonoBehaviour
{
    public int count;

    public GameObject bravo;
    public GameObject restart;
    public GameObject monJoueur;
    public GameObject dollards;
    public GameObject startPosition;


    private IEnumerator reussite()
    {
        bravo.SetActive(true);
        Debug.Log("Bravo activ�");
        yield return new WaitForSeconds(3f);
        restart.SetActive(true);
        yield break;
    }

    public void recommencer()
    {
        bravo.SetActive(false);
        restart.SetActive(false);

        monJoueur.transform.position = startPosition.transform.position;

        for (int i = 0; i < dollards.transform.childCount; i++)
        {
            dollards.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
        }
    }
    public void compte()
    {
        count += 1;
        if (count >= 1)
        {
            Debug.Log("Dead");
            StartCoroutine(reussite());
        }
    }

    
}
