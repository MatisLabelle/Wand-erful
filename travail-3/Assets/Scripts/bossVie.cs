using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 10; // Nombre de boulets nécessaires pour détruire le boss
    public GameObject explosionEffect; // Effet visuel à jouer lorsque le boss est détruit

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet entrant est un boulet
        if (collision.gameObject.CompareTag("boulet"))
        {
            health--; // Réduit la santé du boss
            Debug.Log("Le boss a été touché ! Santé restante : " + health);

            // Détruit le boulet
            Destroy(collision.gameObject);

            // Vérifie si la santé atteint zéro
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Debug.Log("Le boss est détruit !");

        // Jouer un effet visuel si défini
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // Détruit ou désactive le boss
        Destroy(gameObject); // Utilisez `SetActive(false)` si vous voulez désactiver le boss au lieu de le détruire.
    }
}
