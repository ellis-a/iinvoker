using FishNet.Object;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    private float _gcd;
    private float _movementSpeed;
    private float _maxHealth;
    private float _currentHealth;

    private CharacterController _characterController;

    [Header("Components")]
    public Camera PlayerCamera;
    public GameObject PlayerCharacter;
    public GameObject Rotator;

    [Header("Attributes")]
    public int Power = 10;
    public int Alacrity = 10;
    public int Focus = 10;
    public int Will = 10;

    [Header("Equipment")]
    public Wand Wand;
    public SpellBook SpellBook;

    private Plane GroundPlane = new Plane(Vector3.up, 0);

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _movementSpeed = 5f;
        _maxHealth = 100f;
        
        _currentHealth = _maxHealth;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotationInput();
        HandleSpellCasts();
    }

    [Client(RequireOwnership = true)]
    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 offset = Rotator.transform.rotation * new Vector3(horizontal, Physics.gravity.y, vertical) * (_movementSpeed * Time.deltaTime);

        _characterController.Move(offset);

        //transform.Translate(_movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f,
        //    _movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime, Space.World);
    }

    [Client(RequireOwnership = true)]
    private void HandleRotationInput()
    {
        if (Input.GetButton("CameraRotation"))
        {
            return;
        }

        var ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (GroundPlane.Raycast(ray, out distance))
        {
            var hit = ray.GetPoint(distance);
            PlayerCharacter.transform.LookAt(new Vector3(hit.x, PlayerCharacter.transform.position.y, hit.z));
        }
    }

    public void HandleSpellCasts()
    {
        //foreach (var spell in SpellBook.GetSpells())
        //{
        //    if (spell == null)
        //    {
        //        continue;
        //    }

        //    var gcdComplete = Time.time > _gcd;
        //    if (gcdComplete && (Input.GetButtonDown(spell.Hotkey)
        //        || Input.GetButton(spell.Hotkey) && (spell.Hotkey == "Attack" || spell.Hotkey == "AltAttack")))
        //    {
        //        if (!SpellBook.IsManaAvailable(spell)) //manacost
        //        {
        //            continue;
        //        }

        //        _gcd = Time.time + 0.5f;
        //        SpellBook.SpendMana(spell);
        //        spell.SetAttributes(Power, Alacrity, Focus, Will);
        //        spell.CastSpell();
        //    }
        //}
    }
}
