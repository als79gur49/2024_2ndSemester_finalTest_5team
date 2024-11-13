using UnityEngine;
//using UnityEngine.UI;
public class PanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedPanel;

    private void TogglePanel(bool isActive)
    {
        if (selectedPanel == null)
        {
            Debug.Log("패널이 할당되지 않음.");

            return;
        }

        selectedPanel.SetActive(isActive);
    }

    public void OpenPanel()
    {
        TogglePanel(true);
    }
    public void ClosePanel()
    {
        TogglePanel(false);
    }
}
