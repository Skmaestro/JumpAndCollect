using UnityEngine;

public class Collectables_Cubes : CollectableItem
{
    public int GainPoints = 1;
    public override void OnItemCollected(PlayerController PC)
    {
        Destroy(gameObject);
        SimpleSFX.Instance.PlaySFX(PickupSFX);
        PC.PlayerCollectAbility.AddPoints(GainPoints);
    }

    public override void OnSpawned()
    {
        
    }
}
