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
        if(Ability != null && !Ability.HasAbilityCount)
        {
            count.transform.parent.gameObject.SetActive(false);  
        }
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

            if(Ability.Cooldown == Ability.CooldownTimer && Ability.AbilityCount > 0)
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
