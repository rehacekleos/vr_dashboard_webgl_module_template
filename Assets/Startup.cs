
using UnityEngine;
using VrDashboardLogger.Editor;
using VrDashboardLogger.Editor.Classes;

public class Startup : MonoBehaviour
{
    
    
    void Start()
    {
        var vrLogger = gameObject.AddComponent<VrLogger>();
        vrLogger.GetVrData(HandleVrData);
    }

    // Here you can make your own implementation of VR data
    private void HandleVrData(VrData data)
    {
        Debug.Log(data);

        foreach (var record in data.records)
        {
            Debug.Log(record);
        }
    }
}