using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class tir : MonoBehaviour
{

    public float rotationSpeed = 1;
    public float BlastPower = 2;

    public GameObject canonBall;
    public Transform shotPoint;
    private bool bouclier;
    private bool pret;

    public GameObject shield;
    public GameObject boss;

    [SerializeField] private InputActionProperty shieldButton;

    
    public AudioClip tirSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (shieldButton.action.IsPressed())
        {
            apparaitre();
            bouclier = true;
        }
        else 
        {
            disparaitre();
            bouclier = false;
        }

    }

    public void tirer()
    {
        float HorizontalRotation = Input.GetAxis("Horizontal");
        float VerticalRotation = Input.GetAxis("Vertical");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, HorizontalRotation * rotationSpeed, VerticalRotation * rotationSpeed));

        if (tirSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(tirSound);
        }

        StartCoroutine("Feu");
    }

    public void apparaitre()
    {
        shield.SetActive(true);
    }

    public void disparaitre()
    {
        shield.SetActive(false);
    }

    IEnumerator Feu()
    {
        pret = true;
        GameObject createdCanonball = Instantiate(canonBall, shotPoint.position, shotPoint.rotation);
        createdCanonball.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * BlastPower;
        yield return new WaitForSeconds(1f);
        pret = false;
        yield return new WaitForSeconds(5f);
        Destroy(createdCanonball);
        yield break;
    }



}