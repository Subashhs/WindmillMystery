using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    [SerializeField] private Animator myDoor; // Reference to the door's Animator
    [SerializeField] private bool openTrigger; // Should trigger the door opening
    [SerializeField] private bool closeTrigger; // Should trigger the door closing

    private void OnTriggerEnter(Collider other) // Corrected casing and parameter type
    {
        if (other.CompareTag("Player")) // Check if the collider is tagged as "Player"
        {
            if (openTrigger)
            {
                myDoor.Play("DoorOpen", 0, 0.0f); // Play the open animation
                gameObject.SetActive(false); // Deactivate this trigger (optional)
            }
            else if (closeTrigger)
            {
                myDoor.Play("DoorClose", 0, 0.0f); // Play the close animation
                gameObject.SetActive(false); // Deactivate this trigger (optional)
            }
        }
    }

    private void OnTriggerExit(Collider other) // Handle exit if needed
    {
        if (other.CompareTag("Player"))
        {
            // Optionally, you can also trigger the closing animation here
            // if you want the door to close when the player exits.
            if (closeTrigger)
            {
                myDoor.Play("DoorClose", 0, 0.0f);
                gameObject.SetActive(false); // Deactivate this trigger (optional)
            }
        }
    }
}
