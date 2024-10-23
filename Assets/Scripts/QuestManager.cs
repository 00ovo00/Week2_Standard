using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
    public static QuestManager Instance
    {
        get
        {
            // instance�� null���� Ȯ��
            if (instance != null)
            {
                // instance �����ϸ� �ٷ� ����
                return instance;
            }
            // QuestManager Ÿ�� ���� ������Ʈ ã�� ����
            instance = FindObjectOfType<QuestManager>();
            // instance�� null�̸�
            // (���� ���� QuestManager�� ������)
            if (instance == null)
            {
                // ���ο� ���ӿ�����Ʈ ����
                GameObject go = new GameObject("QuestManager");
                instance = go.AddComponent<QuestManager>();
            }
            return instance;
        }
    }

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        // �ν��Ͻ��� null�� �ƴϰ�
        // (�̹�)�����ϴ� �ν��Ͻ��� ���� ������ �ν��Ͻ��� �ƴ� ���
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // ������ �ν��Ͻ� �ı�
            return;
        }
        // �ν��Ͻ��� null�̸� ���� ������ ������ ����
        instance = this;
    }
}