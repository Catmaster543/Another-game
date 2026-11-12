using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public GameStateManager Instance;
    public CurrentGameState currentGameState;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Switch()
    {
        if (currentGameState == CurrentGameState.MainWorld)
        {
            SwitchToConsoleWorld();
        }
        else
        {
            SwitchToMainWorld();
        }
    }

    public void SwitchToConsoleWorld()
    {
        SceneManager.LoadScene("ConsoleWorld", LoadSceneMode.Single);
        currentGameState = CurrentGameState.ConsoleWorld;
    }

    public void SwitchToMainWorld()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        currentGameState = CurrentGameState.MainWorld;
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

    public enum CurrentGameState
    {
        MainWorld,
        ConsoleWorld
    }
}
