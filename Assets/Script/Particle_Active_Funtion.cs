using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Active_Funtion : MonoBehaviour
{
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;

    public void ActiveParticle()
    {
        particle1.Play();
        particle2.Play();
        particle3.Play();

    }

      public void StopActiveParticle()
    {
        particle1.Stop();
        particle2.Stop();
        particle3.Stop();

    }

}
