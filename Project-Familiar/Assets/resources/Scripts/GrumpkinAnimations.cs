using UnityEngine;

public class GrumpkinAnimations : MonoBehaviour
{
    private bool playerClose;
    private bool sus;
    private bool target;
    private Animator m_Animator;
    private ItemRequest m_ItemRequest;
    private bool m_IsTarget;
    private float emotion;

    private void Start()
    {
        m_ItemRequest = GameObject.Find("Cauldron").GetComponent<ItemRequest>();
        m_Animator = GetComponent<Animator>();
        emotion = Random.Range(0, 1000);
    }


    void Update()
    {
        foreach (var item in m_ItemRequest.spawnedItems)
        {
            if (gameObject.CompareTag(item.tag))
            {
                target = true;
                m_IsTarget = true;
            }
            else if (!m_IsTarget)
            {
                target = false;
            }
        }
        m_IsTarget = false;
        if (playerClose)
        {
            m_Animator.Play("GrumpkinScared");
        }

        else if (target)
        {
            m_Animator.Play("GrumpkinConcerned");
        }
        else if (emotion <=10)
        {
            m_Animator.Play("GrumpkinYes");
        }
        else if (emotion <=50)
        {
            m_Animator.Play("GrumpkinCool");
        }
        else if (emotion <=100)
        {
            m_Animator.Play("GrumpkinSus");
        }
        else if (emotion <=200)
        {
            m_Animator.Play("GrumpkinTongue");
        }
        else if (emotion <=500)
        {
            m_Animator.Play("GrumpkinLeft");
        }
        else
        {
            m_Animator.Play("GrumpkinIdle");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerClose = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerClose = false;
        }
    }
}
