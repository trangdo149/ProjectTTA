using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;

    public float scaleFactor = 1.5f; // Mức độ phóng to của nút ở giữa
    public float distanceModifier = 0.5f; // Điều chỉnh độ ảnh hưởng của khoảng cách

    void Update()
    {
        // Tính vị trí trung tâm của viewport (cửa sổ hiển thị)
        float centerX = scrollRect.viewport.rect.width / 2;

        foreach (Transform button in contentPanel)
        {
            // Chuyển đổi vị trí của button sang không gian của viewport
            Vector3 buttonViewportPos = scrollRect.viewport.InverseTransformPoint(button.position);

            // Tính khoảng cách giữa vị trí nút và trung tâm của viewport
            float distance = Mathf.Abs(buttonViewportPos.x - centerX);

            // Áp dụng công thức điều chỉnh kích thước dựa trên khoảng cách
            float scale = 1 - (distance * distanceModifier / scrollRect.viewport.rect.width);
            scale = Mathf.Clamp(scale, 0.5f, 1.0f); // Giới hạn kích thước không quá nhỏ hoặc quá lớn

            button.localScale = new Vector3(scale * scaleFactor, scale * scaleFactor, 1);
        }
    }
}
