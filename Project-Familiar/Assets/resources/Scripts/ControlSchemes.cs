using UnityEngine;

public class ControlSchemes : MonoBehaviour
{
    public GameObject keyboard;

    public GameObject gamePad;

    void Update()
    {
        if (!SceneControl.IsKeyboard)
        {
            gamePad.SetActive(true);
            keyboard.SetActive(false);
        }

        if (SceneControl.IsKeyboard)
        {
            gamePad.SetActive(false);
            keyboard.SetActive(true);
        }
    }
}
