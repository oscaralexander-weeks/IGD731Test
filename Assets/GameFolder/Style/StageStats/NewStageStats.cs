using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NewStageStats : ScriptableObject
{
    public FloatVariable Hits, Misses, TrapKills, EnvironmentKills, StealthKills, Style, HighestCombo;
}
