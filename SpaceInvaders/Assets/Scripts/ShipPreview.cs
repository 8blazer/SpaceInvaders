using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPreview : MonoBehaviour
{
    public string direction = "";
    public GameObject saveManager;
    public GameObject UI_Manager;
    public Text unlockText;
    public Image checkmark;

    public Sprite defaultPreview;
    public Sprite pinkPreview;
    public Sprite greenPreview;
    public Sprite bluePreview;
    public Sprite monochromePreview;
    public Sprite redPreview;
    public Sprite doppelgangerPreview;
    public Sprite flamePreview;
    public Sprite rainbowPreview;
    public Sprite glitchPreview;
    public Sprite weaponPreview;
    public Sprite enemyPreview;
    public Sprite upsideDownPreview;
    public Sprite goldPreview;
    public Sprite hiddenPreview;

    private void Start()
    {
        if (PlayerPrefs.GetString("ship") == "default")
        {
            checkmark.enabled = true;
            GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == "fadeLeft")
        {
            GetComponent<Image>().color += new Color(0, 0, 0, -5 * Time.deltaTime);
            unlockText.GetComponent<Text>().color += new Color(0, 0, 0, -7 * Time.deltaTime);
            GetComponent<RectTransform>().position += new Vector3(-3000 * Time.deltaTime, 0, 0);
            checkmark.color += new Color(0, 0, 0, -7 * Time.deltaTime);
            if (GetComponent<RectTransform>().localPosition.x < -700)
            {
                direction = "";
				GetComponent<Image>().color = new Color(1, 1, 1, 0);
				GetComponent<Image>().sprite = hiddenPreview;
                GetComponent<Button>().interactable = false;
                unlockText.text = "";
                checkmark.enabled = false;
            }
        }
        else if (direction == "fadeRight")
        {
			GetComponent<Image>().color += new Color(0, 0, 0, -5 * Time.deltaTime);
			unlockText.GetComponent<Text>().color += new Color(0, 0, 0, -7 * Time.deltaTime);
			GetComponent<RectTransform>().position += new Vector3(3000 * Time.deltaTime, 0, 0);
			checkmark.color += new Color(0, 0, 0, -7 * Time.deltaTime);
			if (GetComponent<RectTransform>().localPosition.x > 700)
            {
                direction = "";
				GetComponent<Image>().color = new Color(1, 1, 1, 0);
				GetComponent<Image>().sprite = hiddenPreview;
                GetComponent<Button>().interactable = false;
                unlockText.text = "";
                checkmark.enabled = false;
            }
        }
        else if (direction == "appearRight")
        {
            GetComponent<Image>().color += new Color(0, 0, 0, 5 * Time.deltaTime);
            unlockText.GetComponent<Text>().color += new Color(0, 0, 0, 6 * Time.deltaTime);
            GetComponent<RectTransform>().position += new Vector3(-3000 * Time.deltaTime, 0, 0);
            checkmark.color += new Color(0, 0, 0, 6 * Time.deltaTime);
            if (GetComponent<RectTransform>().localPosition.x < 0)
            {
                direction = "";
				GetComponent<Image>().color = new Color(1, 1, 1, 1);
				unlockText.GetComponent<Text>().color = new Color(0, 0, 0, 1);
                checkmark.color = new Color(1, 1, 1, 1);
            }
        }
        else if (direction == "appearLeft")
        {
            GetComponent<Image>().color += new Color(0, 0, 0, 5 * Time.deltaTime);
            unlockText.GetComponent<Text>().color += new Color(0, 0, 0, 6 * Time.deltaTime);
            GetComponent<RectTransform>().position += new Vector3(3000 * Time.deltaTime, 0, 0);
            checkmark.color += new Color(0, 0, 0, 6 * Time.deltaTime);
            if (GetComponent<RectTransform>().localPosition.x > 0)
            {
                direction = "";
				GetComponent<Image>().color = new Color(1, 1, 1, 1);
                unlockText.GetComponent<Text>().color = new Color(0, 0, 0, 1);
                checkmark.color = new Color(1, 1, 1, 1);
            }
        }
    }

    public void FadeLeft()
    {
        direction = "fadeLeft";
    }

    public void FadeRight()
    {
        direction = "fadeRight";
    }

    public void AppearLeft()
    {
        direction = "appearLeft";
        GetComponent<RectTransform>().localPosition = new Vector3(-700, 65, 0);
        GetComponent<Image>().color = new Color(1, 1, 1, 0);
        if (UI_Manager.GetComponent<Buttons>().shipPreview == PlayerPrefs.GetString("ship"))
        {
            checkmark.enabled = true;
            GetComponent<Button>().interactable = false;
        }
        else
        {
            checkmark.enabled = false;
        }
        ShipPreviewSprite();
    }

    public void AppearRight()
    {
        direction = "appearRight";
        GetComponent<RectTransform>().localPosition = new Vector3(700, 65, 0);
        GetComponent<Image>().color = new Color(1, 1, 1, 0);
        if (UI_Manager.GetComponent<Buttons>().shipPreview == PlayerPrefs.GetString("ship"))
        {
            checkmark.enabled = true;
            GetComponent<Button>().interactable = false;
        }
        else
        {
            checkmark.enabled = false;
        }
        ShipPreviewSprite();
    }

    void ShipPreviewSprite()
    {
        switch (UI_Manager.GetComponent<Buttons>().shipPreview)
        {
            case "default":
                GetComponent<Image>().sprite = defaultPreview;
                if (!checkmark.enabled)
                {
                    GetComponent<Button>().interactable = true;
                }
                unlockText.text = "";
                break;
            case "pink":
                if (saveManager.GetComponent<SaveManager>().easyMode != "unbeaten")
                {
                    GetComponent<Image>().sprite = pinkPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat Easy Mode";
                    GetComponent<Button>().interactable = false;
                }
                break;
            case "green":
                if (saveManager.GetComponent<SaveManager>().easyMode != "unbeaten" && saveManager.GetComponent<SaveManager>().easyMode != "beaten")
                {
                    GetComponent<Image>().sprite = greenPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat Easy Mode Without Using Continues";
                }
                break;
            case "blue":
                if (saveManager.GetComponent<SaveManager>().easyMode == "noLives")
                {
                    GetComponent<Image>().sprite = bluePreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat Easy Mode Without Dying";
                }
                break;
            case "monochrome":
                if (saveManager.GetComponent<SaveManager>().normalMode != "unbeaten")
                {
                    GetComponent<Image>().sprite = monochromePreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat Normal Mode";
                }
                break;
            case "red":
                if (saveManager.GetComponent<SaveManager>().normalMode != "unbeaten" && saveManager.GetComponent<SaveManager>().normalMode != "beaten")
                {
                    GetComponent<Image>().sprite = redPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat Normal Mode Without Using Continues";
                }
                break;
            case "doppelganger":
                if (saveManager.GetComponent<SaveManager>().normalMode == "noLives")
                {
                    GetComponent<Image>().sprite = doppelgangerPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat Normal Mode Without Dying";
                }
                break;
            case "flame":
                if (saveManager.GetComponent<SaveManager>().hardMode != "unbeaten")
                {
                    GetComponent<Image>().sprite = flamePreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat Hard Mode";
                }
                break;
            case "rainbow":
                if (saveManager.GetComponent<SaveManager>().hardMode != "unbeaten" && saveManager.GetComponent<SaveManager>().hardMode != "beaten")
                {
                    GetComponent<Image>().sprite = rainbowPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat Hard Mode Without Using Continues";
                }
                break;
            case "glitch":
                if (saveManager.GetComponent<SaveManager>().hardMode == "noLives")
                {
                    GetComponent<Image>().sprite = glitchPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat Hard Mode Without Dying";
                }
                break;
            case "weapon":
                if (saveManager.GetComponent<SaveManager>().weaponChallenges == 6)
                {
                    GetComponent<Image>().sprite = weaponPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat All Weapon Challenges";
                }
                break;
            case "enemy":
                if (saveManager.GetComponent<SaveManager>().enemyChallenges == 6)
                {
                    GetComponent<Image>().sprite = enemyPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat All Enemy Challenges";
                }
                break;
            case "upsideDown":
                if (saveManager.GetComponent<SaveManager>().otherChallenges == 6)
                {
                    GetComponent<Image>().sprite = upsideDownPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "Beat All Other Challenges";
                }
                break;
            case "gold":
                if (saveManager.GetComponent<SaveManager>().easyMode == "noLives" &&
                    saveManager.GetComponent<SaveManager>().normalMode == "noLives" &&
                    saveManager.GetComponent<SaveManager>().hardMode == "noLives" &&
                    saveManager.GetComponent<SaveManager>().weaponChallenges == 6 &&
                    saveManager.GetComponent<SaveManager>().enemyChallenges == 6 &&
                    saveManager.GetComponent<SaveManager>().otherChallenges == 6)
                {
                    GetComponent<Image>().sprite = goldPreview;
                    if (!checkmark.enabled)
                    {
                        GetComponent<Button>().interactable = true;
                    }
                    unlockText.text = "";
                }
                else
                {
                    unlockText.text = "100% The Game";
                    GetComponent<Button>().interactable = false;
                }
                break;
        }
    }

    public void ShipSelect()
    {
        PlayerPrefs.SetString("ship", UI_Manager.GetComponent<Buttons>().shipPreview);
        checkmark.enabled = true;
        GetComponent<Button>().interactable = false;
    }
}
