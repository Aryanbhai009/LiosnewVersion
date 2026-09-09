using UnityEngine;
using System;

public class PaymentStore : MonoBehaviour
{
    public int blueTickets = 0;
    public string merchantUPI = "yourname@upi";
    public string merchantName = "LIOS Store";

    public void AddTickets(int amount) => blueTickets += amount;

    public bool SpendTickets(int amount)
    {
        if (blueTickets >= amount) { blueTickets -= amount; return true; }
        return false;
    }

    public void PayViaUPI(float amountINR, string itemID)
    {
        string txnID = "TXN_" + UnityEngine.Random.Range(100000, 999999);

        #if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            string upiUri = $"upi://pay?pa={merchantUPI}&pn={Uri.EscapeDataString(merchantName)}&tr={txnID}&am={amountINR:F2}&cu=INR&tn={Uri.EscapeDataString(itemID)}";
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent", intentClass.GetStatic<string>("ACTION_VIEW"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", upiUri);

            intentObject.Call<AndroidJavaObject>("setData", uriObject);
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Select UPI App");

            currentActivity.Call("startActivityForResult", chooser, 3001);
        }
        catch (Exception e) { Debug.LogError("UPI Intent Failed: " + e.Message); }
        #else
        Debug.Log($"[Editor Test] UPI Triggered: ₹{amountINR} for {itemID}");
        OnPaymentSuccess("TEST_SUCCESS");
        #endif
    }

    public void OnPaymentSuccess(string response)
    {
        AddTickets(100); // Grants Blue Tickets (Pure Cosmetics)
    }
}
