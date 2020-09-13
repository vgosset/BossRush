using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Boss/Weapon/Action")]

public class BossWeaponAction : ScriptableObject 
{
    public int id;
    public int damage;
    public float duration;
    public string animTrigger;
}