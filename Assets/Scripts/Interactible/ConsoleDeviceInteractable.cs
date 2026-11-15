using UnityEngine;

public class ConsoleDeviceInteractable : MonoBehaviour, IInteractable
{
    #region Interacteable stuff
    public string prompt => "Pick up the strange device";
    public void Interact(Player player)
    {
        player.consoleUnlocked = true;
        player.storyManager.Progress();
        GameObject destroyTarget = gameObject.transform.parent.gameObject;
        Destroy(destroyTarget);
    }
    public int stageNeeded => 0;
    #endregion
}
