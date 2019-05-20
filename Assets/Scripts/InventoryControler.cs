using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControler : MonoBehaviour
{
    public Item sword, axe, dagger;
    public PlayerWeaponControler playerWeaponControler;

    void Start()
    {
        playerWeaponControler = GetComponent<PlayerWeaponControler>();
        List<BaseStat> swordStats = new List<BaseStat>();
        List<BaseStat> axeStats = new List<BaseStat>();
        List<BaseStat> daggerStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Power", "Your power level."));
        axeStats.Add(new BaseStat(14, "Power", "Your power level."));
        daggerStats.Add(new BaseStat(4, "Power", "Your power level."));
        sword = new Item(swordStats, "sword");
        axe = new Item(axeStats, "axe");
        dagger = new Item(daggerStats, "dagger");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponControler.EquipWeapon(sword);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            playerWeaponControler.EquipWeapon(axe);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            playerWeaponControler.EquipWeapon(dagger);
        }
    }
}
