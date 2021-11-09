using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gamecanvas;
    public GameObject JournalCanvas;
    public Canvas Canvas;
    public GameObject OnlineJournalInputField;
    public GameObject OnlineJournalButton;
    public GameObject OfflineJournalPrompt;
    public GameObject OfflineJournalButton;
    public void OnlineJournal()
    {
        gamecanvas.SetActive(false);
        JournalCanvas.SetActive(true);
    }
    public void OfflineJournal()
    {
        gamecanvas.SetActive(false);
        JournalCanvas.SetActive(true);
        OnlineJournalInputField.SetActive(false);
        OnlineJournalButton.SetActive(false);
        OfflineJournalPrompt.SetActive(true);
        OfflineJournalButton.SetActive(true);
    }
    public void NoJournal()
    {
        FindObjectOfType<SC_IRPlayer>().controlsactive = true;
        SC_GroundGenerator.instance.Pickup = false;
        gamecanvas.SetActive(false);
    }
    public void submitjournalbutton()
    {
        FindObjectOfType<SC_IRPlayer>().controlsactive = true;
        SC_GroundGenerator.instance.Pickup = false;
        JournalCanvas.SetActive(false);
    }

    public void offlinejournalbutton()
    {
        FindObjectOfType<SC_IRPlayer>().controlsactive = true;
        OnlineJournalInputField.SetActive(true);
        OnlineJournalButton.SetActive(true);
        OfflineJournalPrompt.SetActive(false);
        OfflineJournalButton.SetActive(false);
        JournalCanvas.SetActive(false);
        SC_GroundGenerator.instance.Pickup = false;
    }
}
