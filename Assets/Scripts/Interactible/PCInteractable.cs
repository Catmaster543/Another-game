using UnityEngine;

public class PCInteractable : MonoBehaviour, IInteractable
{
    Animator animator;
    public GameObject sedwick;
    public GameObject[] marbles;

    #region Interactable stuff
    public string prompt => "Use PC";
    public int stageNeeded => 1;
    public void Interact(Player player)
    {
        if (player.heldObj == sedwick)
        {
            Destroy(player.heldObj);
            player.isHoldingObj = false;
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
       //whatcha looking for??
       //FIH
    }

    public void ReleaseMarbles()
    {
        Debug.Log("Releasing the marbles");
        foreach (GameObject marble in marbles)
        {
            Debug.Log($"Releasing {marble.name}");
            marble.SetActive(true);
        }
    }
}
