using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmove : MonoBehaviour {

    public float speed = 3.0f;
    public float gravity = -9.8f;
    public AudioSource _SourceAudio;
    public AudioClip _ClipAudio;
    public AudioClip _Shot;

    private CharacterController _charController;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            _SourceAudio.clip = _ClipAudio;
           _SourceAudio.Play();
        }
        if (Input.GetMouseButtonDown(0))
        {
            _SourceAudio.clip = _Shot;
            _SourceAudio.Play();
        }

    float deltaX = Input.GetAxis("Horizontal") * speed;
    float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
