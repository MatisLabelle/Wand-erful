using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioOnTrigger : MonoBehaviour
{

    public AudioClip clip;
    private AudioSource source;
    public string targetTag;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            source.PlayOneShot(clip);
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
