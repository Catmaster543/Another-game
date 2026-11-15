using System.Collections;
using TMPro;
using UnityEngine;

public class Cactus : MonoBehaviour, IInteractable
{
    public UIManager uiManager;
    TextMeshProUGUI tipText;

    Animator Animator;
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        Animator = gameObject.GetComponent<Animator>();
        tipText = uiManager.tipText;
    }
    #region Interacteable stuff
    public string prompt => "Cactus";
    public void Interact(Player player)
    {
        StartCoroutine(CactusInteract());
    }
    public int stageNeeded => 0;
    //I have no clue what this is
    #endregion
    IEnumerator CactusInteract()
    {
        Animator.SetTrigger("Interact");
        tipText.text = "???";
        yield return null;
    }
}

//Yes, it was necessary.
//It was fun.
//WEEEEUMMMMMM