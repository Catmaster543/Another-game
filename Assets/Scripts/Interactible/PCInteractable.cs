using UnityEngine;

public class PCInteractable : MonoBehaviour, IInteractable
{
    Animator animator;
    public GameObject sedwick;
    #region Interactable stuff
    public string prompt => "Use PC";
    public int stageNeeded => 1;
    public void Interact(Player player)
    {
        if (player.heldObj == sedwick)
        {
            Destroy(player.heldObj);
            animator.SetTrigger("Success");
        }
        else
        {
            animator.SetTrigger("Fail");
        }
    }
    #endregion
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
