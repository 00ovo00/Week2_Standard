using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPoolTest : MonoBehaviour
{
    public ObjectPool trianglePool;
    public ObjectPool squarePool;
    public ObjectPool circlePool;
    public Transform triangleSpawnPoint;
    public Transform squareSpawnPoint;
    public Transform circleSpawnPoint;
    public float spawnDelay;

    void Update()
    {
        // 스페이스바 누르고 있으면 풀에서 인스턴스 Get
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject triangle = trianglePool.Get();
            GameObject square = squarePool.Get();
            GameObject circle = circlePool.Get();
            
            triangle.transform.position = triangleSpawnPoint.position;
            square.transform.position = squareSpawnPoint.position;
            circle.transform.position = circleSpawnPoint.position;
            
            // 일정 시간 뒤에 Release
            StartCoroutine(ReleaseAfterTime(trianglePool, triangle, spawnDelay));
            StartCoroutine(ReleaseAfterTime(squarePool, square, spawnDelay));
            StartCoroutine(ReleaseAfterTime(circlePool, circle, spawnDelay));
        }
        
    }
    private IEnumerator ReleaseAfterTime(ObjectPool pool, GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        pool.Release(go);
    }
}
