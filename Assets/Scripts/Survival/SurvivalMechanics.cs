using UnityEngine;

public class SurvivalMechanics : MonoBehaviour
{
    public bool isBleeding = false;
    public bool isKnockedDown = false;
    private PlayerStats stats;

    private void Start() => stats = GetComponent<PlayerStats>();

    private void Update()
    {
        if (isBleeding && stats != null) stats.TakeDamage(1f * Time.deltaTime);
    }

    public void ApplyBandage()
    {
        isBleeding = false;
        if (stats != null) stats.health += 15f;
    }
}

public class Campfire : MonoBehaviour
{
    public bool isLit = false;
    public void CookMeat() { if (isLit) Debug.Log("Meat Cooked (+30 Food)"); }
}
