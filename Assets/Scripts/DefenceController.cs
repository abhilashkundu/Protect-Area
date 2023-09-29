using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceController : MonoBehaviour
{
    public GameObject myself;

    public void OnMouseDown()
    {
        print("DefenceCalled");
        myself.SendMessage("ActiveTurrent");
    }
}
