using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cible : MonoBehaviour
{
    public GameObject particules; // Particules � activer lorsqu'un boulet touche
    public GameObject boulet; // R�f�rence au boulet (boulet d�truit au contact)
    public compteTir script; // R�f�rence au script pour compter les tirs

    public int health = 10; // Nombre de points de vie du boss
    private bool stop; // Emp�che plusieurs actions simultan�es

    public int compte;

    private void OnTriggerEnter(Collider other)
    {
        // Si le tag est "boulet" et que l'action n'est pas d�j� en cours
        if (other.CompareTag("boulet") && !stop)
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
        Debug.Log($"Cible touch�e ! Sant� restante : {health}");

        // D�truit le boulet
        Destroy(boulet);

        // Joue les particules d'impact
        if (particules != null)
        {
            particules.SetActive(true);
            particules.GetComponent<ParticleSystem>().Play();
        }

        // Si la sant� atteint z�ro, d�sactiver ou d�truire la cible
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
        Debug.Log("La cible est d�truite !");
        // Vous pouvez ajouter ici d'autres effets de destruction (sons, particules, etc.)
        gameObject.SetActive(false); // D�sactive la cible
        script.compte(); // Compte le tir final ou d�clenche une action sp�cifique

        // Facultatif : Jouer un effet de destruction (particules, sons, etc.)
    }

    private IEnumerator Reussite()
    {
        Debug.Log("R�ussite !");

        yield return new WaitForSeconds(3f); // Attend 3 secondes

        ReloadScene(); // Appelle la m�thode Recommencer
    }

    public void ReloadScene()
    {
        // Recharge la sc�ne active
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Recommencer()
    {
        Debug.Log("Recommencer appel� !");

        // R�initialisation de la position de la cible ou d'autres comportements n�cessaires
    }
}
