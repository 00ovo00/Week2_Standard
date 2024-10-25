using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [구현사항 2]
// QuestDataSO를 상속받는 MonsterQuestDataSO와 EncounterQuestDataSO를 정의
[CreateAssetMenu(fileName = "MonsterQuestData", menuName = "Quest/MonsterQuestDataSO")]
public class MonsterQuestDataSO : QuestDataSO
{
    public int MonsterKillCount;    // 죽여야 하는 몬스터 수
}