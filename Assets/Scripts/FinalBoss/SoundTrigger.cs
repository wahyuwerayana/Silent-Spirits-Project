using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip newSound; 
    public GameObject bgmObject; // GameObject yang memutar background sound
    private AudioSource bgmAudioSource; // Audio source untuk background sound
    private Collider2D triggerCollider; 

    private void Start()
    {
       
        if (bgmObject != null)
        {
            bgmAudioSource = bgmObject.GetComponent<AudioSource>();
            if (bgmAudioSource == null)
            {
                Debug.LogError("No AudioSource component found on BGM object!");
            }
        }
        else
        {
            Debug.LogError("BGM object is not assigned!");
        }

      
        triggerCollider = GetComponent<Collider2D>();
        if (triggerCollider == null)
        {
            Debug.LogError("No Collider2D component found on the trigger object!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.CompareTag("Player"))
        {
            
            if (bgmAudioSource != null && bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Stop();
            }

            if (newSound != null)
            {
                bgmAudioSource.clip = newSound;
                bgmAudioSource.loop = false;
                bgmAudioSource.volume = 0.2f;
                bgmAudioSource.Play();
            }

            
            if (triggerCollider != null)
            {
                triggerCollider.enabled = false;
            }
        }
    }
}
