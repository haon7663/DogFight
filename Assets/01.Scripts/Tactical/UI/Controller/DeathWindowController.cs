using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWindowController : MonoBehaviour
{
    public DeathWindow deathWindow;

    public void Show()
    {
        deathWindow.gameObject.SetActive(true);
        deathWindow.Show();
    }
}
