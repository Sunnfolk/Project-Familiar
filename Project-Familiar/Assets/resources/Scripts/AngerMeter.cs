using UnityEngine;


public class AngerMeter : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    public float meter = 1f;
    public bool AngerStop;
    void Start()
    {
        
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        SpriteRenderer.sprite = Resources.Load<Sprite>("sprites/AngerMeter/"+ meter);
        if (meter == 19)
        {
            AngerStop = true;
        }
        else
        {
            AngerStop = false;
        }
    }
}
