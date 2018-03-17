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
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.jump.ToString();
            else if (sliderContent.GetChild(i).name == "Left Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.left.ToString();
            else if (sliderContent.GetChild(i).name == "Right Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.right.ToString();
            else if (sliderContent.GetChild(i).name == "Shield Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.shield.ToString();
            else if (sliderContent.GetChild(i).name == "Interact Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.interact.ToString();
            else if (sliderContent.GetChild(i).name == "Attack Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.attack.ToString();
            else if (sliderContent.GetChild(i).name == "Rift Power 1 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.rift1.ToString();
            else if (sliderContent.GetChild(i).name == "Rift Power 2 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.rift2.ToString();
            else if (sliderContent.GetChild(i).name == "Rift Power 3 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.rift3.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 1 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.weapon1.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 2 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.weapon2.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 3 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.weapon3.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 4 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.weapon4.ToString();
            else if (sliderContent.GetChild(i).name == "Weapon 5 Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.weapon5.ToString();
            else if (sliderContent.GetChild(i).name == "Pause Button")
                sliderContent.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.pause.ToString();
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
                InputManager.IM.jump = newKey;
                buttonText.text = InputManager.IM.jump.ToString();
                PlayerPrefs.SetString("jumpKey", InputManager.IM.jump.ToString());
                break;
            case "left":
                InputManager.IM.left = newKey;
                buttonText.text = InputManager.IM.left.ToString();
                PlayerPrefs.SetString("leftKey", InputManager.IM.left.ToString());
                break;
            case "right":
                InputManager.IM.right = newKey;
                buttonText.text = InputManager.IM.right.ToString();
                PlayerPrefs.SetString("rightKey", InputManager.IM.right.ToString());
                break;
            case "shield":
                InputManager.IM.shield = newKey;
                buttonText.text = InputManager.IM.shield.ToString();
                PlayerPrefs.SetString("shieldKey", InputManager.IM.shield.ToString());
                break;
            case "interact":
                InputManager.IM.interact = newKey;
                buttonText.text = InputManager.IM.interact.ToString();
                PlayerPrefs.SetString("interactKey", InputManager.IM.interact.ToString());
                break;
            case "attack":
                InputManager.IM.attack = newKey;
                buttonText.text = InputManager.IM.attack.ToString();
                PlayerPrefs.SetString("attackKey", InputManager.IM.attack.ToString());
                break;
            case "rift1":
                InputManager.IM.rift1 = newKey;
                buttonText.text = InputManager.IM.rift1.ToString();
                PlayerPrefs.SetString("rift1Key", InputManager.IM.rift1.ToString());
                break;
            case "rift2":
                InputManager.IM.rift2 = newKey;
                buttonText.text = InputManager.IM.rift2.ToString();
                PlayerPrefs.SetString("rift2Key", InputManager.IM.rift2.ToString());
                break;
            case "rift3":
                InputManager.IM.rift3 = newKey;
                buttonText.text = InputManager.IM.rift3.ToString();
                PlayerPrefs.SetString("rift3Key", InputManager.IM.rift3.ToString());
                break;
            case "weapon1":
                InputManager.IM.weapon1 = newKey;
                buttonText.text = InputManager.IM.weapon1.ToString();
                PlayerPrefs.SetString("weapon1Key", InputManager.IM.weapon1.ToString());
                break;
            case "weapon2":
                InputManager.IM.weapon2 = newKey;
                buttonText.text = InputManager.IM.weapon2.ToString();
                PlayerPrefs.SetString("weapon2Key", InputManager.IM.weapon2.ToString());
                break;
            case "weapon3":
                InputManager.IM.weapon3 = newKey;
                buttonText.text = InputManager.IM.weapon3.ToString();
                PlayerPrefs.SetString("weapon3Key", InputManager.IM.weapon3.ToString());
                break;
            case "weapon4":
                InputManager.IM.weapon4 = newKey;
                buttonText.text = InputManager.IM.weapon4.ToString();
                PlayerPrefs.SetString("weapon4Key", InputManager.IM.weapon4.ToString());
                break;
            case "weapon5":
                InputManager.IM.weapon5 = newKey;
                buttonText.text = InputManager.IM.weapon5.ToString();
                PlayerPrefs.SetString("weapon5Key", InputManager.IM.weapon5.ToString());
                break;
            case "pause":
                InputManager.IM.pause = newKey;
                buttonText.text = InputManager.IM.pause.ToString();
                PlayerPrefs.SetString("pauseKey", InputManager.IM.pause.ToString());
                break;

        }

        yield return null;
    }
}
