public interface IInteractable
{
    string prompt { get; }
    void Interact(Player player);
}
