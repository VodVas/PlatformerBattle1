public class Coin : CollectibleItem
{
    public bool IsCollected { get; private set; } = false;

    public override void Collect()
    {
        if (!IsCollected)
        {
            IsCollected = true;
        }
    }

    public void Reset()
    {
        IsCollected = false;
    }
}