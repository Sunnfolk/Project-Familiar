using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private PauseMenu m_PauseMenu;

    private void Start()
    {
        m_PauseMenu = GetComponent<PauseMenu>();
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
}