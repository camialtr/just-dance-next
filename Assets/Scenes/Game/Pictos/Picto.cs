using Nova;
using UnityEngine;

public class Picto : MonoBehaviour
{
    public UIBlock2D picto;
    public UIBlock2D shadow;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
