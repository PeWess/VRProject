using UnityEngine;

public class PadlockUnlock : MonoBehaviour
{
    public GameObject _suitableKey;
    public GameObject _lockedDoor;

    private Collider _keyCol;

    private void Awake()
    {
        _keyCol = _suitableKey.GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == _keyCol)
        {
            _lockedDoor.GetComponent<DoorBehaviour>().OnPadlockUnlocked();
            Destroy(_suitableKey);
            Destroy(gameObject);
        }
    }
}
