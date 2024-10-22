using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager instance;

    // [구현사항 2] 정적 프로퍼티 정의
    public static QuestManager Instance
    {
        get
        {
            // instance가 null인지 확인
            if (instance != null)
            {
                // instance 존재하면 바로 리턴
                return instance;
            }
            // QuestManager 타입 가진 컴포넌트 찾아 대입
            instance = FindObjectOfType(typeof(QuestManager)) as QuestManager;
            if (instance == null)
            {
                // instance가 null이면 새로운 게임오브젝트 생성
                instance = new QuestManager();
            }
            return instance;
        }
    }

    // [구현사항 3] 인스턴스 검사 로직
    private void Awake()
    {
        // 인스턴스가 null이 아니면
        if (instance != null)
        {
            Destroy(instance);  // 생성된 인스턴스 파괴
            return;
        }
        // 인스턴스가 null이면 현재 생성된 것으로 유지
        instance = this;
    }
}