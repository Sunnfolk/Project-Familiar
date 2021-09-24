using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInput : MonoBehaviour
{
   
    [HideInInspector] public Vector2 moveVector;
    [HideInInspector] public bool dash;
    [HideInInspector] public bool interact;
    void Update()
    {
        moveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
        moveVector.y = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.wKey.isPressed ? 1f : 0f);

        dash = Keyboard.current.shiftKey.wasPressedThisFrame;
    }
}

