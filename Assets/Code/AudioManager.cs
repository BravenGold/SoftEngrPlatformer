using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip startMusic;
    public AudioClip loopedMusic;
    public AudioClip oneUp;
    public AudioClip collectable;
    public AudioClip crouch;
    public AudioClip hit;
    public AudioClip extraJump;
    public AudioClip jump;
    public AudioClip landing;
    public AudioClip poyo;
    public AudioClip victory;
    public AudioClip death;

    private bool pauseMusic = false;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = startMusic;
        musicSource.Play();
        PlaySFX(poyo);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
        if (clip == victory || clip == death)
        {
            if (musicSource.isPlaying)
            {
                musicSource.Pause();
                pauseMusic = true;
            }

        }
        if(clip == victory || clip == hit)
        {
            sfxSource.PlayOneShot(poyo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!sfxSource.isPlaying) 
        {
            pauseMusic = false;
        }
        if (!musicSource.isPlaying && !pauseMusic)
        {
            // Switch to the second song
            musicSource.clip = loopedMusic;
            musicSource.Play();
        }
        //Conditionals for stopping the music for the victory and death sfxs
 

        //conditionals for kirby saying "poyo"

    }
}
