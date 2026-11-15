using UnityEngine;

public class MarbleInteractable : MonoBehaviour, IInteractable
{
    public Rigidbody rb;
    public Material[] materials;

    #region Interacteable stuff
    public string prompt => "Pick up marble";
    public int stageNeeded => 1;
    public void Interact(Player player)
    {
        player.PickUpInteraction(gameObject);
    }
    #endregion

    void Start()
    {
        int rng = Random.Range(0, materials.Length);
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material = materials[rng];
        rb = GetComponent<Rigidbody>();
    }
}
