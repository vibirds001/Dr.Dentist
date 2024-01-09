using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void GoToUrl()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=Pf8CeGa7tII&list=PLdphSQ97DFonCPSAtg4kwdsCKatLsepMj&index=1");
    }
}
