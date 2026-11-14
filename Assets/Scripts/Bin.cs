using System.Collections;
using TMPro;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public UIManager uiManager;
    TextMeshProUGUI tipText;
    public AudioSource staticSound;

    Animator binAnim;
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        binAnim = gameObject.GetComponent<Animator>();
        tipText = uiManager.tipText;
    }
    #region Interacteable stuff
    public string prompt => "Interact with the bin";
    public void Interact(Player player)
    {
        binAnim.SetTrigger("Out");
        tipText.text = "Debug";
        StartCoroutine(BinInterract());
    }
    public int stageNeeded => 1;
    //I have no clue what this is
    #endregion
    IEnumerator BinInterract()
    {
        binAnim.SetTrigger("Out");
        tipText.text = "Debug";
        yield return null;
    }
}

//I really don't know what you expected