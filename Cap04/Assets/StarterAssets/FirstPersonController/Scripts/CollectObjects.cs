using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class CollectObjects : MonoBehaviour
{
    bool startDeleteMessage;
    float timer;
    private int score;
    private TextMeshProUGUI messageUI;
    private int petrolCansCollected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        startDeleteMessage = false;
        timer = 0.0f;
        petrolCansCollected = 0;
        /*GameObject messageAuxFind = GameObject.Find("userMessageUI");

        if (messageAuxFind!= null)
        {
            // Obtiene el componente TextMeshProUGUI y se almacena en la variable principal
            messageUI = messageAuxFind.GetComponent<TextMeshProUGUI>();
            
            // Modifica propiedad .text
            messageUI.text = string.Empty; // string.Empty es mas limpio y eficiente que ""
        }
        else
        {
            Debug.LogError("No se encontro el GameObject llamado 'messageUI'. Verifique nombre");
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        // Al chocar con la caja en el metodo OnControllerColliderHit se activa
        if (startDeleteMessage == true)
        {
            timer += Time.deltaTime;
            if (timer >= 2) //resetea el mensaje luego de 2 segundos
            {
                //GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "";
                timer = 0.0f;
                startDeleteMessage = false;
            }
        }

    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "pick_me" || hit.collider.gameObject.tag == "jerry_can")
        {
            float posX = hit.transform.position.x;
            print("colision con " + hit.gameObject.name + " poscision X: " + posX);
            string label = hit.collider.gameObject.tag;
            print("Collision with" + label);
            score = score + 1;

            startDeleteMessage = true; // Activa variable cuando choca con la caja para mostrar mensaje
            // Si puntuacion >4 y la escena activa es maze, entonces carga nivel 2, de lo contrario no
            if (score >= 4 && SceneManager.GetActiveScene().name == "maze") SceneManager.LoadScene("level2");
            print("score: " + score);
            if (hit.collider.gameObject.tag == "jerry_can")
            {
                petrolCansCollected++;
                print("Collected " + petrolCansCollected + "can(s)" );
            }
            Destroy(hit.collider.gameObject);
            if (messageUI != null)
            {
                // asigno el mensaje que necesito usando .text
                messageUI.text = "You collected " + score + " Boxe(s)!";
            }
        } 
    }
}
