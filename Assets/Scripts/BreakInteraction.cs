using UnityEngine;
using Valve.VR.InteractionSystem;

public class BreakInteraction : MonoBehaviour
{
    private Interactable _interactableScript;
    private Rigidbody _rigidBody;
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _interactableScript = GetComponent<Interactable>();

        _rigidBody.useGravity = false;
        _rigidBody.isKinematic = true;
        _interactableScript.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Cube"))
        {
            _rigidBody.useGravity = true;
            _rigidBody.isKinematic = false;
            _interactableScript.enabled = true;
        }
    }
}
