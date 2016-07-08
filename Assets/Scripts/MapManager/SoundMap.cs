using UnityEngine;
using System.Collections;

public class SoundMap : MonoBehaviour {

    public AudioClip AmbientSound;
    public AudioClip FightStageSound;
    public AudioClip GameOver;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	public void PlayAmbientSound()
    {
        audioSource.clip = AmbientSound;
        audioSource.Play();
    }

    public void PlayFightStageSound()
    {
        audioSource.clip = FightStageSound;
        audioSource.Play();
    }

    public void PlayGameOver()
    {
        audioSource.clip = GameOver;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
