using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadNextScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
