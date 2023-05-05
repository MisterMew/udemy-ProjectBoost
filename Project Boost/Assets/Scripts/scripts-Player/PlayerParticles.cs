using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    [SerializeField] public ParticleSystem crashExplosion = null;
    [SerializeField] public ParticleSystem winParticles = null;
    [SerializeField] public ParticleSystem leftThrustParticles = null;
    [SerializeField] public ParticleSystem rightThrustParticles = null;
    [SerializeField] private List<ParticleSystem> mainThrusterParticles = new List<ParticleSystem>();

    public void Play(ParticleSystem ptSys)
    {
        if (!ptSys.isPlaying)
            ptSys.Play();
    }
    public void Stop(ParticleSystem prtSys)
    {
        if (prtSys.isPlaying)
            prtSys.Stop();
    }

    public void ToggleMainThrust(bool toggleMain = true)
    {
        foreach (ParticleSystem part in mainThrusterParticles)
        {
            if (toggleMain)
                Play(part);

            else if (!toggleMain)
                Stop(part);
        }
    }

    public void ToggleSideThrust(string LR, bool enable)
    {
        ParticleSystem particleSystem = null;

        if (LR == "L") particleSystem = leftThrustParticles;
        else if (LR == "R") particleSystem = rightThrustParticles;

        if (enable)
                Play(particleSystem);
            else
                Stop(particleSystem);
    }
}