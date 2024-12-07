using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class compteTir : MonoBehaviour
{
    public int count;

    
    public void compte()
    {
        count += 1;
        if (count >= 1)
        {
            Debug.Log("Dead");

        }
    }

    
}
