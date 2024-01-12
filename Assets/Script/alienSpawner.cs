using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class alienSpawner : MonoBehaviour
{
    public int AlienCount = 10;
    public GameObject AlienObject;
    public Transform playerTransform;
    public float xMin = -30f;
    public float xMax = 40f;
    public float zMin = -50f;
    public float zMax = 130f;

    void Start()
    {
        for (int i = 0; i < AlienCount; i++)
        {
            var pos = GetPositionForAlien();
            var alien = Instantiate(AlienObject, pos, Quaternion.identity);
            alien.transform.LookAt(Vector3.zero);
        }
    }
    Vector3 GetPositionForAlien()
    {
        NavMeshHit hit;
        while (true)
        {
            var pos = new Vector3(Random.Range(xMin, xMax), 1, Random.Range(zMin, zMax));
            var colliders = Physics.OverlapBox(pos, new Vector3(1,0.5F,1));
            if (colliders.Length == 0) return pos;

            if (NavMesh.SamplePosition(pos,out hit, 1.0f, NavMesh.AllAreas))
            {
                float distanceToPlayer = Vector3.Distance(pos, playerTransform.position);

                if (distanceToPlayer > 10.0f)
                {
                    return hit.position;
                }
            }
        }
    }
}
