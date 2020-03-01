using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject character;
    public GameObject console;

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

        if (Input.GetKeyDown(KeyCode.F1))
        {
            console.SetActive(!console.activeSelf);

            PlayerController pc = FindObjectOfType<PlayerController>();

            if (pc != null)
            {
                pc.SetPaused(console.activeSelf);
            }
        }
    }
}
