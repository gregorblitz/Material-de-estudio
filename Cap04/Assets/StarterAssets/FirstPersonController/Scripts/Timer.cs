using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time;
    private TextMeshProUGUI timerText; // VARIABLE CLASE TextMeshProUGUI PARA ALMACENAR TIEMPO
    private TextMeshProUGUI messageText; // VARIABLE CLASE TextMeshProUGUI PARA ALMACENAR TEXTO
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 55.0f;
        // Busca el GameObject en la escena por su nombre y lo guarda en una variable secundaria
        GameObject timerGo = GameObject.Find("timerUI");
        if (timerGo!= null)
        {
            // Obtiene el componente TextMeshProUGUI y se almacena en la variable principal
            timerText = timerGo.GetComponent<TextMeshProUGUI>();
            
            // Modifica propiedad .text
            timerText.text = string.Empty; // string.Empty es mas limpio y eficiente que ""
        }
        else
        {
            Debug.LogError("No se encontro el GameObject llamado 'timerUI'. Verifique nombre");
        }

        // Repite el mismo proceso seguro para el mensaje del usuario
        GameObject messageGo = GameObject.Find("userMessageUI");
        if (messageGo!= null)
        {
            messageText = messageGo.GetComponent<TextMeshProUGUI>();
            messageText.text = string.Empty;
        }
        else
        {
            Debug.LogError("No se encontro el GameObject llamado 'userMessageUI'. Verifique nombre");
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; // Forma más limpia de sumar el tiempo
        
        int seconds = (int)(time % 60); //float a int y se reinicia cuando llega a 60 debido a %
        int minutes = (int)(time / 60);

        // PROTEGE CONTRA NULOS Y FORMATO DE TEXTO
        if (timerText != null)
        {
            // Usar ToString("00") asegura que siempre haya dos dígitos (ej. 01:05)
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        if (time > 118)
        {
            // PROTEGE CONTRA NULOS
            if (messageText != null)
            {
                messageText.text = "Time Is Almost Up.";
            }
        }
        
        if (time > 120)
        {
            //print("TIME UP");
            SceneManager.LoadScene("maze");
        }
    }
}
