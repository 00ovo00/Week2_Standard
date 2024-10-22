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
            instance = FindObjectOfType(typeof(QuestManager)) as QuestManager;
            if (instance == null)
            {
                // instance�� null�̸� ���ο� ���ӿ�����Ʈ ����
                instance = new QuestManager();
            }
            return instance;
        }
    }

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        // �ν��Ͻ��� null�� �ƴϸ�
        if (instance != null)
        {
            Destroy(instance);  // ������ �ν��Ͻ� �ı�
            return;
        }
        // �ν��Ͻ��� null�̸� ���� ������ ������ ����
        instance = this;
    }
}