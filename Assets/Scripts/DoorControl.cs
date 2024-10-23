using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Animator doorAnimator; // Reference to the Animator controlling the door
    private bool isPlayerNearDoor = false; // To track if the player is near the door
    private bool isDoorOpen = false; // To track if the door is currently open

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDoorOpen) // When the player is near the door and it's not open
        {
            isPlayerNearDoor = true;
            OpenDoor(); // Call the function to open the door
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isDoorOpen) // When the player leaves and the door is open
        {
            isPlayerNearDoor = false;
            CloseDoor(); // Call the function to close the door
        }
    }

    private void OpenDoor()
    {
        // Play the door's open animation
        doorAnimator.Play("DoorOpen");
        isDoorOpen = true; // Set the door status to open
    }

    private void CloseDoor()
    {
        // Play the door's close animation
        doorAnimator.Play("DoorClose");
        isDoorOpen = false; // Set the door status to closed
    }
}
