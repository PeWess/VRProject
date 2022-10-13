using System;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] public Transform turnPointTransform;
    [Range(0, 1)] public double openPercent;

    public Animator _animator;

    private Vector3 rotation_start = new Vector3(0, 0, 0);
    private Vector3 rotation_end = new Vector3(0, 90, 0);

    private void Awake()
    {
        _animator.SetBool("PadlockUnlocked", false);
    }

    void Update()
    {
        openPercent = Vector3.Lerp(rotation_start, rotation_end, (turnPointTransform.rotation.eulerAngles.y - 360) / rotation_end.y).y / rotation_end.y;
    }

    public void OnPadlockUnlocked()
    {
        _animator.SetBool("PadlockUnlocked", true);
    }
}
