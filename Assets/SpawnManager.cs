using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnLocation;
    [SerializeField] private GameObject cat;
    [SerializeField] private float interval;
    [SerializeField] private float delayInterval;

    private void Start()
    {
     InvokeRepeating(nameof(SpawnCat),delayInterval, interval);   
    }

    private void SpawnCat()
    {
        int spawnLocation = Random.Range(0, _spawnLocation.Length);
        Vector3 spawnPosition = _spawnLocation[spawnLocation].transform.position;

        // Set rotation based on spawnLocation
        Quaternion spawnRotation = Quaternion.Euler(0, spawnLocation == 1 ? 90f : -90f, 0);

        var catSpawn = Instantiate(cat, spawnPosition, spawnRotation);

        Rigidbody catRb = catSpawn.GetComponent<Rigidbody>();
        if (spawnLocation == 0)
        {
            catSpawn.transform.DOMove(new Vector3(-2f, 0f, 0f),2f);
        }
        else if (spawnLocation == 1)
        {
            catSpawn.transform.DOMove(new Vector3(2f, 0f, 0f), 2f);

        }
    }


}
