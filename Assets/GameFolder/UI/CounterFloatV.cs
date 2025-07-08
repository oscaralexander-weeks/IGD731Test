using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterFloatV : MonoBehaviour
{
    [SerializeField] private FloatVariable Variable;
    [SerializeField] private TextMeshProUGUI TextComponent;
    [SerializeField] private string Text;

    private void Update()
    {
        if(TextComponent != null && Variable != null)
        {
            TextComponent.text = Text + Variable.Value.ToString();
        }
    }
}
