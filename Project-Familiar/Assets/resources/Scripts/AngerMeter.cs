using UnityEngine;


public class AngerMeter : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    public float meter = 1f;
    void Start()
    {
        
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        SpriteRenderer.sprite = Resources.Load<Sprite>("sprites/AngerMeter/"+ meter);
    }
}
