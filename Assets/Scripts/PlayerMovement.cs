using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SteamVR_Action_Vector2 _moveInput;
    [SerializeField] private float _movementSpeed;

    private CharacterController _controller;
    private Vector3 _direction;
    private Vector3 _gravity;

    private PostProcessVolume _volume;
    private Vignette _vignette;
    
    private Vector3 _input;
    private float _intensity;

    private void Awake()
    {
        _controller = gameObject.GetComponent<CharacterController>();
        _gravity = new Vector3(0, 9.81f, 0);
        _movementSpeed = 1.0f;

        _controller = gameObject.GetComponent<CharacterController>();
        _volume = FindObjectOfType<PostProcessVolume>();
    }

    private void Update()
    {
        _input = new Vector3(_moveInput.axis.x, 0, _moveInput.axis.y);
        _direction = 
            Player.instance.hmdTransform.TransformDirection(_input);
        _controller.Move(_movementSpeed * Time.deltaTime * Vector3.ProjectOnPlane(_direction, Vector3.up) -
                         _gravity * Time.deltaTime);

        _volume.profile.TryGetSettings(out _vignette);
        _intensity = Mathf.Lerp(_vignette.intensity.value, _input.normalized.magnitude * 0.7f, Time.deltaTime * 5);
        _vignette.intensity.value = _intensity;
    }
}
