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

    public async void TriggerStar3()
    {
        stars[2].SetImage(starsTexture[0]);
        stars[2].Color = Color.white;
        starAudios[0].Play();
        animator.Play("Star-3-Reveal");
        await Task.Delay(1000);
        starAudios[3].Play();
    }

    public async void TriggerStar4()
    {
        stars[3].SetImage(starsTexture[0]);
        stars[3].Color = Color.white;
        starAudios[0].Play();
        animator.Play("Star-4-Reveal");
        await Task.Delay(1000);
        starAudios[4].Play();
    }

    public async void TriggerStar5()
    {
        stars[4].SetImage(starsTexture[0]);
        stars[4].Color = Color.white;
        starAudios[0].Play();
        animator.Play("Star-5-Reveal");
        await Task.Delay(1000);
        starAudios[5].Play();
    }

    public void TriggerSuperstar()
    {
        stars[0].SetImage(starsTexture[1]);
        stars[1].SetImage(starsTexture[1]);
        stars[2].SetImage(starsTexture[1]);
        stars[3].SetImage(starsTexture[1]);
        stars[4].SetImage(starsTexture[1]);
        starAudios[6].Play();
        animator.Play("Plus-Reveal");
    }

    public void TriggerMegastar()
    {
        stars[0].SetImage(starsTexture[2]);
        stars[1].SetImage(starsTexture[2]);
        stars[2].SetImage(starsTexture[2]);
        stars[3].SetImage(starsTexture[2]);
        stars[4].SetImage(starsTexture[2]);
        starAudios[7].Play();
        animator.Play("Plus-Reveal");
    }
}
