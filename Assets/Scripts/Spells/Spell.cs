using System.Linq;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    private int _whiteManaCost = -1;
    private int _blueManaCost = -1;
    private int _blackManaCost = -1;
    private int _redManaCost = -1;
    private int _greenManaCost = -1;
    private int _colourlessManaCost = -1;
    private int _genericManaCost = -1;

    protected void OnValidate()
    {
        _whiteManaCost = -1;
        _blueManaCost = -1;
        _blackManaCost = -1;
        _redManaCost = -1;
        _greenManaCost = -1;
        _colourlessManaCost = -1;
        _genericManaCost = -1;
    }

    [SerializeField]
    public string AbilityName;
    [SerializeField]
    public AudioClip Sound;
    [SerializeField]
    public Sprite Sprite;
    [SerializeField]
    public float Damage; //temp property

    [SerializeField]
    public string ManaCost;

    public int WhiteManaCost 
    {
        get
        {
            if (_whiteManaCost == -1)
            {
                _whiteManaCost = ManaCost.Count(m => char.ToLower(m) == 'w');
            }
            return _whiteManaCost;
        }
    }
    public int BlueManaCost
    {
        get
        {
            if (_blueManaCost == -1)
            {
                _blueManaCost = ManaCost.Count(m => char.ToLower(m) == 'u');
            }
            return _blueManaCost;
        }
    }
    public int BlackManaCost
    {
        get
        {
            if (_blackManaCost == -1)
            {
                _blackManaCost = ManaCost.Count(m => char.ToLower(m) == 'b');
            }
            return _blackManaCost;
        }
    }
    public int RedManaCost
    {
        get
        {
            if (_redManaCost == -1)
            {
                _redManaCost = ManaCost.Count(m => char.ToLower(m) == 'r');
            }
            return _redManaCost;
        }
    }
    public int GreenManaCost
    {
        get
        {
            if (_greenManaCost == -1)
            {
                _greenManaCost = ManaCost.Count(m => char.ToLower(m) == 'g');
            }
            return _greenManaCost;
        }
    }
    public int ColourlessManaCost
    {
        get
        {
            if (_colourlessManaCost == -1)
            {
                _colourlessManaCost = ManaCost.Count(m => char.ToLower(m) == 'c');
            }
            return _colourlessManaCost;
        }
    }
    public int GenericManaCost 
    { 
        get 
        {
            if (_genericManaCost == -1)
            {
                var str = new string(ManaCost.Where(char.IsDigit).ToArray());
                if (string.IsNullOrWhiteSpace(str))
                {
                    return 0;
                }
                _genericManaCost = int.Parse(str);
            }
            return _genericManaCost;
        }
    }

    [HideInInspector]
    public string Hotkey;
    [HideInInspector]
    public Transform CastPoint;

    public static Spell Instance;
    
    public abstract void Initialize(GameObject obj);
    public abstract void CastSpell();

    protected int _power;
    protected int _alacrity;
    protected int _focus;
    protected int _will;

    public void SetAttributes(int power, int alacrity, int focus, int will)
    {
        _power = power;
        _alacrity = alacrity;
        _focus = focus;
        _will = will;
    }

    public string GetSpellColours()
    {
        var colours = string.Empty;

        if (WhiteManaCost > 0) { colours += "White "; }
        if (BlueManaCost > 0) { colours += "Blue "; }
        if (BlackManaCost > 0) { colours += "Black "; }
        if (RedManaCost > 0) { colours += "Red "; }
        if (GreenManaCost > 0) { colours += "Green"; }

        if (string.IsNullOrWhiteSpace(colours)) { colours += "Colourless"; }

        return colours.Trim();
    }
}
