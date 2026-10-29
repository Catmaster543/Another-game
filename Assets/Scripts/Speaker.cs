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
    }

    public string name;
    public Speaker speakersObject;
    public Sprite quietSprite;
    public Sprite talkSprite;
}
