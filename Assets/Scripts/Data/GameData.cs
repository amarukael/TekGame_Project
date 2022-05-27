using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data",
                 menuName = "ScriptableObject/GameData",
                 order = 1)]
public class GameData : ScriptableObject
{
    public UnitPoint HealthPoint;
    public UnitPoint MagicPoint;
    public UnitPoint StaminaPoint;
    public float MoveSpeed;
    public float AtkSpeed;

    public LevelSet LevelPoint;
    public int KillPoint;
    public int GamePoint;

    public ItemCollection Item_GreenOre;
    public ItemCollection Item_RedStone;
    public ItemCollection Item_BlueCrystal;
    public ItemCollection Item_GoldBar;
    public ItemCollection Item_Lumber;
    public ItemCollection Item_CrudeOil;
    public ItemCollection Item_MagicCoal;
    public ItemCollection Item_MagicPowder;
    public ItemCollection Item_Elixir;
    public ItemCollection Item_Scroll;

    public int GamePointStock
    {
        get
        {
            return GamePoint;
        }
        set
        {
            GamePoint = value;
            if (GamePoint > MAX_POINT)
            {
                GamePoint = MAX_POINT;
            }
            else if (GamePoint < 0)
            {
                GamePoint = 0;
            }
        }
    }

    public void ResetGame()
    {
        HealthPoint.MaximumStock = 2500;
        MagicPoint.MaximumStock = 200;
        StaminaPoint.MaximumStock = 500;

        MoveSpeed = 5f;
        AtkSpeed = 0.5f;
        LevelPoint = LevelSet.Demo;
        KillPoint = 0;
        GamePoint = 100;

        Item_Elixir.Stock += 10;
        Item_Scroll.Stock += 5;
    }

    private const int MAX_POINT = 99999;
}
