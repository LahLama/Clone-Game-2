using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level02", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void LoadMainMenu(string menuSceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName, LoadSceneMode.Single);
    }
}