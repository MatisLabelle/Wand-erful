using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class compteTir : MonoBehaviour
{
    public int count;

   
    public void compte()
    {
        count += 1;
        if (count >= 10)
        {
            Debug.Log("Dead");
        }
    }

    
}
