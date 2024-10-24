using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTest : MonoBehaviour
{
    public ObjectPool circlePool;
    public ObjectPool squarePool;
    public Transform circleSpawnPoint;
    public Transform squareSpawnPoint;
    public float spawnDelay = 5.0f;


    void Update()
    {
        // 스페이스바 누르고 있으면 풀에서 인스턴스 Get
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject circle = circlePool.Get();
            GameObject square = squarePool.Get();

            circle.transform.position = circleSpawnPoint.position;
            square.transform.position = squareSpawnPoint.position;

            // 5초 뒤에 Release
            StartCoroutine(ReleaseAfterTime(circlePool, circle, spawnDelay));
            StartCoroutine(ReleaseAfterTime(squarePool, square, spawnDelay));
        }
        
    }
    private IEnumerator ReleaseAfterTime(ObjectPool pool, GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        pool.Release(go);
    }
}
