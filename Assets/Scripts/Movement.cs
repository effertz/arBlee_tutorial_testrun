using UnityEngine;

public class Movement : MonoBehaviour {
    float _speed = 0.5f;

    // Controller & Manager
    CharacterController _controller;
    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();

        if (_animator == null) Debug.LogError("_animator is NULL");
        if (_controller == null) Debug.LogError("_controller is NULL");
    }

    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            _animator.SetBool("IsWalking", !_animator.GetBool("IsWalking"));
        }

        if (_animator.GetBool("IsWalking")) MoveForward();
    }

    void MoveForward()
    {
        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = direction * _speed;

        velocity = transform.transform.TransformDirection(velocity);

        _controller.Move(velocity * Time.deltaTime);
    }
}
