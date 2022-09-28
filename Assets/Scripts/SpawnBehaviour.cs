using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject ghost_preab;
    private GameObject ghost;

    public Transform[] spawn_points;
    
    void Start()
    {
        InvokeRepeating("Round", 5.0f, 15.0f);
    }

    private void Round()
    {
        Debug.Log("Round started");
        StartCoroutine("Spawn");
    }
    
    IEnumerator Spawn()
    {
        var spawn_point = spawn_points[Random.Range(0, spawn_points.Length)];
        ghost = Instantiate(ghost_preab, spawn_point.position, spawn_point.rotation);
        Debug.Log("The ghost has appeared");

        yield return new WaitForSeconds(10.0f);
        Destroy(ghost);
        Debug.Log("The ghost is gone");
        Debug.Log("Round finished");
    }
}
