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

        // Thrust
        if (Input.GetKey(KeyCode.Space))
            StartRocketThrust();
        else
            StopRocketThrust();

        // Tilt Left
        if (Input.GetKey(KeyCode.A))
        {
            HandleRotation(rotationAngle);
            playerParticles.ToggleSideThrust("R", true);
        }
        else
        {
            playerParticles.ToggleSideThrust("R", false);
        }

        // Tilt Right
        if (Input.GetKey(KeyCode.D))
        {
            HandleRotation(-rotationAngle);
            playerParticles.ToggleSideThrust("L", true);
        }
        else
        {
            playerParticles.ToggleSideThrust("L", false);
        }
    }

    private void StartRocketThrust()
    {
        rigidbody.AddRelativeForce(Vector3.up * mainThrustForce * Time.deltaTime, ForceMode.Force);
        playerAudio.PlayAudio(playerAudio.sfxRocketThrust);
        playerParticles.ToggleMainThrust();
    }
    private void StopRocketThrust()
    {
        playerAudio.PlayAudio(playerAudio.sfxRocketThrust, false);
        playerParticles.ToggleMainThrust(false);
    }

    private void HandleRotation(float rotationAngle)
    {
        transform.Rotate(Vector3.forward * rotationAngle * Time.deltaTime);
    }
}
