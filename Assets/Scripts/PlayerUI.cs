using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("Screens")]
    public GameObject character;

    [Header("Character Screens")]
    public GameObject inventory;
    public GameObject stats;
    public GameObject news;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            character.SetActive(!character.activeSelf);

            PlayerController pc = FindObjectOfType<PlayerController>();

            if(pc != null)
            {
                pc.SetPaused(character.activeSelf);
            }
        }
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
        stats.SetActive(false);
        news.SetActive(false);
    }

    public void OpenStats()
    {
        inventory.SetActive(false);
        stats.SetActive(true);
        news.SetActive(false);
    }

    public void OpenNews()
    {
        inventory.SetActive(false);
        stats.SetActive(false);
        news.SetActive(true);
    }
}
