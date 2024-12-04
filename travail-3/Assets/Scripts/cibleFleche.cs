using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cibleFleche : MonoBehaviour
{
    public int compte;

    public GameObject bravo;
    public GameObject restart;
    public GameObject monJoueur;
    public GameObject dollards;
    public GameObject startPosition;
    public InputActionAsset inputActions;

    private IEnumerator Reussite()
    {
        inputActions.Disable();
        bravo.SetActive(true);
        Debug.Log("Bravo activé");
        yield return new WaitForSeconds(1f);
        restart.SetActive(true);
        yield break;
    }

    public void Recommencer()
    {
        bravo.SetActive(false);
        restart.SetActive(false);
        inputActions.Enable();

        monJoueur.transform.position = startPosition.transform.position;

        for (int i = 0; i < dollards.transform.childCount; i++)
        {
            dollards.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "fleche")
        {
            return;
        }
        compte += 1;
        if (compte >= 10)
        {
            Debug.Log("Dead");
            StartCoroutine(Reussite());
        }
    }
}
