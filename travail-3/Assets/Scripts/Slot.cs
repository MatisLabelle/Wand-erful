using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isOccupied = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("potion"))
        {
            isOccupied = true;
            Debug.Log($"{other.name} placé sur {gameObject.name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("potion"))
        {
            isOccupied = false;
        }
    }
}
