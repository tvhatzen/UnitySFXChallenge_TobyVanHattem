using UnityEngine;

public class PauseAudioAndAnimationOnTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animator;
    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    private void Start()
    {
        // Store the default position and rotation of the animated object
        if (animator != null)
        {
            defaultPosition = animator.transform.position;
            defaultRotation = animator.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pause audio if it's playing
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Pause();
            }

            // Pause animation and reset position/rotation
            if (animator != null)
            {
                animator.enabled = false; // Disables the animator, pausing any ongoing animation
                animator.transform.position = defaultPosition;
                animator.transform.rotation = defaultRotation;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Unpause audio if it was paused
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.UnPause();
            }

            // Resume animation
            if (animator != null)
            {
                animator.enabled = true; // Re-enables the animator
            }
        }
    }
}
