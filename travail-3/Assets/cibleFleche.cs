using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cibleFleche : MonoBehaviour
{
    public int compte;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fleche")
        {
            compte += 1;
            if (compte >= 4)
            {
                Debug.Log("Dead");
            }
           
        }

    }
}
