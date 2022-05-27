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
            switch (Item)
            {
                case ItemSet.GreenOre:
                    gm.Data.HealthPoint.CurrentStock += 10;
                    DamageActive.PopupDamage(gm.Origin_Damage,
                                             transform.position, 10,
                                             DamageState.AllyHeal);
                    break;
                case ItemSet.RedStone:
                    gm.Data.StaminaPoint.CurrentStock += 20;
                    break;
                case ItemSet.BlueCrystal:
                    gm.Data.MagicPoint.CurrentStock += 50;
                    break;
            }
            var item = gm.ItemGenerate(Item);
            item.Stock++;
            Destroy(gameObject);
        }
    }
}
