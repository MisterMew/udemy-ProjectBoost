using UnityEngine;

public class PBDebug : MonoBehaviour
{
    /* Variables */
    private PlayerCollision playerCollision = default;
    private LevelManager levelManager = default;

    void Awake()
    {
        playerCollision = FindObjectOfType<PlayerCollision>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) ToggleCollisions();
        if (Input.GetKeyDown(KeyCode.L)) ToggleNextLevel();
    }

    bool toggle = true;
    private void ToggleCollisions()
    {
        toggle = !toggle;

        playerCollision.debug_disableCollision = toggle;
        Debug.Log("Collisions: " + toggle.ToString());
    }

    private void ToggleNextLevel()
    {
        levelManager.NextLevel();
        Debug.Log("DEBUG: Next Level");
    }
}
