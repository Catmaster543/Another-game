using UnityEngine;

public class WardrobeDoor : MonoBehaviour, IInteractable
{
    public GameObject otherPos;
    #region Interacteable stuff
    public string prompt => $"{name} wardrobe door";
    public void Interact(Player player)
    {
        otherPos.SetActive(true);
        gameObject.SetActive(false);
    }
    #endregion
}
