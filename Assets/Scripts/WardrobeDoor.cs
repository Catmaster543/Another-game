using UnityEngine;

public class WardrobeDoor : MonoBehaviour, IInteractable
{
    bool open = false;
    Animator animator;
    float rateTimer;
    #region Interacteable stuff
    public string prompt => $"Interact with wardrobe door";
    public int stageNeeded => 0;
    public void Interact(Player player)
    {
        if (open)
        {
            animator.SetTrigger("Close");
            open = false;
        }
        else
        {
            animator.SetTrigger("Open");
            open = true;
        }
    }
    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
