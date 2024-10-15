using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Button[] buttons;              // Mảng chứa các nút bài hát
    public AudioSource[] audioSources;    // Mảng chứa các AudioSource tương ứng
    public Button toggleButton;           // Nút dừng/tiếp tục
    public Button volumeButton;           // Nút hiển thị slider âm lượng
    public Slider volumeSlider;           // Slider điều chỉnh âm lượng
    public Sprite playSprite;             // Hình ảnh cho nút phát
    public Sprite pauseSprite;            // Hình ảnh cho nút dừng
    private int currentPlayingIndex = -1; // Biến lưu chỉ số bài nhạc đang phát

    void Start()
    {
        // Gán sự kiện cho mỗi nút bài hát
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;  // Lưu lại chỉ số hiện tại để dùng trong lambda
            buttons[i].onClick.AddListener(() => PlayMusic(index));
        }

        // Gán sự kiện cho nút dừng/tiếp tục
        toggleButton.onClick.AddListener(TogglePlayPause);

        // Gán sự kiện cho nút hiển thị slider
        volumeButton.onClick.AddListener(ToggleVolumeSlider);

        // Gán sự kiện cho Slider để điều chỉnh âm lượng
        volumeSlider.onValueChanged.AddListener(UpdateVolume);

        // Cập nhật âm lượng ban đầu cho AudioSources
        UpdateVolume(volumeSlider.value);

        // Ẩn slider ban đầu
        volumeSlider.gameObject.SetActive(false);
    }

    void PlayMusic(int index)
    {
        // Dừng tất cả các âm thanh khác
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (i != index)
            {
                audioSources[i].Stop();  // Tắt âm thanh của các nút khác
                audioSources[i].time = 0; // Đặt lại thời gian phát về 0
            }
        }

        // Đặt lại thời gian phát về 0 cho bài nhạc được chọn
        audioSources[index].time = 0; // Đặt lại thời gian phát về 0
        audioSources[index].Play();    // Phát bài nhạc tương ứng

        // Cập nhật chỉ số bài nhạc đang phát
        currentPlayingIndex = index;

        // Thay đổi hình dạng nút cho bài nhạc đang phát
        ChangeToggleButtonSprite(false); // Đặt hình dạng nút dừng
    }

    public void TogglePlayPause()
    {
        // Kiểm tra xem có bài nhạc nào đang phát hay không
        if (currentPlayingIndex != -1)
        {
            // Nếu bài nhạc đang phát, tạm dừng nó
            if (audioSources[currentPlayingIndex].isPlaying)
            {
                audioSources[currentPlayingIndex].Pause();
                ChangeToggleButtonSprite(true); // Đặt hình dạng nút phát
            }
            else
            {
                // Nếu bài nhạc đang tạm dừng, phát tiếp từ đoạn đã dừng
                audioSources[currentPlayingIndex].Play();
                ChangeToggleButtonSprite(false); // Đặt hình dạng nút dừng
            }
        }
    }

    private void ChangeToggleButtonSprite(bool isPlay)
    {
        // Thay đổi hình ảnh của nút dừng/tiếp tục
        Image buttonImage = toggleButton.GetComponent<Image>();
        buttonImage.sprite = isPlay ? playSprite : pauseSprite;
    }

    public void UpdateVolume(float volume)
    {
        // Cập nhật âm lượng cho tất cả các AudioSource
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume; // Cập nhật âm lượng từ slider
        }
    }

    public void ToggleVolumeSlider()
    {
        // Hiện hoặc ẩn slider
        volumeSlider.gameObject.SetActive(!volumeSlider.gameObject.activeSelf);
    }
}
