using UnityEngine;
using UnityEngine.Rendering;

public class OutfitData : MonoBehaviour
{
    public static OutfitData Instance;

    public int topIndex;
    public int midIndex;
    public int bottomIndex;

    public Sprite[] topOptions;
    public Sprite[] midOptions;
    public Sprite[] bottomOptions;

    public bool firstTime = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FirstTime()
    {
        firstTime = true;
    }
}