using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeExplanation : MonoBehaviour
{
	public Image explanation;
	public Text text;

	public void Show()
	{
		if (GetComponent<Button>().interactable)
		{
			explanation.GetComponent<Image>().enabled = true;
			text.GetComponent<Text>().enabled = true;
		}
	}

	public void Hide()
	{
		explanation.GetComponent<Image>().enabled = false;
		text.GetComponent<Text>().enabled = false;
	}
}
