using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageStats : ScriptableObject
{
    [SerializeField] private FloatVariable Hits, Misses, Entertainment, Style;
}
