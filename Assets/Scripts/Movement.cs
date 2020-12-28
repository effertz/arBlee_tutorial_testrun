using UnityEngine;

public class Movement : MonoBehaviour {
    float _speed = 0.5f;

    Animator _animator;
    CharacterController _controller;

    public void SetWalking(bool isWalking) {
        if (_animator != null) _animator.SetBool("IsWalking", isWalking);
    }

    void Start() {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();

        if (_animator == null) Debug.LogError("_animator is NULL");
        if (_controller == null) Debug.LogError("_controller is NULL");
    }

    void Update() {
        if (_animator.GetBool("IsWalking")) MoveForward();
    }

    void MoveForward() {
        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = direction * _speed;

        velocity = transform.transform.TransformDirection(velocity);

        _controller.Move(velocity * Time.deltaTime);
    }
}
