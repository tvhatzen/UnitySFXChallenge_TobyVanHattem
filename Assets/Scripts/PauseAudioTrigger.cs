using UnityEngine;

public class PauseAudioOnTrigger : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource; // Ensure this line is exactly as shown

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.UnPause();
            }
        }
    }
}