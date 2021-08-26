using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour
{
    const int _maxRunes = 6;
    private List<Spell> _spells;
    private float _gcd;

    [SerializeField]
    public PlayerController Character;

    public Spell LClickSpell;
    public Spell RClickSpell;
    public Spell QSpell;
    public Spell ESpell;
    public Spell RSpell;
    public Spell FSpell;
    public Spell SpaceSpell;

    public RuneColour[] RuneColours = new RuneColour[6];
    public ManaRune[] Runes = new ManaRune[6];
    public GameObject CastPoint;

    void OnValidate()
    {
        if (Runes.Length != _maxRunes)
        {
            Debug.LogWarning("Don't change the 'runes' field's array size!");
            Array.Resize(ref Runes, _maxRunes);
        }
        if (RuneColours.Length != _maxRunes)
        {
            Debug.LogWarning("Don't change the 'rune colours' field's array size!");
            Array.Resize(ref RuneColours, _maxRunes);
        }
    }

    void Start()
    {
        SetUpSpells();
        SetUpRunes();
    }

    public List<Spell> GetSpells()
    {
        return _spells;
    }

    public void SpendMana(Spell spellBeingCast)
    {
        var w = spellBeingCast.WhiteManaCost;
        var u = spellBeingCast.BlueManaCost;
        var b = spellBeingCast.BlackManaCost;
        var r = spellBeingCast.RedManaCost;
        var g = spellBeingCast.GreenManaCost;
        var c = spellBeingCast.GenericManaCost;

        var manaToSpend = new List<ManaRune>();

        foreach (var rune in Runes)
        {
            if (!rune.Available)
            {
                continue;
            }

            if (rune.Colour == RuneColour.White && w > 0) //improve this
            {
                w--;
                manaToSpend.Add(rune);
            }
            else if (rune.Colour == RuneColour.Blue && u > 0)
            {
                u--;
                manaToSpend.Add(rune);
            }
            else if (rune.Colour == RuneColour.Black && b > 0)
            {
                b--;
                manaToSpend.Add(rune);
            }
            else if (rune.Colour == RuneColour.Red && r > 0)
            {
                r--;
                manaToSpend.Add(rune);
            }
            else if (rune.Colour == RuneColour.Green && g > 0)
            {
                g--;
                manaToSpend.Add(rune);
            }
        }

        var allManaSpent = w == 0 && u == 0 && b == 0 && r == 0 && g == 0;
        if (allManaSpent)
        {
            foreach (var rune in manaToSpend)
            {
                rune.ConsumeMana();
            }
        }
    }

    public bool IsManaAvailable(Spell spellBeingCast)
    {
        var mana = Runes.ToList();
        var w = mana.Count(m => m.Colour == RuneColour.White && m.Available);
        var u = mana.Count(m => m.Colour == RuneColour.Blue && m.Available);
        var b = mana.Count(m => m.Colour == RuneColour.Black && m.Available);
        var r = mana.Count(m => m.Colour == RuneColour.Red && m.Available);
        var g = mana.Count(m => m.Colour == RuneColour.Green && m.Available);

        if (spellBeingCast.WhiteManaCost > w ||
            spellBeingCast.BlueManaCost > u ||
            spellBeingCast.BlackManaCost > b ||
            spellBeingCast.RedManaCost > r ||
            spellBeingCast.GreenManaCost > g)
        {
            return false;
        }

        return true;
    } 

    private void SetUpRunes()
    {
        for (int i = 0; i < _maxRunes; i++)
        {
            Runes[i].Initialize(RuneColours[i]);
        }
    }

    private void SetUpSpells()
    {
        if (LClickSpell != null)
        {
            LClickSpell.Hotkey = "Attack";
        }
        if (RClickSpell != null)
        {
            RClickSpell.Hotkey = "AltAttack";
        }
        if (QSpell != null)
        {
            QSpell.Hotkey = "QSpell";
        }
        if (ESpell != null)
        {
            ESpell.Hotkey = "ESpell";
        }
        if (RSpell != null)
        {
            RSpell.Hotkey = "RSpell";
        }
        if (FSpell != null)
        {
            FSpell.Hotkey = "FSpell";
        }
        if (SpaceSpell != null)
        {
            SpaceSpell.Hotkey = "SpaceSpell";
        }
        _spells = new List<Spell>() { LClickSpell, RClickSpell, QSpell, ESpell, RSpell, FSpell, SpaceSpell };

        foreach (var spell in _spells)
        {
            if (spell == null) { continue; }
            spell.CastPoint = CastPoint.transform;
        }
    }
}