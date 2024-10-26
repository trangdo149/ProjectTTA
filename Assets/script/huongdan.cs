using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huongdan : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        // Đảm bảo panel tắt khi bắt đầu
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem nhân vật có vào vùng kích hoạt không
        if (other.CompareTag("Player"))
        {
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Ẩn panel khi nhân vật rời khỏi khu vực
        if (other.CompareTag("Player"))
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }
}
