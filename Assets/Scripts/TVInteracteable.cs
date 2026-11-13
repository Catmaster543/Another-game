using System.Collections;
using TMPro;
using UnityEngine;

public class TVInteracteable : MonoBehaviour, IInteractable
{
    public UIManager uiManager;
    TextMeshProUGUI tipText;
    public AudioSource staticSound;

    #region Interacteable stuff
    public string prompt => "Turn on TV";
    public int stageNeeded => 1;
    public void Interact(Player player)
    {
        if (player.heldObj != null)
        {
            StartCoroutine(TurnOnTv());
        }
        else
        {
            StartCoroutine(FailTvTurnOn());
        }
    }
    #endregion

    void Start()
    {
        tipText = uiManager.tipText;
    }
    
    IEnumerator TurnOnTv()
    {
        //staticSound.Play();
        yield return new WaitForSeconds(2f);
        //Play TV cutscene
        //*yield return new WaitForSeconds(*animlenght*)
        GameObject.FindGameObjectWithTag("MainManager").GetComponent<StoryManager>().Progress();
    }
    IEnumerator FailTvTurnOn()
    {
        tipText.gameObject.SetActive(true);
        tipText.text = "You turn on the TV, but nothing happens..";
        yield return new WaitForSeconds(2);
        tipText.gameObject.SetActive(false);
    }
}
