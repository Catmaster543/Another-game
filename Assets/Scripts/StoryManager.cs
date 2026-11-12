using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StoryManager : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private Stage[] stages;
    [SerializeField] private Player player;
    [SerializeField] private UIManager uiManager;

    [Header("Shared References")]
    public int progress { get; private set; } = -1;
    public static StoryManager instance { get; private set; }

    public GameObject playerPrefab;
    public Transform playerSpawn;
    public Player refPlayer;

    [System.Serializable]
    public class Stage
    {
        public string name;
        public UnityEvent method;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        player = Instantiate(playerPrefab).GetComponent<Player>();
        player.uiManager = uiManager;
    }

    public void ReBindReferences()
    {
        uiManager.uniAnimator = GameObject.FindGameObjectWithTag("UniCanvas").GetComponent<Animator>();
        uiManager.objectiveText = GameObject.FindGameObjectWithTag("ObjectiveText").GetComponent<TextMeshProUGUI>();
        uiManager.objectiveAnimator = GameObject.FindGameObjectWithTag("ObjectiveText").GetComponent<Animator>();
    }

    public void Progress()
    {
        Debug.Log("Progressing..");
        progress++;
        if (progress <= stages.Length)
        {
            stages[progress].method.Invoke();
        }
    }

    public IEnumerator UpdateObjective(string text)
    {
        yield return new WaitForSeconds(0.1f);
        uiManager.objectiveAnimator.SetTrigger("Highlight");
        yield return new WaitForSeconds(0.2f);
        uiManager.objectiveText.text = $"● {text}";
    }

    #region Story specific voids
    public void Stage1()
    {
        uiManager.uniAnimator.SetTrigger("ExitML");
        StartCoroutine(UpdateObjective("Take a look around."));
        StartCoroutine(player.WaitForLookingAround());
    }

    public void Stage2()
    {
        StartCoroutine(UpdateObjective("Take Sedwick the ball's cousin and put him inside the wardrobe"));
    }

    public void Stage3()
    {
        Debug.Log("Hello Stage 3");
        //Bind this void on LeManager's StoryManagers stages
        //Just make a new Stage, select LeManager as an object and select this void
    }
    #endregion
}
