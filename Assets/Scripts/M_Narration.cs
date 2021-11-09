using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class M_Narration : MonoBehaviour
{
    public NarrationScriptable NarrationInput;
    public List<NarrationScriptable> left = new List<NarrationScriptable>();
    public List<NarrationScriptable> Right = new List<NarrationScriptable>();
    public int MaxJournalCount;
    public Transform gamecanvas;
    public Canvas canvas;   
    public GameObject Onlinejournal;
    public GameObject OfflineJournal;
    public GameObject NoJournal;
    public GameObject LBG;
    public GameObject RBG;
    [HideInInspector]
    int currentjournalindex = 0;
    public bool journaldone = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintonlyandWait());
    }

    public void canvasoff()
    {
        gamecanvas.gameObject.SetActive(false);
    }

    public void clearstarttext()
    {
        canvas.GetComponentInChildren<TextMeshProUGUI>().SetText(""); 
    }
    private IEnumerator PrintonlyandWait()
    {
        gamecanvas.gameObject.SetActive(true);
        Onlinejournal.SetActive(false);
        OfflineJournal.SetActive(false);
        NoJournal.SetActive(false);
        canvas.GetComponentInChildren<TextMeshProUGUI>().SetText(NarrationInput.NarrationText);
        yield return new WaitForSeconds(5);
        canvas.GetComponentInChildren<TextMeshProUGUI>().SetText("");
        gamecanvas.gameObject.SetActive(false);
    }

    public void PickupPrint()
    {
        if(currentjournalindex < MaxJournalCount)
        {
        FindObjectOfType<SC_IRPlayer>().controlsactive = false;
        currentjournalindex++;
        Debug.Log(currentjournalindex);
        gamecanvas.gameObject.SetActive(true);
        Onlinejournal.SetActive(true);
        OfflineJournal.SetActive(true);
        NoJournal.SetActive(true);
        foreach (Transform myCanvas in gamecanvas)
        {
            if (myCanvas.GetComponent<TextMeshProUGUI>().tag == "L_Narration" && currentjournalindex <= MaxJournalCount)
            {
                myCanvas.GetComponent<TextMeshProUGUI>().SetText(left[currentjournalindex-1].NarrationText);
                LBG.SetActive(true);
                if (currentjournalindex == MaxJournalCount)
                    { endjournals(); }
            }
            if (myCanvas.GetComponent<TextMeshProUGUI>().tag == "R_Narration" && currentjournalindex <= MaxJournalCount)
            {
                myCanvas.GetComponent<TextMeshProUGUI>().SetText(Right[currentjournalindex-1].NarrationText);
                RBG.SetActive(true);
                if (currentjournalindex == MaxJournalCount)
                    { endjournals(); }
                }
        }
        }
       
    }

    private void endjournals()
    {
        Debug.Log("Delete Journal Started");
        FindObjectOfType<SC_PlatformTile>().JournalDone = true;
        journaldone = true;
        Journal[] Journals = FindObjectsOfType<Journal>();
        foreach (Journal journal in Journals)
        {
            Destroy(journal.gameObject);
        }
    }
    
}
