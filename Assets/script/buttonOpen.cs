using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOpen : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Debug.Log("Panel is now " + (isActive ? "inactive" : "active"));
            Panel.SetActive(!isActive);
        }
        else
        {
            Debug.LogError("Panel is null!");
        }

    }
}
