using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Genel bir metod olmasý için virtual olarak iþaretledik böylece diðer metodlar bundan türetilebilir.
    public virtual void Interact()
    {
        //Üstüne yazýlacak metod.
    }
}
