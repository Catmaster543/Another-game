using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Speaker : MonoBehaviour, IInteractable
{
    public string prompt => $"Talk to {name}";
    public void Interact(Player player)
    {
        Debug.Log("Blah blah blah");

        storyManager.UpdateObjective("You did it, good job!");
    }

    public string name;
    public Speaker speakersObject;

    public StoryManager storyManager;

    void Start()
    {
        storyManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<StoryManager>();
    }
}
