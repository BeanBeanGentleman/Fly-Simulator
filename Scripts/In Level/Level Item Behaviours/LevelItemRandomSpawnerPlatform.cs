using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using In_Level.Level_Item_Behaviours.Ingestable;
using UnityEngine;
using Random = UnityEngine.Random;

namespace In_Level.Level_Item_Behaviours
{
    public class LevelItemRandomSpawnerPlatform : MonoBehaviour
    {
        public SpawnableItem SpawnableObject;

        public Vector3 SpawnDirection = Vector3.down;

        public Bounds RayStartPosition = new Bounds();

        public int SpawnCount = 1;

        private bool ExtremeSpawn = false;
        private void Start()
        {
            if (SpawnableObject == null)
            {
                Debug.LogError("THE SPAWNABLE OBJECT IS NULL! TERMINATING RANDOM SPAWN.");
                return;
            }

            List<SpawnableItem> spawned = new List<SpawnableItem>();
            for (int i = 0; i < SpawnCount; ++i)
            {
                GameObject newFoouuud = GameObject.Instantiate(SpawnableObject.gameObject);
                var a = newFoouuud.GetComponent<SpawnableItem>();
                spawned.Add(a);
                bool ThisDone = false;
                AutoResetCounter RetryCount = new AutoResetCounter(20);
                RetryCount.MaxmizeTemp();
                while (!ThisDone && !RetryCount.IsZeroReached(1))
                {
                    foreach (RaycastHit hitt in Physics.RaycastAll(RandomPointInBound(), SpawnDirection, 150))
                    {
                        if (hitt.collider.gameObject == this.gameObject || hitt.collider.transform.IsChildOf(this.transform))
                        {
                            ThisDone = true;
                            Quaternion rot = Random.rotation;
                            while (rot.eulerAngles == hitt.normal) // Prevent Wrong Cross
                            {
                                rot = Random.rotation;
                            }
                            Quaternion rotrot = Quaternion.LookRotation(Vector3.Cross(hitt.normal,
                                    Vector3.Cross(newFoouuud.transform.forward,
                                        hitt.normal)),
                                hitt.normal);
                            newFoouuud.transform.rotation = rotrot;
                            newFoouuud.transform.position = hitt.point;

                            foreach (SpawnableItem spawnedItem in spawned)
                            {
                                if (spawnedItem.IsOverlappingWith(a) || a.IsOverlappingWith(spawnedItem)) ThisDone = false;
                            }
                            
                            break;
                        }
                    }
                }
                
            }
            DestroyImmediate(this);
        }

        Vector3 RandomPointInBound()
        {
            Vector3 random = new Vector3(
                RayStartPosition.extents.x * Random.Range(-1f, 1f),
                RayStartPosition.extents.y * Random.Range(-1f, 1f),
                RayStartPosition.extents.z * Random.Range(-1f, 1f)
            );
            Vector3 vec = RayStartPosition.center + random;
            return RayStartPosition.Contains(vec) ? vec : RandomPointInBound();
        }
    }
}