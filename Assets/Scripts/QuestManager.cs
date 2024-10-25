using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager instance;
    public List<QuestDataSO> Quests;

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
            instance = FindObjectOfType<QuestManager>();
            // instance가 null이면
            // (현재 씬에 QuestManager가 없으면)
            if (instance == null)
            {
                // 새로운 게임오브젝트 생성
                GameObject go = new GameObject("QuestManager");
                instance = go.AddComponent<QuestManager>();
            }
            return instance;
        }
    }

    // [구현사항 3] 인스턴스 검사 로직
    private void Awake()
    {
        // 인스턴스가 null이 아니고
        // (이미)존재하는 인스턴스가 현재 생성된 인스턴스가 아닌 경우
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // 생성된 인스턴스 파괴
            return;
        }
        // 인스턴스가 null이면 현재 생성된 것으로 유지
        instance = this;
    }

    private void Start()
    {
        QuestSetting();
    }

    void QuestSetting()
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            QuestDataSO quest = Quests[i];
            StringBuilder sb = new StringBuilder();
            sb.Append($"Quest {i + 1} - {quest.QuestName} (최소 레벨 {quest.QuestRequiredLevel})");
            
            // 퀘스트 타입마다 다른 출력
            switch (quest)
            {
                case MonsterQuestDataSO monsterQuest: 
                    sb.Append($"\n {monsterQuest.MonsterKillCount} 마리 소탕");
                    break;
                case EncounterQuestDataSO encounterQuest:
                   sb.Append($"\n {encounterQuest.NPCName} 님과 대화하기");
                   break;
                default:
                    Debug.Log("Undefined Quest Error");
                    break;
            }
            Debug.Log(sb);
        }
    }
}