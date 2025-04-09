using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizer : MonoBehaviour
{
    public SpriteRenderer topRenderer;
    public SpriteRenderer midRenderer;
    public SpriteRenderer bottomRenderer;

    public Sprite[] topOptions;
    public Sprite[] midOptions;
    public Sprite[] bottomOptions;

    private int topIndex = 0;
    private int midIndex = 0;
    private int bottomIndex = 0;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public bool acabou = false;
    public AudioSource audioSource;
    public void NextTop()
    {
        topIndex = (topIndex + 1) % topOptions.Length;
        topRenderer.sprite = topOptions[topIndex];
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    public void PreviousTop()
    {
        topIndex = (topIndex - 1 + topOptions.Length) % topOptions.Length;
        topRenderer.sprite = topOptions[topIndex];
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    public void NextMid()
    {
        midIndex = (midIndex + 1) % midOptions.Length;
        midRenderer.sprite = midOptions[midIndex];
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    public void PreviousMid()
    {
        midIndex = (midIndex - 1 + midOptions.Length) % midOptions.Length;
        midRenderer.sprite = midOptions[midIndex];
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    public void NextBottom()
    {
        bottomIndex = (bottomIndex + 1) % bottomOptions.Length;
        bottomRenderer.sprite = bottomOptions[bottomIndex];
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    public void PreviousBottom()
    {
        bottomIndex = (bottomIndex - 1 + bottomOptions.Length) % bottomOptions.Length;
        bottomRenderer.sprite = bottomOptions[bottomIndex];
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    public void NextScene()
    {
        audioSource.clip = audioClip2;
        audioSource.Play();
        if (!audioSource.isPlaying)
        {
            acabou = true;
        }
        SaveCustomizationToOutfitData();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
    }
    void SaveCustomizationToOutfitData()
    {
        OutfitData.Instance.topIndex = topIndex;
        OutfitData.Instance.midIndex = midIndex;
        OutfitData.Instance.bottomIndex = bottomIndex;

        OutfitData.Instance.topOptions = topOptions;
        OutfitData.Instance.midOptions = midOptions;
        OutfitData.Instance.bottomOptions = bottomOptions;
    }

    private void Update()
    {
        if (acabou == true)
        {
            SaveCustomizationToOutfitData();
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}