using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARanimations : MonoBehaviour
{
    
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;
    public GameObject Object7;
    public GameObject Object8;
    public GameObject Object9;
    public GameObject Object10;

    public void ActivateObject1(){
        Object1.SetActive(true);

        Invoke("DeactivateObject1", 5); 
    }

    private void DeactivateObject1(){
        Object1.SetActive(false);
     }

    public void ActivateObject2(){
        Object2.SetActive(true);

        Invoke("DeactivateObject2", 5); 
    }

    private void DeactivateObject2(){
        Object2.SetActive(false);
     }

    public void ActivateObject3(){
        Object3.SetActive(true);

        Invoke("DeactivateObject3", 5); 
    }

    private void DeactivateObject3(){
        Object3.SetActive(false);
     }

    public void ActivateObject4(){
        Object4.SetActive(true);

        Invoke("DeactivateObject4", 5); 
    }

    private void DeactivateObject4(){
        Object4.SetActive(false);
     }

    public void ActivateObject5(){
        Object5.SetActive(true);

        Invoke("DeactivateObject5", 5);
    }

    private void DeactivateObject5(){
        Object5.SetActive(false);
     }

    public void ActivateObject6(){
        Object6.SetActive(true);

        Invoke("DeactivateObject6", 5);
    }

    private void DeactivateObject6(){
        Object6.SetActive(false);
     }

    public void ActivateObject7(){
        Object7.SetActive(true);

        Invoke("DeactivateObject7", 5);
    }

    private void DeactivateObject7(){
        Object7.SetActive(false);
     }

    public void ActivateObject8(){
        Object8.SetActive(true);

        Invoke("DeactivateObject8", 5);
    }

    private void DeactivateObject8(){
        Object8.SetActive(false);
     }

    public void ActivateObject9(){
        Object9.SetActive(true);

        Invoke("DeactivateObject9", 5);
    }

    private void DeactivateObject9(){
        Object9.SetActive(false);
     }

    public void ActivateObject10(){
        Object10.SetActive(true);

        Invoke("DeactivateObject10", 5);
    }

    private void DeactivateObject10(){
        Object10.SetActive(false);
     }
}
