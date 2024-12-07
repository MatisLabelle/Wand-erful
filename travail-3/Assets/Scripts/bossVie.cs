using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 10; // Nombre de boulets n�cessaires pour d�truire le boss
    public GameObject explosionEffect; // Effet visuel � jouer lorsque le boss est d�truit

    private void OnCollisionEnter(Collision collision)
    {
        // V�rifie si l'objet entrant est un boulet
        if (collision.gameObject.CompareTag("boulet"))
        {
            health--; // R�duit la sant� du boss
            Debug.Log("Le boss a �t� touch� ! Sant� restante : " + health);

            // D�truit le boulet
            Destroy(collision.gameObject);

            // V�rifie si la sant� atteint z�ro
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Debug.Log("Le boss est d�truit !");

        // Jouer un effet visuel si d�fini
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // D�truit ou d�sactive le boss
        Destroy(gameObject); // Utilisez `SetActive(false)` si vous voulez d�sactiver le boss au lieu de le d�truire.
    }
}
