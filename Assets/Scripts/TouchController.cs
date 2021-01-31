using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class TouchController : MonoBehaviour {
    public UnityEvent OnSingleTap;
    public UnityEvent OnDoubleTap;
    public UnityEvent OnLongPressBegin;
    public UnityEvent OnLongPressEnd;


    float firstTapTime = 0f;
    const float timeBetweenTaps = 0.5f;
    const float shortestLongPress = 0.5f;
    bool doubleTapInitialized;
    bool longPressInProgress;
    private IEnumerator LongPressCoroutine;


    void OnMouseDown() {
        LongPressCoroutine = LongPressRecognition();
        StartCoroutine(LongPressCoroutine);
    }

    IEnumerator LongPressRecognition() {
        yield return new WaitForSeconds(shortestLongPress);
        LongPressBegin();
    }

    void StopLongPressRecognition() {
        StopCoroutine(LongPressCoroutine);
        longPressInProgress = false;
    }

    void OnMouseUp() {
        Invoke("SingleTap", timeBetweenTaps);

        if (longPressInProgress) LongPressEnd();
        else StopLongPressRecognition();

        if (!doubleTapInitialized) {
            doubleTapInitialized = true;
            firstTapTime = Time.time;
        } else if (Time.time - firstTapTime < timeBetweenTaps) {
            CancelInvoke("SingleTap");
            DoubleTap();
        }
    }

    void SingleTap() {
        doubleTapInitialized = false;
        if (OnSingleTap != null) {
            OnSingleTap.Invoke();
        }
    }

    void DoubleTap() {
        doubleTapInitialized = false;
        if (OnDoubleTap != null) {
            OnDoubleTap.Invoke();
        }
    }

    void LongPressBegin() {
        longPressInProgress = true;
        if (OnLongPressBegin != null) {
            OnLongPressBegin.Invoke();
        }
    }

    void LongPressEnd() {
        longPressInProgress = false;
        if (OnLongPressEnd != null) {
            OnLongPressEnd.Invoke();
        }
    }
}
