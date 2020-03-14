using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour {

    public static AdController instance;
    private readonly string video_id = "3505425";

    private void Awake() {
        instance = this;
    }

    void Start() {
        Advertisement.Initialize(video_id, false);
    }

    public void ShowAd() {
        if (Advertisement.IsReady()) {
            Advertisement.Show();
        }
    }
}