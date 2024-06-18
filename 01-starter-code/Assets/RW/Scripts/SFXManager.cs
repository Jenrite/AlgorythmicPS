using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioClip ShootSFX;
    public AudioClip SheepHitSFX;
    public AudioClip SheepDropSFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayShootSFX()
    {
        PlaySound(ShootSFX);
    }

    public void PlaySheepHitSFX()
    {
        PlaySound(SheepHitSFX);
    }

    public void PlaySheepDropSFX()
    {
        PlaySound(SheepDropSFX);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        }
    }
}

