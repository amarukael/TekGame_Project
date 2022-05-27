using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Origin_DamagedCreep => Resources.Load<GameObject>("Prefabs/Enemies/DamagedCreep");
    public GameObject Origin_NativeCreep => Resources.Load<GameObject>("Prefabs/Enemies/NativeCreep");
    public GameObject Origin_WarriorCreep => Resources.Load<GameObject>("Prefabs/Enemies/WarriorCreep");
    public GameObject Origin_WitchCreep => Resources.Load<GameObject>("Prefabs/Enemies/WitchCreep");
    public GameObject Origin_SkeltCreep => Resources.Load<GameObject>("Prefabs/Enemies/SkeltCreep");
    public GameObject Origin_CastLight => Resources.Load<GameObject>("Prefabs/Stuffs/CastLight");
    public GameObject Origin_Fire1 => Resources.Load<GameObject>("Prefabs/Stuffs/Fire_Style1");
    public GameObject Origin_Fire2 => Resources.Load<GameObject>("Prefabs/Stuffs/Fire_Style2");
    public GameObject Origin_Shell => Resources.Load<GameObject>("Prefabs/Stuffs/ShellEffect");
    public GameObject Origin_Damage => Resources.Load<GameObject>("Prefabs/Stuffs/DamagePop");
    public GameObject Origin_Elixir => Resources.Load<GameObject>("Prefabs/PowerUps/Item_Elixir");
    public GameObject Origin_Scroll => Resources.Load<GameObject>("Prefabs/PowerUps/Item_Scroll");
    //public GameObject Origin_Lumber => Resources.Load<GameObject>("Prefabs/PowerUps/Item_Lumber");
    //public GameObject Origin_CrudeOil => Resources.Load<GameObject>("Prefabs/PowerUps/Item_CrudeOil");
    public GameObject Origin_Green => Resources.Load<GameObject>("Prefabs/PowerUps/Power_Green");
    public GameObject Origin_Red => Resources.Load<GameObject>("Prefabs/PowerUps/Power_Red");
    public GameObject Origin_Blue => Resources.Load<GameObject>("Prefabs/PowerUps/Power_Blue");

    public GameData Data;

    public static GameManager Instance { get; private set; }

    public ItemCollection ItemGenerate(ItemSet ItemId)
    {
        switch (ItemId)
        {
            case ItemSet.GreenOre: return Data.Item_GreenOre;
            case ItemSet.RedStone: return Data.Item_RedStone;
            case ItemSet.BlueCrystal: return Data.Item_BlueCrystal;
            case ItemSet.Lumber: return Data.Item_Lumber;
            case ItemSet.CrudeOil: return Data.Item_CrudeOil;
            case ItemSet.MagicCoal: return Data.Item_MagicCoal;
            case ItemSet.MagicPowder: return Data.Item_MagicPowder;
            case ItemSet.GoldBar: return Data.Item_GoldBar;
            case ItemSet.Elixir: return Data.Item_Elixir;
            case ItemSet.Scroll: return Data.Item_Scroll;
        }
        return null;
    }

    public Vector3 RandomPosition(Vector3 basepos)
    {
        float x = UnityEngine.Random.Range(-1f, 1f);
        float y = UnityEngine.Random.Range(-1f, 1f);
        var rand = basepos + new Vector3(x, y);
        return rand;
    }

    private void Start()
    {
        Instance = this;
    }
}

[Serializable]
public class ItemCollection
{
    public const int MAX_ITEM = 999;

    public ItemSet Uid;
    public string Name;
    public string Description;
    public int Amount;

    public int Stock
    {
        get
        {
            return Amount;
        }
        set
        {
            Amount = value;
            if (Amount > MAX_ITEM)
            {
                Amount = MAX_ITEM;
            }
            else if (Amount < 0)
            {
                Amount = 0;
            }
        }
    }

    public static ItemCollection operator +(ItemCollection a, int b)
    {
        a.Stock = a.Amount + b;
        return a;
    }

    public static ItemCollection operator -(ItemCollection a, int b)
    {
        a.Stock = a.Amount - b;
        return a;
    }
}

public enum UnitState
{
    Idle, Move, Attack, Cast, Dead,
}

public enum DamageState
{
    Default,
    PlayerPhs, PlayerMag,
    EnemyPhs, AllyHeal,
}

public enum EnemySet
{
    Default, Damaged, Native, Warrior, Witch, Skeleton,
}

public enum SkillSet
{
    Default, SplashSwing, DemonShell,
}

public enum ItemSet
{
    Default,
    GreenOre, RedStone, BlueCrystal,
    Lumber, CrudeOil, MagicCoal, MagicPowder, GoldBar,
    Elixir, Scroll,
}

public enum LevelSet
{
    Demo, Easy, Normal, Hard,
}
