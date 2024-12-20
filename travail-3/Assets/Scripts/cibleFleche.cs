using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class cibleFleche : MonoBehaviour
{
    public int compte;

    public GameObject bravo;
    public GameObject monJoueur;
    public GameObject dollards;
    public GameObject startPosition;
    public InputActionAsset inputActions;

    private IEnumerator Reussite()
    {
        inputActions.Disable(); // D�sactive les entr�es
        bravo.SetActive(true); // Active l'objet "Bravo"
        Debug.Log("Bravo activ�");

        yield return new WaitForSeconds(3f); // Attend 3 secondes

        Recommencer(); // Appelle la m�thode Recommencer
    }

    public void Recommencer()
    {
        Debug.Log("Recommencer appel� !");

        bravo.SetActive(false); // D�sactive l'objet "Bravo"
        inputActions.Enable(); // R�active les entr�es

        // Replace le joueur � la position de d�part
        if (startPosition != null && monJoueur != null)
        {
            monJoueur.transform.position = startPosition.transform.position;
        }
        else
        {
            Debug.LogWarning("startPosition ou monJoueur n'est pas assign� !");
        }

        // R�active tous les enfants de "dollards"
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
            Debug.LogWarning("dollards n'est pas assign� !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fleche"))
        {
            compte += 1; // Incr�mente le compteur

            if (compte >= 10)
            {
                Debug.Log("Dead");
                StartCoroutine(Reussite()); // Lance la coroutine
                compte = 0;
            }
        }
    }
}
