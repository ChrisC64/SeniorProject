using UnityEngine;
using System.Collections;

public class LoadingLevelCave : MonoBehaviour
{
    public GUIText loadingText;
    private float timer  = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
     {
         if (col.gameObject.tag == "Player")
             {
                 loadingText.SendMessage("showMessage", "loading next level");
                 Application.LoadLevel("Level 2 Cave");
                 Debug.Log("level 2 loaded");
             }
         }
}
