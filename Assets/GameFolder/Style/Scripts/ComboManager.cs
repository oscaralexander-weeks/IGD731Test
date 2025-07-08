using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public FloatVariable Combo;

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
    }

}
