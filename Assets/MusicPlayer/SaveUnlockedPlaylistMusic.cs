using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUnlockedPlaylistMusic : MonoBehaviour
{
    private int UnlockedPlaylistNumber;

    public GameObject Playlist2ButtonLock;
    public GameObject Playlist3ButtonLock;
    public GameObject Playlist4ButtonLock;

    public GameObject Playlist2ButtonUnlock;
    public GameObject Playlist3ButtonUnlock;
    public GameObject Playlist4ButtonUnlock;

    // Start is called before the first frame update
    void Start()
    {
        UnlockedPlaylistNumber = PlayerPrefs.GetInt("UnlockedPlaylistMusic", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (UnlockedPlaylistNumber == 2)
        {
            Destroy(Playlist2ButtonLock);
            Playlist2ButtonUnlock.SetActive(true);
        }

        else if (UnlockedPlaylistNumber == 3)
        {
            Destroy(Playlist3ButtonLock);
            Playlist3ButtonUnlock.SetActive(true);
            Destroy(Playlist2ButtonLock);
            Playlist2ButtonUnlock.SetActive(true);
        }
        else if (UnlockedPlaylistNumber == 4)
        {
            Destroy(Playlist4ButtonLock);
            Playlist4ButtonUnlock.SetActive(true);
            Destroy(Playlist3ButtonLock);
            Playlist3ButtonUnlock.SetActive(true);
            Destroy(Playlist2ButtonLock);
            Playlist2ButtonUnlock.SetActive(true);
        }
    }
    public void Playlist2Unlocked()
    {
        UnlockedPlaylistNumber = 2;
        PlayerPrefs.SetInt("UnlockedPlaylistMusic", UnlockedPlaylistNumber);
        PlayerPrefs.Save();
    }

    public void Playlist3Unlocked()
    {
        UnlockedPlaylistNumber = 3;
        PlayerPrefs.SetInt("UnlockedPlaylistMusic", UnlockedPlaylistNumber);
        PlayerPrefs.Save();
    }
    public void Playlist4Unlocked()
    {
        UnlockedPlaylistNumber = 4;
        PlayerPrefs.SetInt("UnlockedPlaylistMusic", UnlockedPlaylistNumber);
        PlayerPrefs.Save();
    }

    public void ExitScene()
    {
        PlayerPrefs.SetInt("UnlockedPlaylistMusic", UnlockedPlaylistNumber);
    }
}
