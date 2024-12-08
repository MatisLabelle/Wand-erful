using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class archerFinal : MonoBehaviour
{
    public GameObject bravo;
    public GameObject monJoueur;
    public GameObject dollards;
    public GameObject startPosition;

    public GameObject boss;

    public GameObject particules; // Particules à activer lorsqu'un boulet touche
    public GameObject boulet; // Référence au boulet (boulet détruit au contact)
    public compteTir script; // Référence au script pour compter les tirs

    public int health = 10; // Nombre de points de vie du boss
    private bool stop; // Empêche plusieurs actions simultanées

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boulet") && !stop) // Vérifie si le boulet touche et empêche les collisions multiples
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
    
}
