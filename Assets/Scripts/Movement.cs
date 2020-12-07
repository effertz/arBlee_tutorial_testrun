using UnityEngine;

public class Movement : MonoBehaviour {
    public Animator _animator;

    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            _animator.SetBool("IsWalking", !_animator.GetBool("IsWalking"));
        }
    }
}
