using System;
using UnityEngine;
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

    private void Awake()
    {
        _controller = gameObject.GetComponent<CharacterController>();
        _gravity = new Vector3(0, 9.81f, 0);
        _movementSpeed = 1.0f;
    }

    private void Update()
    {
        _direction = 
            Player.instance.hmdTransform.TransformDirection(new Vector3(_moveInput.axis.x, 0, _moveInput.axis.y));
        _controller.Move(_movementSpeed * Time.deltaTime * Vector3.ProjectOnPlane(_direction, Vector3.up) -
                         _gravity * Time.deltaTime);
    }
}
