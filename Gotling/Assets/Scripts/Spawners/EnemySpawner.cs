using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public float distance;
    private List<GameObject> enemies;

	private void Awake()
	{
		enemies = new List<GameObject>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckEnemies())
		{
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
        var num = Mathf.RoundToInt(Random.Range(0, 3));
		for (int i = 0; i < num; i++)
        {
            SpawnEnemy();
        }
	}

    private void SpawnEnemy()
	{
        enemies.Add(Instantiate(enemy1, Random.insideUnitCircle.normalized * distance, Quaternion.identity));
	}
}
