using UnityEngine;
using UnityEngine.UI;

public class StructureHealthBar : MonoBehaviour
{
    public Image hpFillImage;
    public Text hpText;
    private BuildingPiece targetPiece;

    void Start() => targetPiece = GetComponentInParent<BuildingPiece>();

    void Update()
    {
        if (targetPiece == null) return;
        float fillAmount = Mathf.Clamp01(targetPiece.health / 500f);
        if (hpFillImage != null) hpFillImage.fillAmount = fillAmount;
        if (hpText != null) hpText.text = $"{Mathf.CeilToInt(targetPiece.health)} / 500";
    }
}
