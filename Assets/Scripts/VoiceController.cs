using TextSpeech;
using UnityEngine;

public class VoiceController : MonoBehaviour {

    const string LANG_CODE = "en-US";
    [SerializeField]
    AudioController audioController;

    void Start() {
        Setup(LANG_CODE);

        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        SpeechToText.instance.onPartialResultCallback = OnPartialSpeechResult;

        StartListening();
    }

    void StartListening() {
        SpeechToText.instance.StartRecording();
    }

    void StopListening() {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result) {
        if (result == "Hello") {
            audioController.SayHello();
        }

        StartListening();
    }

    void OnPartialSpeechResult(string result) {
        StopListening();
    }

    void Setup(string languageCode) {
        SpeechToText.instance.Setting(languageCode);
    }

}
