using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public void makeSound()
    {
        FindObjectOfType<AudioManager>().Play("Menu");
    }
}
