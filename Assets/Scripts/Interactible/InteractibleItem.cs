using UnityEngine;

public class InteractibleItem : MonoBehaviour, IInteractable
{
    #region Interactible section
    public string prompt => $"Click to pickup {name}";
    public int stageNeeded => 1;
    public void Interact(Player player)
    {
        player.PickUpInteraction(this.gameObject);
    }
    #endregion

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        
    }
}
