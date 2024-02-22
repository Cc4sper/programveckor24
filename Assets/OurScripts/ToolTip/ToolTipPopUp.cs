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

    private void FollowCursor() // Kod som gör så att tooltipen följer musen när den är över itemet.
    {
        if (!popupCanvasObject.activeSelf) { return; }

        Vector3 newPos = Input.mousePosition + offset;
        newPos.z = 0f;
        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + popupObject.rect.width * popupCanvas.scaleFactor / 2) - padding; // Den räknar ut avstånd mellan kanten av skärmen till musen så att tooltipen befinner sig där istället för att den skulle fastna vid någon kant.
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

    public void DisplayInfo (ItemTT item) // Visar tooltipen när den är över item på marken.
    {
       StringBuilder builder = new StringBuilder();

        builder.Append("<size=14>").Append(item.ColouredName).Append("</size>").AppendLine();
        builder.Append(item.GetTooltipinfoText());

        infoText.text = builder.ToString();

        popupCanvasObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
        print("hoverover");
    }

    public void HideInfo() // Tar bort informationen när den inte är över item.
    {
        popupCanvasObject.SetActive(false);
        print("exits");
    }

}
