using System;
using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;

public class VoiceController : MonoBehaviour {

    const string LANG_CODE = "en-US";
    [SerializeField]
    Text uiText;

    void Start() {
        Setup(LANG_CODE);

        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
    }

    public void SetSpeechToTextActive(bool active) {
        if (active) StartListening();
        else StopListening();
    }

    void StartListening() {
        SpeechToText.instance.StartRecording();
    }

    void StopListening() {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result) {
        uiText.text = result;
        Debug.Log("OnFinalSpeechResult result: " + result);
    }

    void Setup(string languageCode) {
        SpeechToText.instance.Setting(languageCode);
    }
}
