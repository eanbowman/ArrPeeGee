﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public Item sword;
    public PlayerWeaponController playerWeaponController;

    private void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Power", "Your power level."));
        sword = new Item(swordStats, "Staff");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        }
    }
}
