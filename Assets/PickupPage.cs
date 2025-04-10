using System;
using TMPro;
using UnityEngine;

public class PickupPage : MonoBehaviour , IInteractable
{
    public Interactor interactScript;
    public TextMeshProUGUI text;
    public AudioControl audioClip;
    public void Interact()
    {
        
        Debug.Log("Pickup Page" + interactScript.pagesCollected);
        interactScript.pagesCollected += 1;
        audioClip.PickAudio();
        Destroy(gameObject);
    }

    private void Update()
    {
        text.text = ("Pages" + interactScript.pagesCollected);
    }
}
