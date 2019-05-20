using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponControler : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    IWeapon equippedWeapon;
    CharacterStats characterStats;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        
    }

    public void EquipWeapon(Item ItemToEquip)
    {
        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + ItemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = ItemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStats.AddStatBonus(ItemToEquip.Stats);

        Debug.Log(characterStats.stats[0].StatName + ": " + characterStats.stats[0].GetCalculatedStatValue() + " | " + characterStats.stats[1].StatName + ": " + characterStats.stats[1].GetCalculatedStatValue());

    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack();
    }
}
