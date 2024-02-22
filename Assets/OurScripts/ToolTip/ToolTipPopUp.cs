using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class ToolTipPopUp : MonoBehaviour
{
    [SerializeField] private GameObject popupCanvasObject;
    [SerializeField] private RectTransform popupObject;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float padding;

    private Canvas popupCanvas;

    private void Awake()
    {
        popupCanvas = popupCanvasObject.GetComponent<Canvas>();
    }

    private void Update()
    {
        FollowCursor();
    }

    private void FollowCursor() // Kod som g�r s� att tooltipen f�ljer musen n�r den �r �ver itemet.
    {
        if (!popupCanvasObject.activeSelf) { return; }

        Vector3 newPos = Input.mousePosition + offset;
        newPos.z = 0f;
        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + popupObject.rect.width * popupCanvas.scaleFactor / 2) - padding; // Den r�knar ut avst�nd mellan kanten av sk�rmen till musen s� att tooltipen befinner sig d�r ist�llet f�r att den skulle fastna vid n�gon kant.
        if (rightEdgeToScreenEdgeDistance < 0)
        {
            newPos.x += rightEdgeToScreenEdgeDistance;
        }
        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - popupObject.rect.width * popupCanvas.scaleFactor / 2) + padding; // - || -
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            newPos.x += leftEdgeToScreenEdgeDistance;
        }
        float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + popupObject.rect.height * popupCanvas.scaleFactor) - padding; // - || -
        if (topEdgeToScreenEdgeDistance < 0)
        {
            newPos.y += topEdgeToScreenEdgeDistance;
        }
        popupObject.transform.position = newPos;
    }

    public void DisplayInfo (ItemTT item) // Visar tooltipen n�r den �r �ver item p� marken.
    {
       StringBuilder builder = new StringBuilder();

        builder.Append("<size=14>").Append(item.ColouredName).Append("</size>").AppendLine();
        builder.Append(item.GetTooltipinfoText());

        infoText.text = builder.ToString();

        popupCanvasObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
        print("hoverover");
    }

    public void HideInfo() // Tar bort informationen n�r den inte �r �ver item.
    {
        popupCanvasObject.SetActive(false);
        print("exits");
    }

}
