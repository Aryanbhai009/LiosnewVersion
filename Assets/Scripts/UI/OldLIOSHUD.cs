using UnityEngine;

public class OldLIOSHUD : MonoBehaviour
{
    public GameObject backpackPrefab;
    public AudioSource audioSource;
    public AudioClip headshotClip;

    public void SpawnDeathBag(Vector3 position)
    {
        if (backpackPrefab != null) Instantiate(backpackPrefab, position, Quaternion.identity);
    }

    public void PlayHeadshotSound()
    {
        if (audioSource != null && headshotClip != null) audioSource.PlayOneShot(headshotClip);
    }
}
