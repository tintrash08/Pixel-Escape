using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject tapToStartText;
    public TextMeshProUGUI scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void modifyActiveStatusOfElements(GameObject gameObject, bool status)
    {
        gameObject.SetActive(status);
    }

    public void increaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
