using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inventoryScript : MonoBehaviour
{
    private AsyncOperation _SceneAsync;
    private GameObject menuCanvas;
    public Text inventoryText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter()
    {
        inventoryText.text = "Take things out of the\ninventory";
    }

    public void PointerExit()
    {
        inventoryText.text = "";
    }

    public void PointerClick()
    {
        StartCoroutine(loadScene("Inventory"));
    }

    IEnumerator loadScene(string SceneName)
    {
        AsyncOperation nScene = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        nScene.allowSceneActivation = false;
        _SceneAsync = nScene;

        while (nScene.progress < 0.9f)
        {
            Debug.Log("Loading scene " + " [][] Progress: " + nScene.progress);
            yield return null;
        }

        //Activate the Scene
        _SceneAsync.allowSceneActivation = true;

        while (!nScene.isDone)
        {
            // wait until it is really finished
            yield return null;
        }

        Scene nThisScene = SceneManager.GetSceneByName(SceneName);

        if (nThisScene.IsValid())
        {
            Debug.Log("Scene is Valid");
            //SceneManager.MoveGameObjectToScene(UIRootObject, nThisScene);
            SceneManager.SetActiveScene(nThisScene);

            menuCanvas = GameObject.Find("MenuCanvas");
            GameObject player = GameObject.Find("Main Camera");

            menuCanvas.transform.rotation = player.transform.rotation;
            menuCanvas.transform.position = player.transform.position + player.transform.forward * 5;

        }
        else
        {
            Debug.Log("Invalid scene!!");
        }
    }
}
