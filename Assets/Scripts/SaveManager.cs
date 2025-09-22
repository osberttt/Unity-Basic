using UnityEngine;

public static class SaveManager
{

    // key, value pair
    public static void SaveMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public static void SaveSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat("SfxVolume", volume);
        PlayerPrefs.Save();
    }

    public static float GetMusicVolume()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            return PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            return 1;
        }
    }

    public static float GetSfxVolume()
    {
        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            return PlayerPrefs.GetFloat("SfxVolume");
        }
        else
        {
            return 1;
        }
    }
}
