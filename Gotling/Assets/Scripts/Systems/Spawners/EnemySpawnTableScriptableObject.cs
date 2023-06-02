using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnTableScriptableObject", menuName ="ScriptableObject/EnemySpawnTable")]
public class EnemySpawnTableScriptableObject : ScriptableObject
{
    [SerializeField]
    List<SpawnGroup> spawnGroups;
    public List<SpawnGroup> SpawnGroups { get => spawnGroups; private set => spawnGroups = value; }

    // Indexer declaration
    public SpawnGroup this[int index]
    {
        get
		{
            return SpawnGroups[index];
		}
    }

    public int Count { get { return spawnGroups.Count; } }

    [System.Serializable]
    public class SpawnGroup
    {
        [SerializeField]
        public GameObject[] enemies;
    }
}
