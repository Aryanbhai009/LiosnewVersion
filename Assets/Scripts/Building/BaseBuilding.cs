using UnityEngine;

public class BaseBuilding : MonoBehaviour
{
    public Camera mainCam;
    public LayerMask buildableLayer;
    public GameObject wallPreviewPrefab;
    private GameObject currentPreview;
    private bool isBuilding = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) isBuilding = !isBuilding;

        if (isBuilding)
        {
            Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out RaycastHit hit, 10f, buildableLayer))
            {
                if (currentPreview == null) currentPreview = Instantiate(wallPreviewPrefab);
                currentPreview.transform.position = hit.point;

                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(wallPreviewPrefab, hit.point, Quaternion.identity);
                }
            }
        }
        else if (currentPreview != null) Destroy(currentPreview);
    }
}

public class BuildingPiece : MonoBehaviour
{
    public enum Tier { Wood, Stone, Iron, Reinforced }
    public Tier currentTier = Tier.Wood;
    public float health = 250f;
    public ToolCupboard linkedTC;

    void Update()
    {
        if (linkedTC != null && !linkedTC.HasUpkeep())
        {
            health -= 0.1f * Time.deltaTime; // Base Decay Engine
        }
    }
}

public class ToolCupboard : MonoBehaviour
{
    public string ownerID;
    public int storedWood = 0;
    public int storedStone = 0;

    public bool HasUpkeep() => storedWood > 0 || storedStone > 0;
}

public class DoorLock : MonoBehaviour
{
    public string pinCode = "1234";
    public bool isLocked = true;

    public bool TryUnlock(string code) => (code == pinCode) ? !(isLocked = false) : false;
}
