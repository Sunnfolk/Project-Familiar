using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private PauseMenu m_PauseMenu;
    public static bool IsKeyboard;
    private ActionsPlayerInput m_Input;

    private void Awake()
    {
        m_Input = new ActionsPlayerInput();
    }

    private void Start()
    {
        m_PauseMenu = GetComponent<PauseMenu>();
    }
    void Update()
    {
        if (m_Input.UI.Gamepad.triggered)
        {
            IsKeyboard = false;
        }
        
        if (Keyboard.current.anyKey.wasPressedThisFrame || m_Input.UI.Mouse.triggered)
        {
            IsKeyboard = true;
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        if (m_PauseMenu != null)
        {
            m_PauseMenu.Resume();
        }
    }

 public void QuitGame()
    {
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
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