using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public GameStateManager Instance;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SwitchToConsoleWorld()
    {
        SceneManager.LoadScene("ConsoleWorld", LoadSceneMode.Single);
    }

    public void SwitchToMainWorld()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
