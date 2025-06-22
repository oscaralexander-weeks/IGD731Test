using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IconPanelUIAbility : MonoBehaviour
{
    public AbilityBaseClass Ability;
    public BaseDefaultWeapon Weapon;

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
        //null check 
        if(Weapon != null)
        {
            itemName.text = Weapon.WeaponName;

            if (Weapon.Cooldown == Weapon.CooldownTimer)
            {
                cooldown.text = "Ready";
            }
            else
            {
                cooldown.text = Weapon.CooldownTimer.ToString("F0");
            }
            
        }

        if(Ability != null)
        {
            itemName.text = Ability.AbilityName;

            if(Ability.AbilityCooldown == Ability.AbilityCooldownTimer)
            {
                cooldown.text = "Ready";
            }
            else
            {
                cooldown.text = Ability.AbilityCooldownTimer.ToString("F0");
            }
        }
    }
}
