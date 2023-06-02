using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public float distance;
    private List<GameObject> enemies;

    [SerializeField]
    public EnemySpawnTableScriptableObject spawnTable;

    private float difficulty;

	private void Awake()
	{
		enemies = new List<GameObject>();
	}

	// Start is called before the first frame update
	void Start()
    {
        difficulty = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckEnemies())
		{
            difficulty++;
            SpawnEnemies();
		}
    }

    private bool CheckEnemies()
	{
        // Remove all destroyed enemies
        enemies.RemoveAll(o => o == null);
        return enemies.Count > 0;
	}

    private void SpawnEnemies()
	{
        var spawnGroup = spawnTable[Mathf.RoundToInt(Random.Range(0, spawnTable.Count))];
		for (int i = 0; i < spawnGroup.enemies.Length; i++)
        {
            SpawnEnemy(spawnGroup.enemies[i]);
        }
	}

    private void SpawnEnemy(GameObject enemy)
	{
        var instance = Instantiate(enemy, Random.insideUnitCircle.normalized * distance, Quaternion.identity);
        var stats = instance.GetComponent<LevelManager>();

        // TODO make difficulty scalor equation or table
        stats.SetStartingLevel(difficulty);
        enemies.Add(instance);
	}
}
