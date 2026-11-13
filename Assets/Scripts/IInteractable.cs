public interface IInteractable
{
    string prompt { get; }
    int stageNeeded { get; }
    void Interact(Player player);
}
