using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageClearBreakdown : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI StyleScoreTextComponent, StatsTextComponent;
    [SerializeField] private StageStats stageStats;

    public void CheckStageStats()
    {
        StatsTextComponent.text = ($"Hits: {stageStats.Hits.Value} \n Misses: {stageStats.Misses.Value} \n Entertainment: {stageStats.Entertainment.Value}");
    }

}
