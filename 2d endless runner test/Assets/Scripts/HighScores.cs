using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScores : MonoBehaviour {

    public static HighScores instance;

    const string privateCode = "kDpZaglugkCJ3BdThvv6Lwkn6r6fCxbkugvuEWEHSE0g";
    const string publicCode = "5e66e77bfe232612b898fa9e";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;

    void Awake() {
        instance = this;
    }

    public static void AddNewHighscore(string username, int score) {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    //trocado WWW por UnityWebRequest

    IEnumerator UploadNewHighscore(string username, int score) {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error)) {
            print("Upload Successfull");
            DownloadHighscores();
        } else {
            print("Error uploading" + www.error);
        }
    }

    public void DownloadHighscores() {
        StartCoroutine("DownloadHighscoresFromDatase");
    }

    IEnumerator DownloadHighscoresFromDatase() {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error)) {
            FormatHighscores(www.text);
            DisplayHighscores.instance.OnHighscoresDownloaded(highscoresList);
        } else {
            print("Error Downloading" + www.error);
        }
    }

    void FormatHighscores(string textStream) {
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++) {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }
}

public struct Highscore {
    public string username;
    public int score;

    public Highscore(string _username, int _score) {
        username = _username;
        score = _score;
    }
}
