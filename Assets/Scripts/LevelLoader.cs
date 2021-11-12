using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int indexNumber;

    void Start()
    {
        indexNumber = SceneManager.GetActiveScene().buildIndex;
        indexNumber += 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            StartCoroutine ("ChangeLevelCo");
        }
    }

    IEnumerator ChangeLevelCo()
    {
        FindObjectOfType<SceneTransition>().Transition();
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(indexNumber);
        //DestroyObject(checkpointManager.gameObject);
        print("Manager deleted");

    }


}
