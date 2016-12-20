using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Ending : MonoBehaviour
{
    private string scene = "Title";
    public GameObject endingScreen;

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(10.0F);
        SceneManager.LoadScene(scene);
    }

    void OnCollisionEnter(Collision other)
    {
        ending();
    }
    public void ending()
    {
        endingScreen.SetActive(true);
        StartCoroutine(Pause());
    }
}
