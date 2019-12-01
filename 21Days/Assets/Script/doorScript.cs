using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class doorScript : MonoBehaviour
{
    public Text doorText;
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
        if ((days%7) == 0)
        {
            doorText.text = "Click to go outside!";
        }
        else
        {
            doorText.text = "Not ready to go out yet\nCheck the weather!";
        }
    }

    public void PointerExit()
    {
        doorText.text = "";
    }

    public void PointerClick()
    {
        if ((days%7) == 0)
        {
            doorText.text = "Click to go outside!";
            SceneManager.LoadScene("Outside");
        }

    }
}
