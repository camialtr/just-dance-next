using Nova;
using UnityEngine;

public class Picto : MonoBehaviour
{
    public UIBlock pictoCluster;
    public UIBlock2D picto;
    public UIBlock2D shadow;

    private void Start()
    {
        
    }

    public void Show()
    {
        LeanTween.value(1169.4f, 500f, 1.8f).setOnUpdate((float value) =>
        {
            pictoCluster.Position.X = value;
        });
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
