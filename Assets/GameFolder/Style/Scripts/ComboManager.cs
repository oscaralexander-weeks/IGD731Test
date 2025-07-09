using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public FloatVariable Combo;
    public FloatVariable HighestCombo;

    public float ComboTimer = 0f;
    public float ComboCooldown = 3f;

    private void Update()
    {
        ComboTimer += Time.deltaTime;

        if(ComboTimer > ComboCooldown)
        {
            Combo.Value = 0;
            ComboTimer = 0;
        }
    }

    public void AddToComboStreak()
    {
        Combo.Value += 1;
        ComboTimer = 0;
        UpdateHighestCombo();
    }

    public void EndComboStreak()
    {
        Combo.Value = 0;
        ComboTimer = 0;
    }

    public void UpdateHighestCombo()
    {
        if(Combo.Value > HighestCombo.Value)
        {
            HighestCombo.Value = Combo.Value;
        }
    }
}
