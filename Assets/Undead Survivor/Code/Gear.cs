using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    private ItemData.ItemType type;
    private float rate;

    private float baseRotationSpeed = 150f;
    private float baseBulletSpeed = 75f;

    private Player player;

    public void Init(ItemData data)
    {
        // Basic Set
        name = "Gear " + data.itemType;
        player = GameManager.instance.player;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;

        // Property Set
        type = data.itemType;
        rate = data.damages[0];
        // fix later
        //baseRotationSpeed = data.baseRotationSpeed;
        //baseBulletSpeed = data.baseBulletSpeed;

        player.OnApplyGear += ApplyGear;

        ApplyGear();
    }

    private void OnDestroy()
    {
        if(player != null)
        {
            player.OnApplyGear -= ApplyGear;
        }
    }

    public void LevelUp(float rate)
    {
        this.rate = rate;
        ApplyGear();
    }

    void ApplyGear()
    {
        switch (type)
        {
            case ItemData.ItemType.Glove:
                RateUp();
                break;
            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;
        }
    }

    void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach(Weapon weapon in weapons)
        {
            switch (weapon.itemType)
            {
                case ItemData.ItemType.Melee:
                    weapon.speed = baseRotationSpeed * (1 + rate) * Character.rotationSpeed;
                    break;
                case ItemData.ItemType.Range:                    
                    weapon.speed = baseBulletSpeed * (1f-rate) * Character.fireCooldown;
                    break;
            }
        }
    }

    void SpeedUp()
    {
        player = GameManager.instance.player;
        player.speed = player.speed * (1 + rate) * Character.Speed;
    }
}
