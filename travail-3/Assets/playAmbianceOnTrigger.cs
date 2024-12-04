using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAmbianceOnTrigger : MonoBehaviour
{
    public AudioClip clip; // Le clip à jouer
    private AudioSource source; // Composant AudioSource
    public string targetTag; // Tag de l'objet cible
    public bool loopAudio = false; // Option pour activer/désactiver la boucle

    // Initialisation
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.loop = loopAudio; // Configure la propriété loop de l'AudioSource
    }

    // Jouer l'audio lorsque l'objet entre dans la zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && !source.isPlaying)
        {
            source.clip = clip; // Assigner le clip à la source
            source.Play();
        }
    }

    // Arrêter l'audio lorsque l'objet quitte la zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag) && source.isPlaying)
        {
            source.Stop();
        }
    }
}
