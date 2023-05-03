using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public ParticleSystem crashExplosion = null;
    public ParticleSystem winParticles = null;
    public ParticleSystem mainThrustParticles = null;
    public ParticleSystem leftThrustParticles = null;
    public ParticleSystem rightThrustParticles = null;
    public List<ParticleSystem> mainThrusterParticles = new List<ParticleSystem>();

    public void ToggleMainThrust(bool enable = true)
    {
        foreach (ParticleSystem part in mainThrusterParticles)
        {
            if (enable)
                part.Play();

            else if (!enable)
                part.Stop();
        }
    }

    public void ToggleSideThrust(bool toggleLeft, bool toggleRight)
    {
        if (toggleLeft)
        {
            leftThrustParticles.Play();
            rightThrustParticles.Stop();
        }
        else if (toggleRight)
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Play();
        }
    }
}