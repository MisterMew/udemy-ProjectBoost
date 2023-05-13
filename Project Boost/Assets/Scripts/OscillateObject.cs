using System.Collections.Generic;
using UnityEngine;

public class OscillateObject : MonoBehaviour
{
    /* Variables */
    [SerializeField] private GameObject targetObject;
    
    private Vector3 startingPos = Vector3.zero;
    [SerializeField] private Vector3 movementVector = Vector3.zero;
    [SerializeField, Range(0, 1)] private float movementFactor = 1f;
    [SerializeField, Range(0, 10)] private float cycleLength = 1f;

    private void Awake()
    {
        startingPos = CurrentPos(targetObject);
    }

    private void Update()
    {
        Oscillate();
    }

    private void Oscillate()
    {
        float oscillationCycles = cycleLength * Time.time; //Get the number of cycles

        const float tau = Mathf.PI * 2f; //tau = full radius of a circle in radians
        float rawSinWave = Mathf.Sin(oscillationCycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;

        targetObject.transform.position = startingPos + offset;
    }

    private Vector3 CurrentPos(GameObject gameobject)
    {
        return gameobject.transform.position;
    }
}
