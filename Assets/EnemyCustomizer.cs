using UnityEngine;

public class EnemyCustomizer : MonoBehaviour
{
    public SpriteRenderer topRenderer;
    public SpriteRenderer midRenderer;
    public SpriteRenderer bottomRenderer;
    
    public Sprite[] topOptions;
    public Sprite[] midOptions;
    public Sprite[] bottomOptions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
        if (OutfitData.Instance != null)
        {
            var data = OutfitData.Instance;
            SetOutfit
            (
                data.topIndex,
                data.midIndex,
                data.bottomIndex
            );
        }
    }

    // Update is called once per frame
    void SetOutfit(int topIndex, int midIndex, int bottomIndex)
    {
        topRenderer.sprite = topOptions[topIndex];
        midRenderer.sprite = midOptions[midIndex];
        bottomRenderer.sprite = bottomOptions[bottomIndex];
    }
}
