using System.Collections.Generic;
using UnityEngine;

public class SimpleSFX : MonoBehaviour
{
    public static SimpleSFX Instance;
    private AudioSource AS;

    private void Awake()
    {
        Instance = this;
        TryGetComponent(out AS);
    }
   
    public void PlaySFX(AudioClip clip, float volume=1)
    {
        AS.PlayOneShot(clip, volume);
    }
}
