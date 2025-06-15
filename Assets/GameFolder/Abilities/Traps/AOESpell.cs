using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESpell : MonoBehaviour
{
    private Enemy enemy;
    public float castTime;
    public int spellDamage;

    public float castRadius;

    Renderer spellRenderer;

    private void Start()
    {
        spellRenderer = GetComponent<Renderer>();
    }

}
