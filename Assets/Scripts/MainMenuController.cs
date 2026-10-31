using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Animator mainMenuAnimator;
    public void PlayButtonPress()
    {
        mainMenuAnimator.SetTrigger("Play");
    }

    public void QuitButtonPress()
    {
        Application.Quit();
    }
}
