using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _gcd;
    private float _movementSpeed;
    private float _maxHealth;
    private float _currentHealth;

    [Header("Attributes")]
    [SerializeField]
    public int Power = 10;
    [SerializeField]
    public int Alacrity = 10;
    [SerializeField]
    public int Focus = 10;
    [SerializeField]
    public int Will = 10;

    [Header("Equipment")]
    public Wand Wand;
    public SpellBook SpellBook;

    private Plane GroundPlane = new Plane(Vector3.up, 0);

    void Start()
    {
        _movementSpeed = 5f;
        _maxHealth = 100f;

        switch (Wand.Wood)
        {
            case Wand.WandWood.Birch:
                _movementSpeed += 1f;
                _maxHealth -= 20;
                break;
            case Wand.WandWood.Maple:
                _movementSpeed += 0.5f;
                _maxHealth -= 10;
                break;
            case Wand.WandWood.RedOak:
                break;
            case Wand.WandWood.Cedar:
                _movementSpeed -= 0.5f;
                _maxHealth += 10;
                break;
            case Wand.WandWood.Walnut:
                _movementSpeed -= 1f;
                _maxHealth += 20;
                break;
            default:
                break;
        }
        
        _currentHealth = _maxHealth;
    }

    void Update()
    {
        HandleMovement();
        HandleRotationInput();
        HandleSpellCasts();
    }

    void HandleMovement()
    {
        transform.Translate(_movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f,
            _movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime, Space.World);
    }

    void HandleRotationInput()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (GroundPlane.Raycast(ray, out distance))
        {
            var hit = ray.GetPoint(distance);
            transform.LookAt(new Vector3(hit.x, transform.position.y, hit.z));
        }
    }

    public void HandleSpellCasts()
    {
        foreach (var spell in SpellBook.GetSpells())
        {
            if (spell == null)
            {
                continue;
            }

            var gcdComplete = Time.time > _gcd;
            if (gcdComplete && (Input.GetButtonDown(spell.Hotkey)
                || Input.GetButton(spell.Hotkey) && (spell.Hotkey == "Attack" || spell.Hotkey == "AltAttack")))
            {
                if (!SpellBook.IsManaAvailable(spell)) //manacost
                {
                    continue;
                }

                _gcd = Time.time + 0.5f;
                SpellBook.SpendMana(spell);
                spell.SetAttributes(Power, Alacrity, Focus, Will);
                spell.CastSpell();
            }
        }
    }
}
