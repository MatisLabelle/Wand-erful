using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class controlJeu : MonoBehaviour
{
    public bool etat = false;
    public GameObject video1;
    public GameObject video2;

    public void ouverture(){
        if (etat)
        {
            video1.SetActive(true);
        } else
        {
            video2.SetActive(true);
        }
        etat = !etat;
    }

    public void fermeture()
    {
        video1.SetActive(false);
        video2.SetActive(false);
    }

    public void jouer()
    {
        SceneManager.LoadScene(0);
    }

    public void quitterPartie()
    {
        Application.Quit();
    }

}
