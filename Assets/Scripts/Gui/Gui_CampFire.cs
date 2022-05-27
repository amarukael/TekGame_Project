using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Gui_CampFire : GUI_Active
{
    public void BtnHome_Handler()
    {
        if (PnlHome.gameObject.activeInHierarchy)
        {
            PnlHome.gameObject.SetActive(false);
            Player.position = new Vector3(19.35f, -26f, 0f);
        }
        else
        {
            DisableMenuPanel();
            PnlHome.gameObject.SetActive(true);
            Player.position = new Vector3(-9f, 8f, 0f);
            SubCamera.position = new Vector3(-9.5f, 8f, -10f);
        }
        MainCamera.position = new Vector3(19.15f, -25.45f, -10f);
    }

    public void BtnStock_Handler()
    {
        if (PnlStock.gameObject.activeInHierarchy)
        {
            PnlStock.gameObject.SetActive(false);
            Player.position = new Vector3(20.5f, -13.86f, 0f);
        }
        else
        {
            DisableMenuPanel();
            PnlStock.gameObject.SetActive(true);
            Player.position = new Vector3(-10.24f, 23f, 0f);
            SubCamera.position = new Vector3(-9.5f, 23.5f, -10f);
        }
        MainCamera.position = new Vector3(20.38f, -11.54f, -10f);
    }

    public void BtnBench_Handler()
    {
        if (PnlBench.gameObject.activeInHierarchy)
        {
            PnlBench.gameObject.SetActive(false);
            Player.position = new Vector3(13.45f, -20.3f, 0f);
        }
        else
        {
            DisableMenuPanel();
            PnlBench.gameObject.SetActive(true);
            Player.position = new Vector3(-24.52f, 15.8f, 0f);
            SubCamera.position = new Vector3(-24.49f, 16.38f, -10f);
        }
        MainCamera.position = new Vector3(10.8f, -19f, -10f);
    }

    public void BtnGoTo_Handler()
    {
        if (PnlGoTo.gameObject.activeInHierarchy)
        {
            PnlGoTo.gameObject.SetActive(false);
        }
        else
        {
            DisableMenuPanel();
            PnlGoTo.gameObject.SetActive(true);
        }
        Player.position = new Vector3(20f, -16.35f, 0f);
        MainCamera.position = new Vector3(23.73f, -18.39f, -10f);
    }

    public void BtnStats_Handler()
    {
        var panel = PnlHome.Find("PnlStats");
        if (panel.gameObject.activeInHierarchy)
        {
            panel.gameObject.SetActive(false);
        }
        else
        {
            DisableContentPanel();
            panel.gameObject.SetActive(true);
        }
        Player.position = new Vector3(-9f, 8f, 0f);
        SubCamera.position = new Vector3(-9.5f, 8f, -10f);
    }

    public void BtnRestore_Handler()
    {
        var panel = PnlHome.Find("PnlRestore");
        if (panel.gameObject.activeInHierarchy)
        {
            panel.gameObject.SetActive(false);
        }
        else
        {
            DisableContentPanel();
            panel.gameObject.SetActive(true);
        }
        Player.position = new Vector3(-11.2f, 10.84f, 0f);
        SubCamera.position = new Vector3(-9.5f, 11.86f, -10f);
    }

    public void BtnLibrary_Handler()
    {
        var panel = PnlHome.Find("PnlLibrary");
        if (panel.gameObject.activeInHierarchy)
        {
            panel.gameObject.SetActive(false);
        }
        else
        {
            DisableContentPanel();
            panel.gameObject.SetActive(true);
        }
        Player.position = new Vector3(-6.85f, 11.26f, 0f);
        SubCamera.position = new Vector3(-9.5f, 11.86f, -10f);
    }

    public void BtnInventory_Handler()
    {
        var panel = PnlStock.Find("PnlInventory");
        if (panel.gameObject.activeInHierarchy)
        {
            panel.gameObject.SetActive(false);
        }
        else
        {
            DisableContentPanel();
            panel.gameObject.SetActive(true);
        }
        Player.position = new Vector3(-10.24f, 23f, 0f);
        SubCamera.position = new Vector3(-9.5f, 23.5f, -10f);
    }

    public void BtnFurnace_Handler()
    {
        var panel = PnlBench.Find("PnlFurnace");
        if (panel.gameObject.activeInHierarchy)
        {
            panel.gameObject.SetActive(false);
        }
        else
        {
            DisableContentPanel();
            panel.gameObject.SetActive(true);
        }
        Player.position = new Vector3(-26.37f, 22.65f, 0f);
        SubCamera.position = new Vector3(-24.49f, 23.51f, -10f);
    }

    public void BtnCraft_Handler()
    {
        var panel = PnlBench.Find("PnlCraft");
        if (panel.gameObject.activeInHierarchy)
        {
            panel.gameObject.SetActive(false);
        }
        else
        {
            DisableContentPanel();
            panel.gameObject.SetActive(true);
        }
        Player.position = new Vector3(-22.96f, 18.15f, 0f);
        SubCamera.position = new Vector3(-24.49f, 18.75f, -10f);
    }

    public void BtnNightmare_Handler()
    {
        SceneManager.LoadScene("LastStandScene");
    }

    public void BtnDaylight_Handler()
    {

    }

    public void BtnCheckRestore_Handler(int item)
    {
        var validate = false;
        var trade1 = Data.Item_GreenOre.Amount;
        var trade2 = Data.Item_RedStone.Amount;
        var trade3 = Data.Item_BlueCrystal.Amount;
        var trade4 = Data.Item_CrudeOil.Amount;
        var trade5 = Data.Item_Lumber.Amount;
        var trade6 = Data.Item_GoldBar.Amount;

        Action Exchange = null;
        switch (item)
        {
            case 1: // HP
                validate = trade1 >= 10 && trade4 >= 1 && trade6 >= 1;
                Exchange = () => {
                    Data.HealthPoint.CurrentPoint = Data.HealthPoint.MaximumPoint;

                    Data.Item_GreenOre -= 10;
                    Data.Item_CrudeOil -= 1;
                    Data.Item_GoldBar -= 1;
                };
                break;
            case 2: // MP
                validate = trade3 >= 2 && trade5 >= 1 && trade6 >= 1;
                Exchange = () => {
                    Data.MagicPoint.CurrentPoint = Data.MagicPoint.MaximumPoint;

                    Data.Item_BlueCrystal -= 2;
                    Data.Item_Lumber -= 1;
                    Data.Item_GoldBar -= 1;
                };
                break;
            case 3: // SP
                validate = trade2 >= 2 && trade5 >= 1 && trade6 >= 1;
                Exchange = () => {
                    Data.StaminaPoint.CurrentPoint = Data.StaminaPoint.MaximumPoint;

                    Data.Item_RedStone -= 2;
                    Data.Item_Lumber -= 1;
                    Data.Item_GoldBar -= 1;
                };
                break;
        }

        if (validate)
        {
            Exchange?.Invoke();
        }
        else
        {
            PnlNotice.gameObject.SetActive(true);
            notice = 2f;
        }
    }

    public void BtnCheckFurnace_Handler(int item)
    {
        var validate = false;
        var trade1 = Data.Item_GreenOre.Amount;
        var trade2 = Data.Item_RedStone.Amount;
        var trade3 = Data.Item_BlueCrystal.Amount;
        var trade4 = Data.Item_MagicPowder.Amount;
        var trade5 = Data.Item_Lumber.Amount;
        var trade6 = Data.Item_CrudeOil.Amount;
        var trade7 = Data.Item_GoldBar.Amount;
        var trade8 = Data.GamePoint;

        Action Exchange = null;
        switch ((ItemSet)item)
        {
            case ItemSet.MagicCoal:
                validate = trade4 >= 1 && trade5 >= 1 && trade7 >= 1;
                Exchange = () => {
                    Data.Item_MagicCoal += 1;

                    Data.Item_MagicPowder -= 1;
                    Data.Item_Lumber -= 1;
                    Data.Item_GoldBar -= 1;
                };
                break;
            case ItemSet.MagicPowder:
                validate = trade1 >= 1 && trade2 >= 1 && trade3 >= 1;
                Exchange = () => {
                    Data.Item_MagicPowder += 1;

                    Data.Item_GreenOre -= 1;
                    Data.Item_RedStone -= 1;
                    Data.Item_BlueCrystal -= 1;
                };
                break;
            case ItemSet.GoldBar:
                validate = trade8 >= 25 && trade6 >= 1 && trade5 >= 1;
                Exchange = () => {
                    Data.Item_GoldBar += 1;

                    Data.GamePoint -= 25;
                    Data.Item_CrudeOil -= 1;
                    Data.Item_Lumber -= 1;
                };
                break;
        }

        if (validate)
        {
            Exchange?.Invoke();
        }
        else
        {
            PnlNotice.gameObject.SetActive(true);
            notice = 2f;
        }
    }

    public void BtnCheckCraft_Handler(int item)
    {
        var validate = false;
        var trade1 = Data.Item_MagicPowder.Amount;
        var trade2 = Data.Item_Lumber.Amount;
        var trade3 = Data.Item_GoldBar.Amount;
        var trade4 = Data.Item_MagicCoal.Amount;

        Action Exchange = null;
        switch ((ItemSet)item)
        {
            case ItemSet.Elixir:
                validate = trade1 >= 1 && trade2 >= 1 && trade3 >= 1;
                Exchange = () => {
                    Data.Item_Elixir += 1;

                    Data.Item_MagicPowder -= 1;
                    Data.Item_Lumber -= 1;
                    Data.Item_GoldBar -= 1;
                };
                break;
            case ItemSet.Scroll:
                validate = trade1 >= 1 && trade3 >= 3 && trade4 >= 1;
                Exchange = () => {
                    Data.Item_Scroll += 1;

                    Data.Item_MagicPowder -= 1;
                    Data.Item_MagicCoal -= 1;
                    Data.Item_GoldBar -= 3;
                };
                break;
        }

        if (validate)
        {
            Exchange?.Invoke();
        }
        else
        {
            PnlNotice.gameObject.SetActive(true);
            notice = 2f;
        }
    }

    protected override void InitializeComponent()
    {
        PnlHome = transform.Find("PnlHome");
        PnlStock = transform.Find("PnlStock");
        PnlBench = transform.Find("PnlBench");
        PnlGoTo = transform.Find("PnlGoTo");
        PnlNotice = transform.Find("PnlNotice");

        var pnlStats = PnlHome.Find("PnlStats");
        TxtHp = pnlStats.Find("TxtHp").GetComponent<TextMeshProUGUI>();
        TxtMp = pnlStats.Find("TxtMp").GetComponent<TextMeshProUGUI>();
        TxtSp = pnlStats.Find("TxtSp").GetComponent<TextMeshProUGUI>();
        TxtStage = pnlStats.Find("TxtStage").GetComponent<TextMeshProUGUI>();
        TxtKill = pnlStats.Find("TxtKill").GetComponent<TextMeshProUGUI>();
        TxtGp = pnlStats.Find("TxtGp").GetComponent<TextMeshProUGUI>();

        var pnlInventory = PnlStock.Find("PnlInventory");
        var pnlContent = pnlInventory.Find("PnlStorage").Find("Viewport").Find("Content");
        Items = new SlotHandler[10];
        TxtQty = new TextMeshProUGUI[10];
        for (int i = 0; i < TxtQty.Length; i++)
        {
            var pnlItem = pnlContent.Find($"PnlItem ({i + 1})");
            TxtQty[i] = pnlItem.Find("TxtQty").GetComponent<TextMeshProUGUI>();
            Items[i] = pnlItem.GetComponent<SlotHandler>();
            Items[i].SlotAction = ItemActive;
        }
        TxtItemName = pnlInventory.Find("TxtItemName").GetComponent<TextMeshProUGUI>();
        TxtItemDesc = pnlInventory.Find("TxtItemDesc").GetComponent<TextMeshProUGUI>();
    }

    protected override void GuiMonitor()
    {
        TxtHp.text = $"{Data.HealthPoint.CurrentPoint} / {Data.HealthPoint.MaximumPoint}";
        TxtMp.text = $"{Data.MagicPoint.CurrentPoint} / {Data.MagicPoint.MaximumPoint}";
        TxtSp.text = $"{Data.StaminaPoint.CurrentPoint} / {Data.StaminaPoint.MaximumPoint}";

        TxtStage.text = Data.LevelPoint.ToString();
        TxtKill.text = $"{Data.KillPoint} pts";
        TxtGp.text = $"{Data.GamePoint} pts";

        TxtQty[0].text = Data.Item_GreenOre.Amount.ToString();
        TxtQty[1].text = Data.Item_RedStone.Amount.ToString();
        TxtQty[2].text = Data.Item_BlueCrystal.Amount.ToString();
        TxtQty[3].text = Data.Item_MagicPowder.Amount.ToString();
        TxtQty[4].text = Data.Item_MagicCoal.Amount.ToString();
        TxtQty[5].text = Data.Item_GoldBar.Amount.ToString();
        TxtQty[6].text = Data.Item_Lumber.Amount.ToString();
        TxtQty[7].text = Data.Item_CrudeOil.Amount.ToString();
        TxtQty[8].text = Data.Item_Elixir.Amount.ToString();
        TxtQty[9].text = Data.Item_Scroll.Amount.ToString();

        if (notice > 0)
        {
            notice -= Time.deltaTime;
        }

        if (notice < 0)
        {
            PnlNotice.gameObject.SetActive(false);
            notice = 0;
        }
    }

    private Transform PnlHome;
    private Transform PnlStock;
    private Transform PnlBench;
    private Transform PnlGoTo;
    private Transform PnlNotice;

    private TextMeshProUGUI TxtHp;
    private TextMeshProUGUI TxtMp;
    private TextMeshProUGUI TxtSp;
    private TextMeshProUGUI TxtStage;
    private TextMeshProUGUI TxtKill;
    private TextMeshProUGUI TxtGp;

    private SlotHandler[] Items;
    private TextMeshProUGUI[] TxtQty;
    private TextMeshProUGUI TxtItemName;
    private TextMeshProUGUI TxtItemDesc;

    private float notice;

    private void DisableMenuPanel()
    {
        PnlHome.gameObject.SetActive(false);
        PnlStock.gameObject.SetActive(false);
        PnlBench.gameObject.SetActive(false);
        PnlGoTo.gameObject.SetActive(false);
    }

    private void DisableContentPanel()
    {
        PnlHome.Find("PnlStats").gameObject.SetActive(false);
        PnlHome.Find("PnlRestore").gameObject.SetActive(false);
        PnlHome.Find("PnlLibrary").gameObject.SetActive(false);

        PnlStock.Find("PnlInventory").gameObject.SetActive(false);

        PnlBench.Find("PnlFurnace").gameObject.SetActive(false);
        PnlBench.Find("PnlCraft").gameObject.SetActive(false);
    }

    private void ItemActive(ItemCollection item)
    {
        TxtItemName.text = item.Name;
        TxtItemDesc.text = item.Description;
    }
}
