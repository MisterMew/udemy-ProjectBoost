using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    /* Variables */
    private LevelManager levelManager = default;
    private const string rocketPadTag = "RocketPad";

    private void Awake() => levelManager = FindObjectOfType<LevelManager>();

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case rocketPadTag:
                Debug.Log(">SAFE<");
                break;
            default:
                Debug.Log(">COLLISION<");
                levelManager.ResetLevel();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == rocketPadTag)
            levelManager.NextLevel();
    }
}
