using UnityEngine;

public class ServerSystem : MonoBehaviour
{
    public enum ServerType { Bloody, Rampage, Standard, Ranked, Social }
    public ServerType activeServer = ServerType.Standard;

    public void ConnectToServer(ServerType type)
    {
        activeServer = type;
        Debug.Log($"Connecting to {type} Server...");
    }
}
