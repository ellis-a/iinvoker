using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public Camera MenuCamera;
    public GameObject Player;
    public Vector3 PlayerSpawnPosition = new Vector3(0, 0, 0);
    public Weapon[] weapons;

    public GameObject WeaponSelectPanel;
    public GameObject AbilityPanel;

    public void OnWeaponSelect(int weaponChoice)
    {
        MenuCamera.enabled = false;
        WeaponSelectPanel.SetActive(false);
        AbilityPanel.SetActive(true);

        var spawnedPlayer = Instantiate(Player, PlayerSpawnPosition, Quaternion.identity) as GameObject;
        var weaponHolder = spawnedPlayer.GetComponentInChildren<WeaponHolderMarker>().gameObject;
        var selectedWeapon = weapons[weaponChoice];

        Instantiate(selectedWeapon.Prefab, weaponHolder.transform);
    }
}
