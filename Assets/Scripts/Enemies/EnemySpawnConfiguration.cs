using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemySpawnConfiguration
{
    [field: SerializeField] public Transform SpawnPosition { get; private set; }
}
