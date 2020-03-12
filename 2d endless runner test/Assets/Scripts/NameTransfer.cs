using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour {

    public static NameTransfer instance;

    public string theName;
    public GameObject inputField;
    public InputField InputField;
    private TouchScreenKeyboard mobileKeys;

    private void Awake() {
        instance = this;
    }

    void Start() {
        mobileKeys = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

        mobileKeys.active = false;
    }

    void OnGUI() {
        if (InputField.isFocused && InputField.text != "" && Input.GetKey(KeyCode.Return)) {
            theName = inputField.GetComponent<Text>().text;
            Debug.Log(theName);
            InputField.text = "";
            int theScore = (int)ScoreManager.instance.scoreCount;
            HighScores.AddNewHighscore(theName, theScore);
        }

        if (mobileKeys != null && mobileKeys.status == TouchScreenKeyboard.Status.Done) {
            theName = inputField.GetComponent<Text>().text;
            InputField.text = "";
            int theScore = (int)ScoreManager.instance.scoreCount;
            HighScores.AddNewHighscore(theName, theScore);

        }
    }
}
