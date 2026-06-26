using UnityEngine;

public abstract class CollectableItem : MonoBehaviour, iCollectable
{
    public AudioClip PickupSFX;

    public void Collected(PlayerController PC)
    {
        OnItemCollected(PC);
    }
    public abstract void OnSpawned();
    public abstract void OnItemCollected(PlayerController PC);
    public void Spawn()
    {
        OnSpawned();
    }
}
