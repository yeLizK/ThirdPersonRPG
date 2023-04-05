using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FOVDetection))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        FOVDetection fovDetection = (FOVDetection)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fovDetection.transform.position, Vector3.up, Vector3.forward, 360, fovDetection.FOVRadius);

        Vector3 viewAngleLeftSide = DirectionFromAngle(fovDetection.transform.eulerAngles.y, -fovDetection.FOVAngle / 2);
        Vector3 viewAngleRightSide = DirectionFromAngle(fovDetection.transform.eulerAngles.y, fovDetection.FOVAngle / 2);

        Handles.color = Color.red;
        Handles.DrawLine(fovDetection.transform.position, fovDetection.transform.position + viewAngleLeftSide * fovDetection.FOVRadius);
        Handles.DrawLine(fovDetection.transform.position, fovDetection.transform.position + viewAngleRightSide * fovDetection.FOVRadius);

        if (fovDetection.isPlayerDetected)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fovDetection.transform.position, fovDetection.playerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    
}
