using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum characterType
{
    Boy, Girl, Man, Woman
}

public class Character : MonoBehaviour
{
    public static float Speed
    {
        get { return GameManager.instance.characterId == characterType.Boy ? 1.1f : 1f; }
    }

    public static float rotationSpeed
    {
        get { return GameManager.instance.characterId == characterType.Girl ? 1.1f : 1f; }
    }

    public static float fireCooldown
    {
        get { return GameManager.instance.characterId == characterType.Girl ? .9f : 1f; }
    }

    public static float Damage
    {
        get { return GameManager.instance.characterId == characterType.Man ? 1.2f : 1f; }
    }

    public static int Amount
    {
        get { return GameManager.instance.characterId == characterType.Woman ? 1 : 0; }
    }
}
