using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class M_Narration : MonoBehaviour
{
    public NarrationScriptable NarrationInput;
    public GameObject gamecanvas;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintandWait());
    }

    public void canvasoff()
    {
        gamecanvas.SetActive(false);
    }
    private IEnumerator PrintandWait()
    {
        gamecanvas.SetActive(true);
        canvas.GetComponentInChildren<TextMeshProUGUI>().SetText(NarrationInput.NarrationText);
        yield return new WaitForSeconds(5);
        gamecanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
