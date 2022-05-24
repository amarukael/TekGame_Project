using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public ItemSet Item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var gm = GameManager.Instance;
        if (collision.CompareTag("Player") && collision.isTrigger)
        {
            var player = collision.GetComponent<PlayerActive>();
            switch (Item) {
                case ItemSet.GreenOre:
                    player.HealthPoint.CurrentStock += 10;
                    DamageActive.PopupDamage(gm.Origin_Damage,
                                             transform.position, 10,
                                             DamageState.AllyHeal);
                    break;
                case ItemSet.RedStone:
                    player.StaminaPoint.CurrentStock += 20;
                    break;
                case ItemSet.BlueCrystal:
                    player.MagicPoint.CurrentStock += 50;
                    break;
                case ItemSet.Elixir:
                    gm.Item_Elixir++;
                    break;
                case ItemSet.Scroll:
                    gm.Item_Scroll++;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
