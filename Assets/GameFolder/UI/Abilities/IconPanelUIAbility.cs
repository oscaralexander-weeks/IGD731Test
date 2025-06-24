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
    public TextMeshProUGUI count;

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

            if (Ability.HasAbilityCount)
            {
                count.text = Ability.AbilityCount.ToString();
            }

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

    public void SwitchAbility(AbilitiesSuperclass ability)
    {
        Ability = ability;
        DisplayIcon();
    }
}
