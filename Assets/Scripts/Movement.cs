using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    // Controller & Manager
    public Animator _animator;

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            _animator.SetBool("IsWalking", !_animator.GetBool("IsWalking"));
        }
    }
}
