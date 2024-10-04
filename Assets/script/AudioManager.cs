using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Button[] buttons;        // Mảng chứa các nút
    public AudioSource[] audioSources;  // Mảng chứa các AudioSource tương ứng

    void Start()
    {
        // Gán sự kiện cho mỗi nút
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;  // Lưu lại chỉ số hiện tại để dùng trong lambda
            buttons[i].onClick.AddListener(() => PlayMusic(index));
        }
    }

    void PlayMusic(int index)
    {
        // Dừng tất cả các âm thanh và đặt lại vị trí phát về 0
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (i != index)
            {
                audioSources[i].Stop();  // Tắt âm thanh của các nút khác
                audioSources[i].time = 0; // Đặt lại thời gian phát về 0
            }
        }

        // Phát âm thanh của nút được nhấn
        if (!audioSources[index].isPlaying)
        {
            audioSources[index].Play();  // Phát âm thanh tương ứng với nút được nhấn
        }
        else
        {
            // Nếu âm thanh đang phát, tắt nó đi và phát lại từ đầu
            audioSources[index].Stop();
            audioSources[index].time = 0; // Đặt lại thời gian phát về 0
            audioSources[index].Play();
        }
    }

    public void StopAllMusic()
    {
        // Dừng tất cả AudioSource trong danh sách và đặt lại vị trí phát
        foreach (AudioSource audioS in audioSources)
        {
            audioS.Stop();
            audioS.time = 0; // Đặt lại thời gian phát về 0
        }
    }
}
