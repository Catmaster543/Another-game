using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayButtonPress()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButtonPress()
    {
        Application.Quit();
    }
}
