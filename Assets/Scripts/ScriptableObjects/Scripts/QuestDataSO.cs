using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [구현사항 1]
// 퀘스트의 정보를 저장하는 스크립터블 오브젝트 QuestDataSO를 정의
[CreateAssetMenu(fileName = "QuestData", menuName = "Quest/QuestDataSO")]
public class QuestDataSO : ScriptableObject
{
    public string QuestName;                // 퀘스트 이름
    public int QuestRequiredLevel;          // 퀘스트의 최소레벨
    public int QuestNPC;                    // 퀘스트를 주는 NPC의 id
    public List<int> QuestPrerequisites;    // 선행 퀘스트의 id들의 리스트
}
