using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManaRune : MonoBehaviour
{
    [SerializeField]
    private Image _runeImage;
    [SerializeField]
    private Image _darkMask;
    [SerializeField]
    private TMP_Text _coolDownText;
    private float _cooldownDuration;
    private float _nextReadyTime;
    private float _coolDownTimeLeft;

    [System.NonSerialized]
    public bool Available;
    [System.NonSerialized]
    public RuneColour Colour;

    void Start()
    {
        _darkMask.fillAmount = 0f;
    }

    public void Initialize(RuneColour runeColour)
    {
        _cooldownDuration = 4f;
        SetCooldownMask();
        SetColour(runeColour);
    }

    void Update()
    {
        Available = Time.time > _nextReadyTime;
        SetCooldownMask();
        if (!Available)
        {
            CoolDown();
        }
    }

    public void ConsumeMana()
    {
        _nextReadyTime = Time.time + _cooldownDuration;
        Available = false;
    }

    private void SetColour(RuneColour colour)
    {
        Colour = colour;
        switch (colour)
        {
            case RuneColour.White:
                _runeImage.overrideSprite = Resources.Load<Sprite>("ManaRuneSprites/White");
                break;
            case RuneColour.Blue:
                _runeImage.overrideSprite = Resources.Load<Sprite>("ManaRuneSprites/Blue");
                break;
            case RuneColour.Black:
                _runeImage.overrideSprite = Resources.Load<Sprite>("ManaRuneSprites/Black");
                break;
            case RuneColour.Red:
                _runeImage.overrideSprite = Resources.Load<Sprite>("ManaRuneSprites/Red");
                break;
            case RuneColour.Green:
                _runeImage.overrideSprite = Resources.Load<Sprite>("ManaRuneSprites/Green");
                break;
            case RuneColour.Colourless:
                _cooldownDuration = 2f;
                _runeImage.overrideSprite = Resources.Load<Sprite>("ManaRuneSprites/Colourless");
                break;
            case RuneColour.Prismatic:
                _cooldownDuration = 8f;
                _runeImage.overrideSprite = Resources.Load<Sprite>("ManaRuneSprites/Prismatic");
                break;
            default:
                break;
        }
    }

    private void SetCooldownMask()
    {
        _coolDownText.enabled = !Available;
        _darkMask.enabled = !Available;
    }

    private void CoolDown()
    {
        _coolDownTimeLeft = _nextReadyTime - Time.time;
        var roundedCd = Mathf.Round(_coolDownTimeLeft);
        _coolDownText.SetText(roundedCd.ToString());
        _darkMask.fillAmount = (_coolDownTimeLeft / _cooldownDuration);
    }
}