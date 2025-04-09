using UnityEngine;

public class PickupPage : MonoBehaviour , IInteractable
{
    public Interactor interactScript;
    public void Interact()
    {
        Debug.Log("Pickup Page" + interactScript.pagesCollected);
        interactScript.pagesCollected += 1;
        Destroy(gameObject);
    }
}
