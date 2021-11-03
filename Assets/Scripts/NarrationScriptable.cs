using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName ="NarrationScript", menuName ="ScriptableObjects/NarrationScript")]
public class NarrationScriptable : ScriptableObject
{
    [TextArea]
    public string NarrationText;
}
