using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time;
    private TextMeshProUGUI timerText; // Guardamos la referencia aquí
    private TextMeshProUGUI messageText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 55.0f;
        //timerText = GameObject.Find("timerUI").GetComponent<TextMeshProUGUI>();
        //messageText = GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        int seconds = (int)(time % 60); // float a int y time = 0 cuando llega a 60, 1 cuando es 61, etc
        int minutes = (int)(time / 60);
        //timerText.text = minutes + ":" + seconds;

        if (time > 118)
        {
            //messageText.text = "Time Is Almost Up.";
        }
        if (time > 120)
        {
            print("TIME IS UP");
            SceneManager.LoadScene("maze");
        }
    }
}
