using TMPro;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private TextMeshProUGUI objectiveText;

    void Start()
    {
        UpdateObjective("Talk to Edwin");
    }

    void Update()
    {
        
    }

    public void UpdateObjective(string text)
    {
        objectiveText.text = $"● {text}";
    }
}
