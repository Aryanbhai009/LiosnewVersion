using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public ItemData resourceGiven;
    public int health = 100;

    public void Harvest(int damage, InventoryCrafting playerInv)
    {
        health -= damage;
        playerInv.AddItem(resourceGiven, 10);
        if (health <= 0) Destroy(gameObject);
    }
}

public class Furnace : MonoBehaviour
{
    public int woodCount = 0;
    public int ironOreCount = 0;

    public void Smelt()
    {
        if (woodCount > 0 && ironOreCount > 0)
        {
            woodCount--;
            ironOreCount--;
            Debug.Log("Smelted Refined Iron!");
        }
    }
}

public class AirdropManager : MonoBehaviour
{
    public GameObject cratePrefab;
    public void DropCrate(Vector3 position) => Instantiate(cratePrefab, position, Quaternion.identity);
}
