using UnityEngine;

public class Motorcycle : MonoBehaviour
{
    public float speed = 12f;
    public float fuelLevel = 100f;

    public void Drive(Vector3 direction)
    {
        if (fuelLevel > 0)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            fuelLevel -= 0.05f * Time.deltaTime;
        }
    }
}

public class GliderSystem : MonoBehaviour
{
    public bool isGliding = false;

    public void DeployGlider(CharacterController controller)
    {
        isGliding = true;
        controller.Move(new Vector3(0, -1.5f, 8f) * Time.deltaTime);
    }
}
