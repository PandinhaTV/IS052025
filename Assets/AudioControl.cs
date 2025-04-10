using UnityEngine;

using UnityEngine.Audio;
public class AudioControl : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickAudio()
    {
        int x= Random.Range(0, audioClips.Length);
        Debug.Log("Picking Audio");
        audioSource.PlayOneShot(audioClips[x]);

    }
}
