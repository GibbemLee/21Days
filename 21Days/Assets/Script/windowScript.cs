using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class windowScript : MonoBehaviour
{
    public Text windowText;
    public static int days = 7;

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
        windowText.text = "Click here to check the weather!";
    }

    public void PointerExit()
    {
        windowText.text = "";
    }

    public void PointerClick()
    {
        if ((days%7) == 0)
        {
            SceneManager.LoadScene("Window_dry");
        }
        else if ((days%7) < 7 && (days%7) >= 3)
        {
            SceneManager.LoadScene("Window_med");
        }
        else
        {
            SceneManager.LoadScene("Window_full");
        }
    }
}
