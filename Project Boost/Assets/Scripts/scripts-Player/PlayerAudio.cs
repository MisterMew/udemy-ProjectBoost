using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    /* Variables */
    public AudioSource rocketThrustAudio;


    public void PlayAudio(AudioSource audio, bool playAudio = true)
    {
        if (playAudio && !audio.isPlaying) 
            audio.Play();
        
        if (!playAudio)
            audio.Stop();
    }
}
