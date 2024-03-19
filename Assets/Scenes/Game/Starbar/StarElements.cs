using Nova;
using System.Threading.Tasks;
using UnityEngine;

public class StarElements : MonoBehaviour
{
    public UIBlock2D[] stars;
    public Texture2D[] starsTexture;
    public AudioSource[] starAudios;
    public Animator animator;

    public async void TriggerStar1()
    {
        stars[0].SetImage(starsTexture[0]);
        stars[0].Color = Color.white;
        starAudios[0].Play();
        animator.Play("Star-1-Reveal");
        await Task.Delay(1000);
        starAudios[1].Play();        
    }

    public async void TriggerStar2()
    {
        stars[1].SetImage(starsTexture[0]);
        stars[1].Color = Color.white;
        starAudios[0].Play();
        animator.Play("Star-2-Reveal");
        await Task.Delay(1000);
        starAudios[2].Play();
    }
}
