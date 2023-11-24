using System.Linq;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    [SerializeField]
    private Hero _ownerWizard;

    [HideInInspector]
    public string Hotkey;

    public string SpellName;
    public string SpellDescription;
    //public string SpellType;
    public int ManaCost;


    public void CastSpell()
    {
        var notEnoughMana = false;
        if (notEnoughMana)
        {
            return;
        }
    }
}
