using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Chỉ gọi cho GameObject gốc
        }
        else
        {
            Destroy(gameObject); // Hủy đối tượng trùng lặp
        }
    }
}
