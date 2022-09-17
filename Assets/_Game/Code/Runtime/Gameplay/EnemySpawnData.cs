using System;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class EnemySpawnData
    {
        public int Count;
        public Vector2 FieldSize = Vector2.one * 100f; 
        public GameObject Prefab;
        public EnemyData[] Types;
    }
}