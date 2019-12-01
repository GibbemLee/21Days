using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;

public class playerScript : MonoBehaviour
{
    public int playerSpeed;
    public static int days = 7;

    private int buttonStat = 0;
    private bool is_interact = false;
    private string[] interact_tags = new string[3] {"Door", "Window", "Inventory"};

    public GameObject WindowPane;
    public Texture[] windowScenes;

    public Text dayText;

    // Start is called before the first frame update
    void Start()
    {
        updateWindow();
        updateDayText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (buttonStat != 1)
            {
                buttonStat = 1;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits = Physics.RaycastAll(ray);

                foreach (RaycastHit hit in hits)
                {
                    if (interact_tags.Contains(hit.collider.gameObject.tag))
                    {
                        is_interact = true;
                        Debug.Log("hit");
                    }
                }

                if (!is_interact)
                {
                    Vector3 forwardDirection = Camera.main.transform.forward;
                    forwardDirection.y = 0;
                    transform.position = transform.position + forwardDirection * playerSpeed * Time.deltaTime;
                }
            }
            else
            {
                if (!is_interact)
                {
                    Vector3 forwardDirection = Camera.main.transform.forward;
                    forwardDirection.y = 0;
                    transform.position = transform.position + forwardDirection * playerSpeed * Time.deltaTime;
                }
            }
        }
        else
        {
            buttonStat = 0;
            is_interact = false;
        }

    }

    void updateWindow()
    {
        Renderer windowScene = WindowPane.GetComponent<Renderer>();

        if ((days%7) == 0)
        {
            windowScene.material.mainTexture = windowScenes[2];
        }
        else if ((days%7) < 7 && (days%7) >= 3)
        {
            windowScene.material.mainTexture = windowScenes[1];
        }
        else
        {
            windowScene.material.mainTexture = windowScenes[0];
        }
    }

    void updateDayText()
    {
        dayText.text = "Day " + days;
    }
}
