using UnityEngine;
using System.Collections;

public class PlaySoundEffectOnTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffectSource;
    [SerializeField] private Transform speakerTransform;
    [SerializeField] private float jumpHeight = 0.5f; // Height of the jump
    [SerializeField] private float jumpDuration = 0.2f; // Duration of the jump up and down
    private bool hasPlayed = false;
    private Vector3 originalPosition;

    private void Start()
    {
        if (speakerTransform != null)
        {
            originalPosition = speakerTransform.position; // Store the original position
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            if (soundEffectSource != null)
            {
                soundEffectSource.Play();
                hasPlayed = true;
                if (speakerTransform != null)
                {
                    StartCoroutine(JumpSpeaker());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayed = false; // Reset for the next entry
        }
    }

    private IEnumerator JumpSpeaker()
    {
        // Move up
        Vector3 targetPosition = originalPosition + Vector3.up * jumpHeight;
        float elapsedTime = 0f;

        while (elapsedTime < jumpDuration)
        {
            speakerTransform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / jumpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        speakerTransform.position = targetPosition;

        // Move back down
        elapsedTime = 0f;
        while (elapsedTime < jumpDuration)
        {
            speakerTransform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / jumpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        speakerTransform.position = originalPosition;
    }
}