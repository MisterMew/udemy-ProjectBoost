using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* Variables */
    private Rigidbody rigidbody = default;
    private PlayerAudio playerAudio = default;
    private PlayerParticles playerParticles = default;

    [SerializeField] private float mainThrustForce = 0F;
    [SerializeField] private float rotationAngle = 0F;

    public bool disableControl = false;


    void Awake()
    {
        rigidbody = GetComponentInChildren<Rigidbody>();
        playerAudio = GetComponentInChildren<PlayerAudio>();
        playerParticles = GetComponentInChildren<PlayerParticles>();
    }

    void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        if (disableControl) return;

        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * mainThrustForce * Time.deltaTime, ForceMode.Force);
            playerAudio.PlayAudio(playerAudio.sfxRocketThrust);
            playerParticles.mainThrustParticles.Play();
            playerParticles.ToggleMainThrust(true);
        }
        else
        {
            playerAudio.PlayAudio(playerAudio.sfxRocketThrust, false);
            playerParticles.mainThrustParticles.Stop();
            playerParticles.ToggleMainThrust(false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            HandleRotation(rotationAngle);
            playerParticles.ToggleSideThrust(false, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            HandleRotation(-rotationAngle);
            playerParticles.ToggleSideThrust(true, false);
        }
    }

    private void HandleRotation(float rotationAngle)
    {
        transform.Rotate(Vector3.forward * rotationAngle * Time.deltaTime);
    }
}
