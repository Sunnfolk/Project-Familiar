using UnityEngine;

public class ControlSchemes : MonoBehaviour
{
    public GameObject keyboard;

    public GameObject gamePad;
    private ActionsPlayerInput m_Input;

    private void Awake()
    {
        m_Input = new ActionsPlayerInput();
    }

    void Update()
    {
        if (m_Input.UI.Gamepad.triggered)
        {
            gamePad.SetActive(true);
            keyboard.SetActive(false);
        }
        if (UnityEngine.InputSystem.Keyboard.current.anyKey.wasPressedThisFrame)
        {
            gamePad.SetActive(false);
            keyboard.SetActive(true);
        }
    }
    private void OnEnable()
    {
        m_Input.Enable();
    }

    private void OnDisable()
    {
        m_Input.Disable();
    }
}
