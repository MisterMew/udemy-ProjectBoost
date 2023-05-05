using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    /* Variables */
    [HideInInspector] public bool debug_disableCollision = false;

    private LevelManager levelManager = default;
    private PlayerAudio playerAudio = default;
    private PlayerController playerController = default;
    private PlayerParticles playerParticles = default;
    private const string rocketPadTag = "RocketPad";

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        playerAudio = GetComponentInChildren<PlayerAudio>();
        playerController = GetComponentInChildren<PlayerController>();
        playerParticles = GetComponentInChildren<PlayerParticles>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (playerController.disableControl || debug_disableCollision) return;

        switch (collision.gameObject.tag)
        {
            case rocketPadTag:
                break;
            default:
                //Handle crash
                playerController.disableControl = true;

                playerParticles.crashExplosion.Play();
                playerAudio.PlayAudio(playerAudio.sfxRocketCollision);
                Invoke("RocketCrash", 1f);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Handle Success
        if (other.gameObject.tag == rocketPadTag)
        {
            playerController.disableControl = true;

            playerParticles.winParticles.Play();
            playerAudio.PlayAudio(playerAudio.sfxLevelWin);
            levelManager.NextLevel();
        }
    }

    private void RocketCrash()
    {
        levelManager.ResetLevel();
    }
}
