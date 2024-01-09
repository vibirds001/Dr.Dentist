using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loop : MonoBehaviour
{

    void changeNext()
    {
        if (Time.timeSinceLevelLoad > 2.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        changeNext();
    }

}