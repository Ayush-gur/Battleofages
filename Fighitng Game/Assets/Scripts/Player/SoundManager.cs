using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip jumpSFX, attackSFX, kickSFX;

    private void Awake()
    {

        if (sfxSource == null)
        {
            Debug.LogError("AudioSource component not found!");
        }
    }
    public void KickSFX()
    {
        sfxSource.clip = kickSFX;
        sfxSource.Play();
    }
    public void JumpSFX()
    {
        sfxSource.clip = jumpSFX;
        sfxSource.Play();

    }

    public void AttackSFX()
    {
        sfxSource.clip = attackSFX;
        sfxSource.Play();

    }
}
