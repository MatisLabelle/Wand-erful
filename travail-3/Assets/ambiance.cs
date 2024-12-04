using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambiance : MonoBehaviour
{
    public AudioSource audioSource;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger!");
        if (other.tag == "Player" && !audioSource.isPlaying) 
        {
            audioSource.Play();
        }
    }
}
