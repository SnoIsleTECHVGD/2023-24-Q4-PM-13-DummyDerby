using UnityEngine;

public class PlayAudioOnKeyPress : MonoBehaviour
{
   // public AudioClip audioClip; // Assign your audio clip in the inspector
    public AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Make sure audio clip is assigned
      //  if (audioClip == null)
        {
          //  Debug.LogError("Audio clip is not assigned!");
        }
    }

    void Update()
    {
        // Check if the 'E' key or '.' key is pressed
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Period))
        {
           
                audioSource.Play();
            
        }
    }
}
