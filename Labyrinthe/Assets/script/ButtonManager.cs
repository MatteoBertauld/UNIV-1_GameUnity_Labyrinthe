using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject settingPanel;

public void ToggleSettingsPanel()
{
    settingPanel.SetActive(!settingPanel.activeSelf);
}
}