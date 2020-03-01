using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Console : MonoBehaviour
{
    [SerializeField] private TMP_InputField commandField;
    [SerializeField] private Transform contentHolder;
    [SerializeField] private GameObject commandItem;

    private bool isLoggedIn;

    public void ExecuteCommand()
    {
        if(commandField.text != "")
        {
            if(commandField.text == "!login 8231o" && isLoggedIn == false)
            {
                isLoggedIn = true;

                CreateOutput("Logged in as Game Admin!");

            }
            else if(commandField.text == "!login 8231o" && isLoggedIn == true)
            {
                CreateOutput("Already logged in!");
            }
            else if(commandField.text == "!login" && isLoggedIn == true)
            {
                CreateOutput("Already logged in!");
            }
            else if(commandField.text == "!login" && isLoggedIn == false)
            {
                CreateOutput("Please enter access code!");
            }
            else if(isLoggedIn != false && commandField.text == "!Player <name> SetWallet <number>")
            {
                CreateOutput("Command unavailable");
            }
            else if (!isLoggedIn)
            {
                GameObject temp = Instantiate(commandItem, contentHolder);

                temp.GetComponent<TMP_Text>().text = "Please log in to run commands!";
            }
            else
            {
                GameObject temp = Instantiate(commandItem, contentHolder);

                temp.GetComponent<TMP_Text>().text = "Error command not found!";
            }
        }
    }

    private void CreateOutput(string output)
    {
        GameObject temp = Instantiate(commandItem, contentHolder);

        temp.GetComponent<TMP_Text>().text = output;
    }
}
