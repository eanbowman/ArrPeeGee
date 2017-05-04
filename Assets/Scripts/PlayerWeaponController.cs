using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    CharacterStats characterStats;

    Transform spawnProjectile;
    IWeapon equippedWeapon;

    private void Start()
    {
        spawnProjectile = transform.FindChild("ProjectileSpawn");
        characterStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            PerformWeaponAttack();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PerformSpecialWeaponAttack();
        }
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if(EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),
            playerHand.transform.position,
            playerHand.transform.rotation
        );
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        if(EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        equippedWeapon.Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStats.AddStatBonus(itemToEquip.Stats);
        Debug.Log("Equipped weapon first stat " + equippedWeapon.Stats[0].GetCalculatedStatValue());
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack();
    }

    public void PerformSpecialWeaponAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }
}
