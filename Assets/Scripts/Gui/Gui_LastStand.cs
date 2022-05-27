using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Gui_LastStand : GUI_Active
{
    public Sprite[] Cooldowns;

    public void BtnMap_Handler()
    {
        isMap = !isMap;
        PnlMap.gameObject.SetActive(isMap);
    }

    public override void BtnExit_Handler()
    {
        SceneManager.LoadScene("CampFireScene");
    }

    protected override void InitializeComponent()
    {
        PnlMap = transform.Find("PnlMap");

        TxtStage = transform.Find("TxtStage").GetComponent<TextMeshProUGUI>();
        TxtKill = transform.Find("TxtKill").GetComponent<TextMeshProUGUI>();
        TxtGp = transform.Find("TxtGp").GetComponent<TextMeshProUGUI>();
        TxtQty1 = transform.Find("TxtQty1").GetComponent<TextMeshProUGUI>();
        TxtQty2 = transform.Find("TxtQty2").GetComponent<TextMeshProUGUI>();

        PnlCd1 = transform.Find("PnlCd (1)").GetComponent<Image>();
        PnlCd2 = transform.Find("PnlCd (2)").GetComponent<Image>();
        PnlCd3 = transform.Find("PnlCd (3)").GetComponent<Image>();
        PnlCd4 = transform.Find("PnlCd (4)").GetComponent<Image>();

        PnlCooldowns = new Image[] {
            PnlCd1, PnlCd2, PnlCd3, PnlCd4,
        };

        BarHp = transform.Find("BarHp").GetComponent<Slider>();
        BarMp = transform.Find("BarMp").GetComponent<Slider>();
        BarSp = transform.Find("BarSp").GetComponent<Slider>();

        input.GamePlay.Map.performed += (e) => {
            BtnMap_Handler();
        };

        player = Player.GetComponent<PlayerActive>();
        isMap = false;
    }

    protected override void GuiMonitor()
    {
        BarHp.maxValue = Data.HealthPoint.MaximumPoint;
        BarMp.maxValue = Data.MagicPoint.MaximumPoint;
        BarSp.maxValue = Data.StaminaPoint.MaximumPoint;

        BarHp.value = Data.HealthPoint.CurrentPoint;
        BarMp.value = Data.MagicPoint.CurrentPoint;
        BarSp.value = Data.StaminaPoint.CurrentPoint;

        TxtStage.text = Data.LevelPoint.ToString();
        TxtKill.text = $"Kill : {Data.KillPoint}";
        TxtGp.text = Data.GamePoint.ToString();

        TxtQty1.text = $"x{Data.Item_Elixir.Amount}";
        TxtQty2.text = $"x{Data.Item_Scroll.Amount}";

        for (int i = 0; i < player.CastTime.Length; i++)
        {
            if (player.CastTime[i] > 0)
            {
                var n = Mathf.RoundToInt(player.CastTime[i]);
                PnlCooldowns[i].gameObject.SetActive(true);
                PnlCooldowns[i].sprite = Cooldowns[n];
            }

            if (PnlCooldowns[i].sprite = Cooldowns[0])
            {
                PnlCooldowns[i].gameObject.SetActive(false);
            }
        }
    }

    private Transform PnlMap;

    private TextMeshProUGUI TxtStage;
    private TextMeshProUGUI TxtKill;
    private TextMeshProUGUI TxtGp;
    private TextMeshProUGUI TxtQty1;
    private TextMeshProUGUI TxtQty2;

    private Image[] PnlCooldowns;
    private Image PnlCd1;
    private Image PnlCd2;
    private Image PnlCd3;
    private Image PnlCd4;

    private Slider BarHp;
    private Slider BarSp;
    private Slider BarMp;

    private PlayerActive player;
    private bool isMap;
}
