using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    /* Variables */
    private LevelManager levelManager = default;
    private PlayerAudio playerAudio = default;
    private const string rocketPadTag = "RocketPad";

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        playerAudio = GetComponentInChildren<PlayerAudio>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case rocketPadTag:
                break;
            default:
                gameObject.GetComponent<PlayerController>().enabled = false;
                playerAudio.PlayAudio(playerAudio.sfxRocketCollision);
                Invoke("RocketCrash", 1f);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == rocketPadTag)
        {
            playerAudio.PlayAudio(playerAudio.sfxLevelWin);
            levelManager.NextLevel();
        }
    }

    private void RocketCrash()
    {
        levelManager.ResetLevel();
    }
}
