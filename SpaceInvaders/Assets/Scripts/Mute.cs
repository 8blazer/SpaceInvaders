using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public GameObject saveManager;
	public AudioClip menuSong;
	public Sprite musicOn;
	public Sprite musicOff;
    // Start is called before the first frame update
    void Start()
    {

    }

	// Update is called once per frame
	void Update()
	{
		if (saveManager.GetComponent<SaveManager>().music && GetComponent<AudioSource>().clip == null)
		{
			GetComponent<AudioSource>().clip = menuSong;
			GetComponent<AudioSource>().Play();
		}
		else if (!saveManager.GetComponent<SaveManager>().music)
		{
			GetComponent<AudioSource>().clip = null;
		}

		if (saveManager.GetComponent<SaveManager>().music)
		{
			GetComponent<Image>().sprite = musicOn;
		}
		else
		{
			GetComponent<Image>().sprite = musicOff;
		}
	}
}
