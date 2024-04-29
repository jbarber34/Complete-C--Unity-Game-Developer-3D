using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryHandler : MonoBehaviour
{
    [SerializeField] Canvas victoryCanvas;

    private void Start()
    {
        victoryCanvas.enabled = false;
    }

    public void HandleVictory()
    {
        victoryCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
