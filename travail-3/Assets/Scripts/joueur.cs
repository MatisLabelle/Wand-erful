using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class joueur : MonoBehaviour
{
    public GameObject ampoule;
    public GameObject ampoule2;
    public GameObject bravo;
    public GameObject btnRestart;
    public GameObject quitter;
    public GameObject statues;
    public CharacterController player;

    public VideoPlayer ecran;

    public Animator porteSortie;
    public Animator porteEntre;
    public Animator spotlight;

    public int count;

    public TextMeshProUGUI pointage;
    


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "porte_sortie")
        {
            ampoule.SetActive(true);
            ampoule2.SetActive(true);
            porteSortie.Play("DoorOpenBack");
        }
        else if (other.tag == "spotlight")
        {
            spotlight.Play("FadeIn");
        }
        else if (other.tag == "television")
        {
            ecran.enabled = true ;
        }
        else if (other.tag == "porte_entre")
        {
            //ampoule.SetActive(true);
            //ampoule2.SetActive(true);
            porteEntre.Play("DoorOpen");
        }
        else if (other.tag == "statue")
        {
            other.gameObject.SetActive(false);
            count++;
            pointage.text = count.ToString();
            if(count >= 4)
            {
                StartCoroutine("Reussite");
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "porte_sortie")
        {
            ampoule.SetActive(false);
            ampoule2.SetActive(false);
            porteSortie.Play("DoorCloseBack");
        }
        else if (other.tag == "spotlight")
        {
            spotlight.Play("FadeOut");
        }
        else if (other.tag == "television")
        {
            ecran.enabled = false;
        }
        else if (other.tag == "porte_entre")
        {
            ampoule.SetActive(false);
            ampoule2.SetActive(false);
            porteEntre.Play("DoorClose");
        }
       
    }


    private IEnumerator Reussite()
    {
        bravo.SetActive(true);
        yield return new WaitForSeconds(5f);
        btnRestart.SetActive(true);
        yield break;
    }

    public void miseAZero()
    {
        bravo.SetActive(false);
        btnRestart.SetActive(false);
        count = 0;
        pointage.text = count.ToString();

        for (int i = 0; i < statues.transform.childCount; i++)
        {
            statues.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
        }
    }

    public void fermerJeu()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            
            quitter.SetActive(true);

        }
    }
    public GameObject personnage; // Assurez-vous d'assigner votre personnage dans l'inspecteur

    public void Teleporter()
    {
       


            personnage.GetComponent<CharacterController>().enabled = false;

            // Utilisation du Vector3 pour la téléportation
            personnage.transform.position = new Vector3(-50.28f, 0.89f, -9.6f);

            personnage.GetComponent<CharacterController>().enabled = true;
        }
    }


