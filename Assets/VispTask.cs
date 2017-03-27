using UnityEngine;
using System.Runtime.InteropServices;

public class VispTask : MonoBehaviour {

    // Import DLL (text-point-projection.dll)
    [DllImport("test-point-projection", CallingConvention = CallingConvention.Cdecl, EntryPoint = "getXY")]
    // Imported function getXY
    public static extern void getXY(double x, double y, double z, double[] XY_2D);

    // Init string of 3D coordinates
    private string coords = "0,-0.05,0.01";

    // Array for storing projected coordinates
    private double[] XY_2d = new double[2];

    // Takes care of changes happening on GUI
    void OnGUI()
    {
        // Defining GUI text box
        coords = GUI.TextField(new Rect(10, 10, 200, 20), coords, 25);
        
        // Defining GUI Button if(Clicked) -> Calculate the 2D projection
        if (GUI.Button(new Rect(300, 145, 200, 50), "Calculate 2D points"))
        {

            // Split string of coordinates and convert to double 
            string[] str = coords.Split(',');
            double[] XYZ = new double[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                XYZ[i] = double.Parse(str[i]);
            }
            double x = XYZ[0];
            double y = XYZ[1];
            double z = XYZ[2];

            // Function to calculate 2d projection. Projected coordinates stored in XY_2d
            getXY(x, y, z, XY_2d);

            //Print statements, check console for output
            Debug.Log(coords);
            Debug.Log("2D_X value");
            Debug.Log(XY_2d[0]);
            Debug.Log("2D_Y value");
            Debug.Log(XY_2d[1]);
        }

    }
    // Use this for initialization
    void Start () {
        Debug.Log("Enter the 3D coordinates seperated by white spaces");
    }
    // Updates every frame
    void Update () {
    }
}
