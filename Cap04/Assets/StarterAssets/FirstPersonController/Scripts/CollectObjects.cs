using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class CollectObjects : MonoBehaviour
{
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "pick_me")
        {
            float posX = hit.transform.position.x;
            print("colision con " +hit.gameObject.name+ " poscision X: " +posX);
            string label = hit.collider.gameObject.tag;
            print("Collision with" + label);
            score = score + 1;
            if (score >= 4) SceneManager.LoadScene("level2");
            print("score: " + score);
            Destroy(hit.collider.gameObject);
            
        }
        
    }
}
