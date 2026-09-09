using UnityEngine;

public class RadiationZone : MonoBehaviour
{
    public float radiationIntensity = 5f;

    private void OnTriggerStay(Collider other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player != null) player.TakeDamage(radiationIntensity * Time.deltaTime);
    }
}

public class KeycardDoor : MonoBehaviour
{
    public enum KeycardColor { Green, Blue, Red }
    public KeycardColor requiredType;
    public bool isOpen = false;

    public bool UnlockDoor(KeycardColor insertedCard)
    {
        if (insertedCard >= requiredType) { isOpen = true; return true; }
        return false;
    }
}
