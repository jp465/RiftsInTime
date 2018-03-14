using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputController : MonoBehaviour {
    public Transform sliderContent;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;
    bool waitingForKeyPress;

	void Start () {
        waitingForKeyPress = false;

        for(int i = 0; i<15; i++)
        {
            if (sliderContent.GetChild(i).name == "Jump Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.jump.ToString();
            else if (sliderContent.GetChild(i).name == "Left Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.left.ToString();
            else if (sliderContent.GetChild(i).name == "Right Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.right.ToString();
            else if (sliderContent.GetChild(i).name == "Shield Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.shield.ToString();
            else if (sliderContent.GetChild(i).name == "Interact Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.interact.ToString();
            else if (sliderContent.GetChild(i).name == "Attack Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.attack.ToString();
            else if (sliderContent.GetChild(i).name == "Rift Power 1 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.rift1.ToString();
            else if (sliderContent.GetChild(i).name == "Rift Power 2 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.rift2.ToString();
            else if (sliderContent.GetChild(i).name == "Rift Power 3 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.rift3.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 1 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.weapon1.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 2 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.weapon2.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 3 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.weapon3.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 4 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.weapon4.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 5 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.weapon5.ToString();
            else if (sliderContent.GetChild(i).name == "Pause Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = LevelManager.LM.pause.ToString();
        }
	}

    private void OnGUI()
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKeyPress)
        {
            newKey = keyEvent.keyCode;
            waitingForKeyPress = false;
        }
    }

    public void StartKeyAssignment(string keyName)
    {
        if (!waitingForKeyPress)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKeyPress()
    {
        while(!keyEvent.isKey)
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKeyPress = true;
        yield return WaitForKeyPress();

        switch (keyName)
        {
            case "jump":
                LevelManager.LM.jump = newKey;
                buttonText.text = LevelManager.LM.jump.ToString();
                PlayerPrefs.SetString("jumpKey", LevelManager.LM.jump.ToString());
                break;
            case "left":
                LevelManager.LM.left = newKey;
                buttonText.text = LevelManager.LM.left.ToString();
                PlayerPrefs.SetString("leftKey", LevelManager.LM.left.ToString());
                break;
            case "right":
                LevelManager.LM.right = newKey;
                buttonText.text = LevelManager.LM.right.ToString();
                PlayerPrefs.SetString("rightKey", LevelManager.LM.right.ToString());
                break;
            case "shield":
                LevelManager.LM.shield = newKey;
                buttonText.text = LevelManager.LM.shield.ToString();
                PlayerPrefs.SetString("shieldKey", LevelManager.LM.shield.ToString());
                break;
            case "interact":
                LevelManager.LM.interact = newKey;
                buttonText.text = LevelManager.LM.interact.ToString();
                PlayerPrefs.SetString("interactKey", LevelManager.LM.interact.ToString());
                break;
            case "attack":
                LevelManager.LM.attack = newKey;
                buttonText.text = LevelManager.LM.attack.ToString();
                PlayerPrefs.SetString("attackKey", LevelManager.LM.attack.ToString());
                break;
            case "rift1":
                LevelManager.LM.rift1 = newKey;
                buttonText.text = LevelManager.LM.rift1.ToString();
                PlayerPrefs.SetString("rift1Key", LevelManager.LM.rift1.ToString());
                break;
            case "rift2":
                LevelManager.LM.rift2 = newKey;
                buttonText.text = LevelManager.LM.rift2.ToString();
                PlayerPrefs.SetString("rift2Key", LevelManager.LM.rift2.ToString());
                break;
            case "rift3":
                LevelManager.LM.rift3 = newKey;
                buttonText.text = LevelManager.LM.rift3.ToString();
                PlayerPrefs.SetString("rift3Key", LevelManager.LM.rift3.ToString());
                break;
            case "weapon1":
                LevelManager.LM.weapon1 = newKey;
                buttonText.text = LevelManager.LM.weapon1.ToString();
                PlayerPrefs.SetString("weapon1Key", LevelManager.LM.weapon1.ToString());
                break;
            case "weapon2":
                LevelManager.LM.weapon2 = newKey;
                buttonText.text = LevelManager.LM.weapon2.ToString();
                PlayerPrefs.SetString("weapon2Key", LevelManager.LM.weapon2.ToString());
                break;
            case "weapon3":
                LevelManager.LM.weapon3 = newKey;
                buttonText.text = LevelManager.LM.weapon3.ToString();
                PlayerPrefs.SetString("weapon3Key", LevelManager.LM.weapon3.ToString());
                break;
            case "weapon4":
                LevelManager.LM.weapon4 = newKey;
                buttonText.text = LevelManager.LM.weapon4.ToString();
                PlayerPrefs.SetString("weapon4Key", LevelManager.LM.weapon4.ToString());
                break;
            case "weapon5":
                LevelManager.LM.weapon5 = newKey;
                buttonText.text = LevelManager.LM.weapon5.ToString();
                PlayerPrefs.SetString("weapon5Key", LevelManager.LM.weapon5.ToString());
                break;
            case "pause":
                LevelManager.LM.pause = newKey;
                buttonText.text = LevelManager.LM.pause.ToString();
                PlayerPrefs.SetString("pauseKey", LevelManager.LM.pause.ToString());
                break;

        }

        yield return null;
    }
}
