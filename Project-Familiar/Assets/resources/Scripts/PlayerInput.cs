using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInput : MonoBehaviour
{
   

    [HideInInspector] public Vector2 moveVector;
    [HideInInspector] public bool dash;
    [HideInInspector] public bool interact;
    [HideInInspector] public float KeyLastP;

    void Update()
    {
        moveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
        moveVector.y = (Keyboard.current.sKey.isPressed ? -1f : 0f) + (Keyboard.current.wKey.isPressed ? 1f : 0f);

        dash = Keyboard.current.shiftKey.wasPressedThisFrame;
        interact = Keyboard.current.eKey.wasPressedThisFrame;
        LastInputCheck();
    }

    private void LastInputCheck()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            KeyLastP = 0f;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            KeyLastP = 1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            KeyLastP = 2f;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            KeyLastP = 3f;
        }
    }
}