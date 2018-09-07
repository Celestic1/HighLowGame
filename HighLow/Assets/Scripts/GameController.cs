using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // restarts the game
    void Update()
    {
        if (Input.GetKeyDown("z"))
            {
                // reload the scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
    }
}
