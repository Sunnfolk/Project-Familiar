using UnityEngine;
using UnityEngine.Serialization;


public class AngerMeter : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    public float meter = 1f;
    [HideInInspector] public bool angerStop;
    void Start()
    {
        
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (meter <= 0)
        {
            meter = 1f;
        }
        SpriteRenderer.sprite = Resources.Load<Sprite>("sprites/AngerMeter/"+ meter);
        if (meter >= 19)
        {
            meter = 19;
            angerStop = true;
        }
        else
        {
            angerStop = false;
        }
    }
}
