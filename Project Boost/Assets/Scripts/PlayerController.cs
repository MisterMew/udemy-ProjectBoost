using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* Variables */
    private Rigidbody rigidbody = default;
    [SerializeField] private float mainThrustForce = 0F;
    [SerializeField] private float rotationAngle = 0F;

    void Start()
    {
        rigidbody = GetComponentInChildren<Rigidbody>();
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
