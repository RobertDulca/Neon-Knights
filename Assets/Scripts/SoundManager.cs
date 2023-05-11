using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;

    GameObject OptionMenu = GameObject.Find("OptionMenu");
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.2f);
            Load();
        }
        else
        {
            Load();
        }
        //VolumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        OptionMenu.gameObject.SetActive(false);
    }

    public void changeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        Save();
    }
    private void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
    }
}
