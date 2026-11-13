using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] public GameObject interactTextObj;
    private TextMeshProUGUI interactText;
    [SerializeField] public Animator uniAnimator;
    [SerializeField] public LineLib lineLib;
    [SerializeField] public MisterDialogue misterDialogue;
    [SerializeField] public TextMeshProUGUI objectiveText;
    [SerializeField] public Animator objectiveAnimator;
    [SerializeField] public TextMeshProUGUI tipText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void ReBind()
    {
        
    }

    void Start()
    {
        interactText = interactTextObj.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    public void UpdateInteractText(string text)
    {
        interactText.text = text;
    }
}
