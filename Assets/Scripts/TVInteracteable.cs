using System.Collections;
using TMPro;
using UnityEngine;

public class TVInteracteable : MonoBehaviour, IInteractable
{
    public UIManager uiManager;
    TextMeshProUGUI tipText;

    #region Interacteable stuff
    public string prompt => "Turn on TV";
    public void Interact(Player player)
    {
        StartCoroutine(TurnOnTv());
    }
    #endregion

    void Start()
    {
        tipText = uiManager.tipText;
    }

    IEnumerator TurnOnTv()
    {
        tipText.gameObject.SetActive(true);
        tipText.text = "You turn on the TV, but nothing happens..";
        yield return new WaitForSeconds(2);
        tipText.gameObject.SetActive(false);
    }
}
