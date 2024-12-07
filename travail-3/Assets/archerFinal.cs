using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class archerFinal : MonoBehaviour
{
    public GameObject bravo;
    public GameObject monJoueur;
    public GameObject dollards;
    public GameObject startPosition;

    public GameObject boss;
    private void Die()
    {
        StartCoroutine(Reussite()); // Lance la coroutine
        Debug.Log("Le boss est détruit !");
        boss.SetActive(false); // Désactive le boss

        // Facultatif : Jouer un effet de destruction (particules, sons, etc.)
    }


    private IEnumerator Reussite()
    {
        bravo.SetActive(true); // Active l'objet "Bravo"
        Debug.Log("Bravo activé");

        yield return new WaitForSeconds(3f); // Attend 3 secondes

        ReloadScene(); // Appelle la méthode Recommencer
    }

    public void ReloadScene()
    {
        // Recharge la scène active
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Recommencer()
    {
        Debug.Log("Recommencer appelé !");

        bravo.SetActive(false); // Désactive l'objet "Bravo"

        // Replace le joueur à la position de départ
        if (startPosition != null && monJoueur != null)
        {
            monJoueur.transform.position = startPosition.transform.position;
        }
        else
        {
            Debug.LogWarning("startPosition ou monJoueur n'est pas assigné !");
        }

        // Réactive tous les enfants de "dollards"
        if (dollards != null)
        {
            for (int i = 0; i < dollards.transform.childCount; i++)
            {
                Transform child = dollards.transform.GetChild(i).GetChild(0);
                if (child != null)
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    Debug.LogWarning($"Child {i} de dollards est null !");
                }
            }
        }
        else
        {
            Debug.LogWarning("dollards n'est pas assigné !");
        }
    }
}
