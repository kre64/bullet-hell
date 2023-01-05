using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  public GameObject slimePrefab;
  public GameObject bigSlimePrefab;
  public float slimeInterval = 1f;
  public float bigSlimeInterval = 4f;

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(spawnEnemy(slimeInterval, slimePrefab));
    StartCoroutine(spawnEnemy(bigSlimeInterval, bigSlimePrefab));
  }

  private IEnumerator spawnEnemy(float interval, GameObject enemy)
  {
    yield return new WaitForSeconds(interval);
    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
    StartCoroutine(spawnEnemy(interval, enemy));
  }
}
