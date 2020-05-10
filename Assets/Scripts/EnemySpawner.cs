using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnText;
    [SerializeField] AudioClip spawnedEnemySFX;
    int spawns = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnText.text = "Spawned : " + spawns.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawns += 1;
            spawnText.text = "Spawned : " + spawns.ToString();
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
