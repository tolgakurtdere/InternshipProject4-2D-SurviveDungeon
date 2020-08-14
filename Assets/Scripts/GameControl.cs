using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("EnemyTag").Length == 0 && !PlayerControl.isOver)
        {
            StartCoroutine(GoNext());
        }
    }

    IEnumerator GoNext()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
