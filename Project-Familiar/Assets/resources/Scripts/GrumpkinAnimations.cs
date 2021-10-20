using UnityEngine;

public class GrumpkinAnimations : MonoBehaviour
{
    public bool playerClose;
    private bool sus;
    public bool target;
    private Animator m_Animator;
    private PlayerMove m_Move;
    private ItemRequest m_ItemRequest;
    private bool m_IsTarget;

    private void Start()
    {
        m_ItemRequest = GameObject.Find("Cauldron").GetComponent<ItemRequest>();
        m_Animator = GetComponent<Animator>();
        m_Move = GetComponent<PlayerMove>();
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
        else
        {
            m_Animator.Play("GrumpkinIdle");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerClose = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerClose = false;
    }
}
