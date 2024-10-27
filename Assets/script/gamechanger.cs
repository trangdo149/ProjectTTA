using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamechanger : MonoBehaviour
{
    public void ChangeScene(string menuScene)
    {
        SceneManager.LoadScene("menuScene");
    }
}
