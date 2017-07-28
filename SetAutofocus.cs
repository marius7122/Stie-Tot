using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SetAutofocus : MonoBehaviour {

    private void Start()
    {
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(SetAutoFocus);
    }

    void SetAutoFocus()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}
