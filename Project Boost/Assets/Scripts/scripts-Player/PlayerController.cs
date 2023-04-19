using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* Variables */
    private Rigidbody rigidbody = default;
    private PlayerAudio playerAudio = default;

    [SerializeField] private float mainThrustForce = 0F;
    [SerializeField] private float rotationAngle = 0F;

    void Awake()
    {
        rigidbody = GetComponentInChildren<Rigidbody>();
        playerAudio = GetComponentInChildren<PlayerAudio>();
    }

    void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * mainThrustForce * Time.deltaTime, ForceMode.Force);
            playerAudio.PlayAudio(playerAudio.rocketThrustAudio);
        }
        else
        {
            playerAudio.PlayAudio(playerAudio.rocketThrustAudio, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            HandleRotation(rotationAngle);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            HandleRotation(-rotationAngle);
        }
    }

    private void HandleRotation(float rotationAngle)
    {
        transform.Rotate(Vector3.forward * rotationAngle * Time.deltaTime);
    }
}
