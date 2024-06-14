using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour, Iinventory
{
    public int Item { get => item; set => item = value; }

    public int item = 0;

    public int Item2 { get => item2; set => item2 = value; }

    public int item2 = 0;

    public int Item3 { get => item3; set => item3 = value; }

    public int item3 = 0;

    public int Prizee { get => prizee; set => prizee = value; }

    public int prizee = 0;
    public bool Sword{get => sword; set => sword = true;}
    public bool sword = false;

}
