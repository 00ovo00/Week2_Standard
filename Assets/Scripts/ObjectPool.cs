using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

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
        int currentPoolSize = pool.Count;   // 현재까지의 풀 사이즈 저장
        CreatePool(poolSize);   // 풀 확장
        // 확장된 풀의 비활성 오브젝트 중 첫번째 가져와 활성화 후 리턴
        GameObject obj = pool[currentPoolSize];
        obj.SetActive(true);
        return obj;
    }

    public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.SetActive(false);
    }
}