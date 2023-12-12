using UnityEngine;

public class PuzzleParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ps1;
    [SerializeField] private ParticleSystem _ps2;
    [SerializeField] private ParticleSystem _ps3;

    void Update()
    {
        if (!_ps1.isPlaying)
        {
            _ps1.Play();
        }
        if (!_ps2.isPlaying)
        {
            _ps2.Play();
        }
        if (!_ps3.isPlaying)
        {
            _ps3.Play();
        }
    }
}
