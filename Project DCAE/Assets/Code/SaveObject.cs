using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{

    // coordinates
    public float x;
    public float y;
    //player pos
    private Transform player;

    private void Start()
    {
        player = GetComponent<Transform>();
        Load();
    }

    private void Update()
    {
        // Cor x and y. Print him.
        x = player.transform.position.x;
        y = player.transform.position.y;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("X", x);
        PlayerPrefs.SetFloat("Y",y);
        PlayerPrefs.Save(); 
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey("X"))
        {
            x = PlayerPrefs.GetFloat("X");
        }
        else if(PlayerPrefs.HasKey("Y"))
        {
            y = PlayerPrefs.GetFloat("Y");
        }
        player.transform.position = new Vector2(x,y);
    }
}
