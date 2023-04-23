using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    /* Variables */
    private AudioSource audioSource = default;
    public AudioClip sfxRocketThrust = null;
    public AudioClip sfxRocketCollision = null;
    public AudioClip sfxLevelWin = null;

    private void Awake() => audioSource = GetComponentInChildren<AudioSource>();

    public void PlayAudio(AudioClip audioClip, bool playAudio = true)
    {
        if (playAudio && !audioSource.isPlaying)
            audioSource.PlayOneShot(audioClip);
        
        if (!playAudio)
            audioSource.Stop();
    }
}
