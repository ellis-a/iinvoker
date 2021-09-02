﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string WeaponName = "Default";
    public Spell[] WeaponAbilities;
    public GameObject Prefab;
}