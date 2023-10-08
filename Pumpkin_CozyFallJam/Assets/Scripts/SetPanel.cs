using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPanel : MonoBehaviour
{
    private SettingsController settings;

    private void Awake()
    {
        settings.SetSettingsPanel(this.gameObject);
    }
}
