using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    // Component references
    Transform MyTransform;
    Camera MyCamera;

    // Default joints
    readonly float yDefault = 3.0f;
    readonly float xDefault = 5.0f;
    readonly float DefaultZoom = 3.375f;

    // Transform values
    float yRange = 0.3f;
    float yNew = 0.0f;
    float xRange = 0.5f;
    float xNew = 0.0f;

    // Zoom variables
    float ZoomMax = 2.0f;
    float ZoomCurr = 0.0f;
    float ZoomDiff = 0.0f;
    float NormalizedZoom = 0.0f;

    // Time variables
    float TimePassed = 0.0f;
    float TimeDiff = 0.0f;
    float NormalizedTime = 0.0f;
    float EulerParam = 0.0f;
    float ShakeDuration = 2.5f;

    // General variable
    bool IsCameraShaking = false;


    void Start()
    {
        MyTransform = GetComponent<Transform>();
        MyCamera = GetComponent<Camera>();

        ResetValues();

        // Default values
        MyTransform.position.Set(xDefault, yDefault, -10);
        MyCamera.orthographicSize = DefaultZoom;
    }

    void Update()
    {
        if (IsCameraShaking)
        {
            TimePassed += Time.deltaTime;

            // Stop camera shaking if the time passed has reached its end.
            if (!(TimePassed >= ShakeDuration))
            {
                // Update time variables
                TimeDiff = ShakeDuration - TimePassed;
                NormalizedTime = TimePassed / ShakeDuration;

                //////////////////////////////////
                //////// ANIMATION STUDIO //////// 

                // Inverse exponential growth normalized parameter
                EulerParam = 1.0f - Mathf.Exp(-5.0f * (NormalizedTime));

                // TRANSLATE
                yNew = yDefault + (Random.Range(-yRange, yRange) * (1.0f - EulerParam));
                xNew = xDefault + (Random.Range(-xRange, xRange) * (1.0f - EulerParam));
                MyTransform.SetPositionAndRotation(new Vector3(xNew, yNew, -10.0f), Quaternion.identity);

                // ZOOM
                ZoomDiff = ZoomMax - DefaultZoom;
                ZoomCurr = ZoomDiff * EulerParam;
                MyCamera.orthographicSize = ZoomMax - ZoomCurr;

                //////// ANIMATION STUDIO //////// 
                //////////////////////////////////

            }
            else
            {
                SetCameraShake(false);
            }
        }
    }

    // Toggle camera shake
    public void SetCameraShake(bool IsActive, bool IsFinalLevel = false)
    {
        ResetValues(IsFinalLevel);
        IsCameraShaking = (IsActive) ? true : false;


    }

    // Reset all joints for next camera shake
    private void ResetValues(bool IsFinalLevel = false)
    {
        TimePassed = 0.0f;

        // Extra power in the final level 3
        if (IsFinalLevel)
        {
            yRange = 1.0f;
            xRange = 1.9f;
            ZoomMax = 2.0f;
            ShakeDuration = 3.0f;
        }
        else
        {
            yRange = 0.3f;
            xRange = 0.5f;
            ZoomMax = 2.0f;
            ShakeDuration = 2.5f;
        }
    }
}
