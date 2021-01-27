using TextSpeech;
using UnityEngine;

public class VoiceController : MonoBehaviour {

    const string LANG_CODE = "en-US";
    [SerializeField]
    AudioController audioController;
    [SerializeField]
    Movement movement;

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

        HandleText(result);

        StartListening();
    }

    void OnPartialSpeechResult(string result) {
        StopListening();
    }

    void HandleText(string result) {

        switch (result) {
            case "Hello":
                audioController.SayHello();
                break;
            case "Walk":
                movement.SetWalking(true);
                break;
            case "Stop":
                movement.SetWalking(false);
                break;
            default:
                break;
        }
    }

    void Setup(string languageCode) {
        SpeechToText.instance.Setting(languageCode);
    }

}
