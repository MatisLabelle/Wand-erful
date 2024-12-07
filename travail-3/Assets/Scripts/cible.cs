using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cible : MonoBehaviour
{
    public GameObject particules; // Particules à activer lorsqu'un boulet touche
    public GameObject boulet; // Référence au boulet (boulet détruit au contact)
    public compteTir script; // Référence au script pour compter les tirs

    public int health = 10; // Nombre de points de vie du boss
    private bool stop; // Empêche plusieurs actions simultanées

    public int compte;

    public GameObject bravo;
    public GameObject monJoueur;
    public GameObject dollards;
    public GameObject startPosition;

    public GameObject boss;


    private void OnTriggerEnter(Collider other)
    {
        // Si le tag est "boulet" et que l'action n'est pas déjà en cours
        if (other.CompareTag("boulet") && !stop)
        {
            boulet = other.gameObject;
            StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        stop = true; // Empêche plusieurs tirs simultanés

        // Réduit la santé du boss
        health--;
        Debug.Log($"Boss touché ! Santé restante : {health}");

        // Détruit le boulet
        Destroy(boulet);

        // Joue les particules d'impact
        if (particules != null)
        {
            particules.SetActive(true);
            particules.GetComponent<ParticleSystem>().Play();
        }

        // Si la santé atteint zéro, désactiver ou détruire le boss
        if (health <= 0)
        {
            Die();
        }

        // Temps d'attente pour éviter les collisions répétées
        yield return new WaitForSeconds(0.5f);
        stop = false; // Réautorise les actions après un court délai
    }

    private void Die()
    {
        Debug.Log("Le boss est détruit !");
        boss.SetActive(false); // Désactive le boss
        script.compte(); // Compte le tir final ou déclenche une action spécifique
        
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