using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [HideInInspector]
    int currentjournalindex = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintonlyandWait());
    }

    public void canvasoff()
    {
        gamecanvas.gameObject.SetActive(false);
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
        gamecanvas.gameObject.SetActive(true);
        Onlinejournal.SetActive(true);
        OfflineJournal.SetActive(true);
        NoJournal.SetActive(true);
        foreach (Transform myCanvas in gamecanvas)
        {
            if (myCanvas.GetComponentInChildren<TextMeshProUGUI>().tag == "L_Narration" && currentjournalindex < MaxJournalCount)
            {
                myCanvas.GetComponentInChildren<TextMeshProUGUI>().SetText(left[currentjournalindex].NarrationText);
            }
            if (myCanvas.GetComponentInChildren<TextMeshProUGUI>().tag == "R_Narration" && currentjournalindex < MaxJournalCount)
            {
                myCanvas.GetComponentInChildren<TextMeshProUGUI>().SetText(Right[currentjournalindex].NarrationText);
            }
        }
        if (currentjournalindex < MaxJournalCount)
        {
            currentjournalindex++;
        }
    }
    
}
