using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject interactTextObj;
    private TextMeshProUGUI interactText;
    [SerializeField] public Animator uniAnimator;
    [SerializeField] public LineObj lineObjStage2;
    [SerializeField] public MisterDialogue misterDialogue;
    [SerializeField] public TextMeshProUGUI objectiveText;
    [SerializeField] public Animator objectiveAnimator;
    [SerializeField] public TextMeshProUGUI tipText;

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
