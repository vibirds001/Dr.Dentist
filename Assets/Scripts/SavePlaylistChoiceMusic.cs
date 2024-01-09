using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlaylistChoiceMusic : MonoBehaviour
{
    private int PlaylistNumber;

    public GameObject ScrollArea1;
    public GameObject ScrollArea2;
    public GameObject ScrollArea3;
    public GameObject ScrollArea4;

    public GameObject Playlist1ButtonPressed;
    public GameObject Playlist1ButtonNotPressed;

    public GameObject Playlist2ButtonPressed;
    public GameObject Playlist2ButtonNotPressed;

    public GameObject Playlist3ButtonPressed;
    public GameObject Playlist3ButtonNotPressed;

    public GameObject Playlist4ButtonPressed;
    public GameObject Playlist4ButtonNotPressed;

    // Start is called before the first frame update
    void Start()
    {
        PlaylistNumber = PlayerPrefs.GetInt("PlaylistMusic", 1);
        Playlist1ButtonPressed.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaylistNumber == 1)
        {
            ScrollArea1.SetActive(true);
            ScrollArea2.SetActive(false);
            ScrollArea3.SetActive(false);
            ScrollArea4.SetActive(false);

            Playlist1ButtonPressed.SetActive(true);
            Playlist1ButtonNotPressed.SetActive(false);
            Playlist2ButtonPressed.SetActive(false);
            Playlist2ButtonNotPressed.SetActive(true);
            Playlist3ButtonPressed.SetActive(false);
            Playlist3ButtonNotPressed.SetActive(true);
            Playlist4ButtonPressed.SetActive(false);
            Playlist4ButtonNotPressed.SetActive(true);

        }
        else if (PlaylistNumber == 2)
        {
            ScrollArea1.SetActive(false);
            ScrollArea2.SetActive(true);
            ScrollArea3.SetActive(false);
            ScrollArea4.SetActive(false);

            Playlist1ButtonPressed.SetActive(false);
            Playlist1ButtonNotPressed.SetActive(true);
            Playlist2ButtonPressed.SetActive(true);
            Playlist2ButtonNotPressed.SetActive(false);
            Playlist3ButtonPressed.SetActive(false);
            Playlist3ButtonNotPressed.SetActive(true);
            Playlist4ButtonPressed.SetActive(false);
            Playlist4ButtonNotPressed.SetActive(true);
        }
        else if (PlaylistNumber == 3)
        {
            ScrollArea1.SetActive(false);
            ScrollArea2.SetActive(false);
            ScrollArea3.SetActive(true);
            ScrollArea4.SetActive(false);

            Playlist1ButtonPressed.SetActive(false);
            Playlist1ButtonNotPressed.SetActive(true);
            Playlist2ButtonPressed.SetActive(false);
            Playlist2ButtonNotPressed.SetActive(true);
            Playlist3ButtonPressed.SetActive(true);
            Playlist3ButtonNotPressed.SetActive(false);
            Playlist4ButtonPressed.SetActive(false);
            Playlist4ButtonNotPressed.SetActive(true);
        }
        else if (PlaylistNumber == 4)
        {
            ScrollArea1.SetActive(false);
            ScrollArea2.SetActive(false);
            ScrollArea3.SetActive(false);
            ScrollArea4.SetActive(true);

            Playlist1ButtonPressed.SetActive(false);
            Playlist1ButtonNotPressed.SetActive(true);
            Playlist2ButtonPressed.SetActive(false);
            Playlist2ButtonNotPressed.SetActive(true);
            Playlist3ButtonPressed.SetActive(false);
            Playlist3ButtonNotPressed.SetActive(true);
            Playlist4ButtonPressed.SetActive(true);
            Playlist4ButtonNotPressed.SetActive(false);
        }
    }

    public void Playlist1Played()
    {
        PlaylistNumber = 1;
        PlayerPrefs.SetInt("PlaylistMusic", PlaylistNumber);
        PlayerPrefs.Save();
    }

    public void Playlist2Played()
    {
        PlaylistNumber = 2;
        PlayerPrefs.SetInt("PlaylistMusic", PlaylistNumber);
        PlayerPrefs.Save();
    }

    public void Playlist3Played()
    {
        PlaylistNumber = 3;
        PlayerPrefs.SetInt("PlaylistMusic", PlaylistNumber);
        PlayerPrefs.Save();
    }

    public void Playlist4Played()
    {
        PlaylistNumber = 4;
        PlayerPrefs.SetInt("PlaylistMusic", PlaylistNumber);
        PlayerPrefs.Save();
    }

    public void ExitScene()
    {
        PlayerPrefs.Save();
    }
}
