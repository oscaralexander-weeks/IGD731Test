using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IconPanelUIAbility : MonoBehaviour
{
    public AbilitiesSuperclass Ability;
    //public BaseDefaultWeapon Weapon;

    public TextMeshProUGUI cooldown;
    public TextMeshProUGUI itemName;

    private void Start()
    {
        
    }

    private void Update()
    {
        DisplayIcon();
    }

    public void DisplayIcon()
    {
        if(Ability != null)
        {
            itemName.text = Ability.Name;

            if(Ability.Cooldown == Ability.CooldownTimer)
            {
                cooldown.text = "Ready";
            }
            else
            {
                cooldown.text = Ability.CooldownTimer.ToString("F0");
            }
        }
    }
}
