using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public void OnClickStart() {
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
    }

    public void OnClickHowToPlay() {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Additive);
    }

    public void OnClickCredits() {
        SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
    }
}
