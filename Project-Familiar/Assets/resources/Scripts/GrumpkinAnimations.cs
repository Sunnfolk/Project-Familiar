using UnityEngine;

public class GrumpkinAnimations : MonoBehaviour
{
    public bool playerClose;
    private bool sus;
    public bool target;
    private bool left;
    private Animator m_Animator;
    private PlayerMove m_Move;
    private ItemRequest m_ItemRequest;
    private bool m_IsTarget;
    public float emotion;

    private void Start()
    {
        m_ItemRequest = GameObject.Find("Cauldron").GetComponent<ItemRequest>();
        m_Animator = GetComponent<Animator>();
        m_Move = GetComponent<PlayerMove>();
        emotion = Random.Range(0, 100);
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
            m_Animator.Play("GrumpkinSus");
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
