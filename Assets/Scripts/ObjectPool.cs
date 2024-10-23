using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

    void Start()
    {
        // �̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
        CreatePool(poolSize);
    }
    void CreatePool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject go = Instantiate(prefab);    // ���������� �ν��Ͻ� ����
            go.SetActive(false);    // Ǯ�� �ֱ� �� ��Ȱ��ȭ
            pool.Add(go);   // Ǯ�� �߰�
        }
    }

    public GameObject Get()
    {
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
        foreach (GameObject go in pool)
        {
            if (!go.activeSelf)
            {
                go.SetActive(true);
                return go;
            }
        }
        int currentPoolSize = pool.Count;   // ��������� Ǯ ������ ����
        CreatePool(poolSize);   // Ǯ Ȯ��

        // Ȯ��� Ǯ�� ��Ȱ�� ������Ʈ �� ù��° ������ Ȱ��ȭ �� ����
        GameObject obj = pool[currentPoolSize];
        obj.SetActive(true);
        return obj;
    }

    public void Release(GameObject obj)
    {
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        obj.SetActive(false);
    }
}