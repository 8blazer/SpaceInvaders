using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public GameObject saveManager;
	public Sprite musicOn;
	public Sprite musicOff;
	public GameObject musicPlayer;
    // Start is called before the first frame update
    void Start()
    {
		
    }

	// Update is called once per frame
	void Update()
	{
		if (saveManager.GetComponent<SaveManager>().music && !musicPlayer.GetComponent<AudioSource>().isPlaying)
		{
			musicPlayer.GetComponent<AudioSource>().volume = 1;
			musicPlayer.GetComponent<AudioSource>().Play();
		}
		else if (!saveManager.GetComponent<SaveManager>().music)
		{
			musicPlayer.GetComponent<AudioSource>().volume = 0;
			musicPlayer.GetComponent<AudioSource>().Stop();
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
