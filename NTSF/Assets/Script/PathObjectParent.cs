using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathObjectParent : MonoBehaviour
{
    public PathPoint[] ComunPathPoints;
    public PathPoint[] RedPathPoints;
    public PathPoint[] BluePathPoints;
    public PathPoint[] GreenPathPoints;
    public PathPoint[] YellowPathPoints;
    public PathPoint[] BazaPoints;


    [Header("Scale and Position diference")]
    public float[] scale;
    public float[] positionDiference; 
}
