using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    private void Awake()
    {
        UIManager.OnMousePressed += () =>
        {
            if(sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }

            sfxSource.Play();
        };
    }
}
