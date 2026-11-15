using System.Collections;
using TMPro;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public UIManager uiManager;
    TextMeshProUGUI tipText;
    public bool leverOn = false;

    Animator Animator;
    void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
        tipText = uiManager.tipText;
    }
    #region Interacteable stuff
    public string prompt => "?.?.?";
    public void Interact(Player player)
    {
        StartCoroutine(LeverInteract());
    }
    public int stageNeeded => 0;
    #endregion
    IEnumerator LeverInteract()
    {
        Animator.SetTrigger("Interact");
        tipText.text = "Debug";
        if (leverOn == false)
        {
            leverOn = true;
        }
        else
        {
            leverOn = false;
        }

        yield return null;
    }
}
//i HAVE NO WAY TO TEST IT RN
//FIH
//YEET
