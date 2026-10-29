using UnityEngine;

public class InteractibleItem : MonoBehaviour, IInteractable
{

    #region Interactible section
    public string prompt => $"Click to pickup {name}";
    public void Interact(Player player)
    {
        player.PickUpInteraction(this.gameObject);
    }
    #endregion

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
