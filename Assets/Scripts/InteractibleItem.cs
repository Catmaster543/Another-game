using UnityEngine;

public class InteractibleItem : MonoBehaviour, IInteractable
{
    #region Interactible section
    public string prompt => $"Click to pickup {name}";
    public int stageNeeded => 0;
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
