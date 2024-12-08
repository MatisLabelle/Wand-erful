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
        Debug.Log($"Cible touchée ! Santé restante : {health}");

        // Détruit le boulet
        Destroy(boulet);

        // Joue les particules d'impact
        if (particules != null)
        {
            particules.SetActive(true);
            particules.GetComponent<ParticleSystem>().Play();
        }

        // Si la santé atteint zéro, désactiver ou détruire la cible
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
        Debug.Log("La cible est détruite !");
        // Vous pouvez ajouter ici d'autres effets de destruction (sons, particules, etc.)
        gameObject.SetActive(false); // Désactive la cible
        script.compte(); // Compte le tir final ou déclenche une action spécifique

        // Facultatif : Jouer un effet de destruction (particules, sons, etc.)
    }

    private IEnumerator Reussite()
    {
        Debug.Log("Réussite !");

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

        // Réinitialisation de la position de la cible ou d'autres comportements nécessaires
    }
}
