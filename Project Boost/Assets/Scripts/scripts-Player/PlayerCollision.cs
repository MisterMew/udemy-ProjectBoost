using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    /* Variables */

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "RocketPad":
                Debug.Log(">SAFE<");
                break;
            default:
                Debug.Log(">COLLISION<");
                break;
        }
    }
}
