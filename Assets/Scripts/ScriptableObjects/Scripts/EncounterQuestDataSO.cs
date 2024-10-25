using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [구현사항 2]
// QuestDataSO를 상속받는 MonsterQuestDataSO와 EncounterQuestDataSO를 정의
[CreateAssetMenu(fileName = "EncounterQuestData", menuName = "Quest/EncounterQuestDataSO")]
public class EncounterQuestDataSO : QuestDataSO
{
    public string NPCName;  // 만나야 하는 NPC 이름
}