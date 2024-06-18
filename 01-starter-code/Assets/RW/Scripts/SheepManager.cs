using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    public bool canSpawn = true;

    public Sheep sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns;

    private List<Sheep> sheepList = new List<Sheep>();

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        Sheep sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheep.OnAteHay.AddListener(HandleSheepEatenHay);
        sheep.OnDropped.AddListener(HandleSheepDropped);
        sheepList.Add(sheep);
    }

    private void HandleSheepEatenHay(Sheep sheep)
    {
        sheepList.Remove(sheep);
        GameManager.Instance.SaveSheep();
        Debug.Log("Sheep saved");
        // Later we could add some points here.
    }

    private void HandleSheepDropped(Sheep sheep)
    {
        sheepList.Remove(sheep);
        GameManager.Instance.DroppedSheep();
        Debug.Log("Sheep dropped");
        // later, we could subtract lives here.
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnSheep();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
