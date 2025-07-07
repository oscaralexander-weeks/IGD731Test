using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageClearBreakdown : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI StyleScoreTextComponent, StatsTextComponent;
    [SerializeField] private StageStats stageStats;
    private float _style;
    public void CheckStageStats()
    {
        StatsTextComponent.text = ($"Hits: {stageStats.Hits.Value} \n Misses: {stageStats.Misses.Value} \n Entertainment: {stageStats.Entertainment.Value}");
        CheckStyle(stageStats.Style);
    }


    private void CheckStyle(FloatVariable style)
    {
        float v = style.Value;
        StyleScoreTextComponent.text = v switch
        {
            < 15 => "Style: F",
            < 30 => "Style: E",
            < 45 => "Style: D",
            < 60 => "Style: C",
            < 75 => "Style: B",
            < 90 => "Style: A",
            < 150 => "Style: S",
            _ => StyleScoreTextComponent.text // fallback
        };
    }
}
