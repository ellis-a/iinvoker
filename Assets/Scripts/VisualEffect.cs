using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class VisualEffect : MonoBehaviour
{
    private IEnumerable<ParticleSystem> _particleSystems { get; set; }

    private void Start()
    {
        _particleSystems = GetComponents<ParticleSystem>();
    }

    private void Update()
    {
        if (!_particleSystems.Any(x => x.isPlaying))
        {
            Destroy(gameObject);
        }
    }

}

