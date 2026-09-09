using UnityEngine;

public class ExplosiveC4 : MonoBehaviour
{
    public float fuseTime = 10f;
    public float explosiveDamage = 1200f;
    public float radius = 4f;

    public void PlantC4() => Invoke(nameof(Detonate), fuseTime);

    private void Detonate()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        foreach (var hit in hits)
        {
            BuildingPiece wall = hit.GetComponent<BuildingPiece>();
            if (wall != null)
            {
                wall.health -= explosiveDamage;
                if (wall.health <= 0) Destroy(wall.gameObject);
            }
        }
        Destroy(gameObject);
    }
}

public class ShotgunTrap : MonoBehaviour
{
    public float trapDamage = 150f;
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player != null) player.TakeDamage(trapDamage);
    }
}
