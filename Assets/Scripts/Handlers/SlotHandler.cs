using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHandler : MonoBehaviour
{
    public ItemSet Item;
    public GameData Data;

    public Action<ItemCollection> SlotAction { get; set; }

    public ItemCollection ItemSelected
    {
        get
        {
            switch (Item)
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
    }

    public void BtnSlot_Handler()
    {
        SlotAction?.Invoke(ItemSelected);
    }
}