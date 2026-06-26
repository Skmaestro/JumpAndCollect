using System.Collections;
using UnityEngine;

public class Collectables_CubesWithAnimation : CollectableItem
{
    public int GainPoints = 1;
    public override void OnItemCollected(PlayerController PC)
    {
        SimpleSFX.Instance.PlaySFX(PickupSFX);
        PC.PlayerCollectAbility.AddPoints(GainPoints);
        StartCoroutine(PlayAnimation());
    }
    IEnumerator PlayAnimation()
    {
        var c = GetComponent<Collider>();
        if (c != null)
            c.enabled = false;

        Vector3 startScale = transform.localScale;
        Vector3 startPos = transform.position;

        float duration = 0.3f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            transform.Rotate(0f, 720f * Time.deltaTime, 0f);

            transform.position = startPos + Vector3.up * t * 0.5f;

            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, t);

            yield return null;
        }

        Destroy(gameObject);
    }
    public override void OnSpawned()
    {
        
    }
}
