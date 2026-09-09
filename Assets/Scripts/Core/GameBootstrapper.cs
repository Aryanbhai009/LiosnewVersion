using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Initializing Classic LIOS Systems...");
        if (FindObjectOfType<GameManager>() == null) new GameObject("GameManager").AddComponent<GameManager>();
        if (FindObjectOfType<PaymentStore>() == null) new GameObject("PaymentStore").AddComponent<PaymentStore>();
    }
}
