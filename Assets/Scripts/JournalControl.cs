using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gamecanvas;
    public GameObject JournalCanvas;
    public Canvas Canvas;
    public void OnlineJournal()
    {
        gamecanvas.SetActive(false);
        JournalCanvas.SetActive(true);
    }
    public void OfflineJournal()
    {

    }
    public void NoJournal()
    {
        SC_GroundGenerator.instance.Pickup = false;
    }
    public void submitjournalbutton()
    {
        SC_GroundGenerator.instance.Pickup = false;
        JournalCanvas.SetActive(false);
    }
}
