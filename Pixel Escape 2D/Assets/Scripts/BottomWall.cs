using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour
{

    public UIManager uiManager;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CommonConstants.blockTag)
        {
            uiManager.increaseScore();
            Destroy(collision.gameObject);
        }
    }
}
