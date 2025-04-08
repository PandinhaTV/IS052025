using UnityEngine;

public class OutfitData : MonoBehaviour
{
    public static OutfitData Instance;

    public int topIndex;
    public int midIndex;
    public int bottomIndex;

    public Sprite[] topOptions;
    public Sprite[] midOptions;
    public Sprite[] bottomOptions;

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
}