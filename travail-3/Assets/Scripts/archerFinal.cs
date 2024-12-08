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

    public GameObject particules; // Particules � activer lorsqu'un boulet touche
    public GameObject boulet; // R�f�rence au boulet (boulet d�truit au contact)
    public compteTir script; // R�f�rence au script pour compter les tirs

    public int health = 10; // Nombre de points de vie du boss
    private bool stop; // Emp�che plusieurs actions simultan�es

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boulet") && !stop) // V�rifie si le boulet touche et emp�che les collisions multiples
        {
            boulet = other.gameObject;
            StartCoroutine(TakeDamage());
        }
    }


    IEnumerator TakeDamage()
    {
        stop = true; // Emp�che plusieurs tirs simultan�s

        // R�duit la sant� du boss
        health--;
        Debug.Log($"Boss touch� ! Sant� restante : {health}");

        // D�truit le boulet
        Destroy(boulet);

        // Joue les particules d'impact
        if (particules != null)
        {
            particules.SetActive(true);
            particules.GetComponent<ParticleSystem>().Play();
        }

        // Si la sant� atteint z�ro, d�sactiver ou d�truire le boss
        if (health <= 0)
        {
            Die();
        }

        // Temps d'attente pour �viter les collisions r�p�t�es
        yield return new WaitForSeconds(0.5f);
        stop = false; // R�autorise les actions apr�s un court d�lai
    }
    private void Die()
    {
        StartCoroutine(Reussite()); // Lance la coroutine
        Debug.Log("Le boss est d�truit !");
        boss.SetActive(false); // D�sactive le boss

        // Facultatif : Jouer un effet de destruction (particules, sons, etc.)
    }


    private IEnumerator Reussite()
    {
        bravo.SetActive(true); // Active l'objet "Bravo"
        Debug.Log("Bravo activ�");

        yield return new WaitForSeconds(3f); // Attend 3 secondes

        ReloadScene(); // Appelle la m�thode Recommencer
    }

    public void ReloadScene()
    {
        // Recharge la sc�ne active
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
