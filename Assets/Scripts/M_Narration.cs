using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class M_Narration : MonoBehaviour
{
    public NarrationScriptable NarrationInput;
    public NarrationScriptable FirstPickupInput;
    public GameObject gamecanvas;
    public Canvas canvas;
    public GameObject Onlinejournal;
    public GameObject OfflineJournal;
    public GameObject NoJournal;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintonlyandWait());
    }

    public void canvasoff()
    {
        gamecanvas.SetActive(false);
    }
    private IEnumerator PrintonlyandWait()
    {
        gamecanvas.SetActive(true);
        Onlinejournal.SetActive(false);
        OfflineJournal.SetActive(false);
        NoJournal.SetActive(false);
        canvas.GetComponentInChildren<TextMeshProUGUI>().SetText(NarrationInput.NarrationText);
        yield return new WaitForSeconds(5);
        gamecanvas.SetActive(false);
    }

    public void PickupPrint()
    {
        gamecanvas.SetActive(true);
        Onlinejournal.SetActive(true);
        OfflineJournal.SetActive(true);
        NoJournal.SetActive(true);
        canvas.GetComponentInChildren<TextMeshProUGUI>().SetText(FirstPickupInput.NarrationText);
    }
    
}
