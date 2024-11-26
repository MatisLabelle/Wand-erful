using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Slot[] slots; // Assigner ici les socles via l'inspecteur
    public GameObject door; // La porte à ouvrir
    public float doorOpenSpeed = 1f; // Vitesse d'ouverture de la porte
    private bool doorOpened = false;

    void Update()
    {
        if (!doorOpened && AllSlotsOccupied())
        {
            OpenDoor();
        }
    }

    private bool AllSlotsOccupied()
    {
        foreach (Slot slot in slots)
        {
            if (!slot.isOccupied)
                return false;
        }
        return true;
    }

    private void OpenDoor()
    {
        doorOpened = true;
        // Exemple : déplace la porte vers le haut
        StartCoroutine(OpenDoorAnimation());
    }

    private System.Collections.IEnumerator OpenDoorAnimation()
    {
        Vector3 targetPosition = door.transform.position + Vector3.up * 5f; // Déplacement vers le haut
        while (Vector3.Distance(door.transform.position, targetPosition) > 0.01f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, doorOpenSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
