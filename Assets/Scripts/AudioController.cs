using UnityEngine;

public class AudioController : MonoBehaviour {
    private AudioSource helloAudioSource;

    void Start() {
        helloAudioSource = GetComponent<AudioSource>();
        if (helloAudioSource == null) Debug.LogError("helloAudioSource is NULL");
    }

    public void SayHello() {
        if (!helloAudioSource.isPlaying) {
            Debug.Log(" ##### Talk.SayHello play audio.");
            helloAudioSource.Play();
        }
    }
}
