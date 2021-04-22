using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    /// <summary>
    /// This script allows for players to change characters during their gameplay.
    /// Keycode 1: Naruto, Keycode 2: Sakura, Keycode 3: Sasuke
    /// </summary>
    public AnimatorOverrideController narutoAnim, sakuraAnim, sasukeAnim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Naruto();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Sakura();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Sasuke();
        }
    }
    
    void Naruto()
    {
        // Replace narutoAnim as the runtime animator controller
        GetComponent<Animator>().runtimeAnimatorController = narutoAnim as RuntimeAnimatorController;
    }

    void Sakura()
    {
        // Replace sakuraAnim as the runtime animator controller
        GetComponent<Animator>().runtimeAnimatorController = sakuraAnim as RuntimeAnimatorController;
    }

    void Sasuke()
    {
        // Replace sasukeAnim as the runtime animator controller
        GetComponent<Animator>().runtimeAnimatorController = sasukeAnim as RuntimeAnimatorController;
    }
}
