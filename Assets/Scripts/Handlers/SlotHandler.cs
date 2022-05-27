using System;
using UnityEngine;

public class SlotHandler : MonoBehaviour
{
    public ItemSet Item;

    public Action<ItemCollection> SlotAction { get; set; }

    public void BtnSlot_Handler()
    {
        SlotAction?.Invoke(GameManager.Instance.ItemGenerate(Item));
    }
}
