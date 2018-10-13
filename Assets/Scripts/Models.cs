using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Place {
    public int id;
    public string title;
    public double latitude;
    public double longitude;
}

[Serializable]
public class PlaceList
{
    public Place[] places;
}