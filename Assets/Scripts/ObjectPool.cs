using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;
    public int maxPoolSize = 1000;  // 풀 최대 확장 크기
    
    void Start()
    {
        // 미리 poolSize만큼 게임오브젝트를 생성한다.
        CreatePool(poolSize);
    }
    void CreatePool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject go = Instantiate(prefab);    // 프리팹으로 인스턴스 생성
            go.transform.SetParent(transform);
            go.SetActive(false);    // 풀에 넣기 전 비활성화
            pool.Add(go);   // 풀에 추가
        }
    }

    public GameObject Get()
    {
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        foreach (GameObject go in pool)
        {
            if (!go.activeSelf)
            {
                go.SetActive(true);
                return go;
            }
        }

        int currentPoolSize = pool.Count;
        Debug.Log(currentPoolSize);
        
        // 최대 풀 크기에 도달하면 확장 x, null 반환
        if (currentPoolSize >= maxPoolSize)
        {
            Debug.Log($"[{this.GetType().Name}] : {MethodBase.GetCurrentMethod().Name}");
            Debug.Log("Exceeded max pool size");
            return null;
        }

        // 풀 확장 가능하면 기본 지정 풀 사이즈만큼 확장
        int newPoolSize = Mathf.Min(poolSize, maxPoolSize - currentPoolSize);
        CreatePool(newPoolSize);
        
        return Get();
    }

    public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.SetActive(false);
    }
}