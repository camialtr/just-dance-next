using Nova;
using UnityEngine;

public class FeedbackElements : MonoBehaviour
{
    public int DancerID;

    public Texture2D[] dancersAvatars;
    public Texture2D[] feedbacks;
    public UIBlock2D[] stars;
    public bool[] starRevealed = new bool[7] { false, false, false, false, false, false, false };
    public Texture2D[] starsTexture;

    public UIBlock2D feedbackColorUIBlock;
    public UIBlock2D avatar;
    public UIBlock2D emission;
    public UIBlock2D line;
    public TextBlock nameShadow;
    public TextBlock nameText;
    public Animator feedbackAnimator;
    public UIBlock2D feedbackUIBlock;

    public void SetUpDancer()
    {
        Color color = Color.white;
        switch (DancerID)
        {
            case 0:
                color = new(0.0f, 0.407843f, 0.827451f, 1f);
                feedbackColorUIBlock.Color = color;
                avatar.SetImage(dancersAvatars[0]);
                emission.Color = color;
                line.Color = color;
                nameShadow.Text = "Happy";
                nameText.Text = "Happy";
                break;
            case 1:
                color = new(0.0f, 0.752941f, 0.745098f, 1f);
                feedbackColorUIBlock.Color = color;
                avatar.SetImage(dancersAvatars[1]);
                emission.Color = color;
                line.Color = color;
                nameShadow.Text = "Jazzy";
                nameText.Text = "Jazzy";
                break;
            case 2:
                color = new(1.0f, 0.701961f, 0.0f, 1f);
                feedbackColorUIBlock.Color = color;
                avatar.SetImage(dancersAvatars[2]);
                emission.Color = color;
                line.Color = color;
                nameShadow.Text = "Funky";
                nameText.Text = "Funky";
                break;
            case 3:
                color = new(1.0f, 0.0f, 0.698039f, 1f);
                feedbackColorUIBlock.Color = color;
                avatar.SetImage(dancersAvatars[3]);
                emission.Color = color;
                line.Color = color;
                nameShadow.Text = "Crazy";
                nameText.Text = "Crazy";
                break;
        }
    }

    public void TriggerFeedback(Feedbacks scoreResult)
    {
        feedbackAnimator.Play("Feedback-Generic");
        switch (scoreResult)
        {
            case Feedbacks.goldmiss:
                feedbackUIBlock.SetImage(feedbacks[0]);
                break;
            case Feedbacks.miss:
                feedbackUIBlock.SetImage(feedbacks[1]);
                break;
            case Feedbacks.ok:
                feedbackUIBlock.SetImage(feedbacks[2]);
                break;
            case Feedbacks.good:
                feedbackUIBlock.SetImage(feedbacks[3]);
                break;
            case Feedbacks.perfect:
                feedbackUIBlock.SetImage(feedbacks[4]);
                break;
            case Feedbacks.yeah:
                feedbackUIBlock.SetImage(feedbacks[5]);
                break;
        }
    }

    public void TriggerStar1()
    {
        stars[0].Color = Color.white;
    }

    public void TriggerStar2()
    {
        stars[1].Color = Color.white;

        stars[0].Position.X = -15;
        stars[1].Position.X = 15;
    }

    public void TriggerStar3()
    {
        stars[2].Color = Color.white;

        stars[0].Position.X = -30;
        stars[1].Position.X = 0;
        stars[2].Position.X = 30;
    }

    public void TriggerStar4()
    {
        stars[3].Color = Color.white;

        stars[0].Position.X = -45;
        stars[1].Position.X = -15;
        stars[2].Position.X = 15;
        stars[3].Position.X = 45;
    }

    public void TriggerStar5()
    {
        stars[4].Color = Color.white;

        stars[0].Position.X = -60;
        stars[1].Position.X = -30;
        stars[2].Position.X = 0;
        stars[3].Position.X = 30;
        stars[4].Position.X = 60;
    }

    public void TriggerSuperstar()
    {
        stars[0].SetImage(starsTexture[0]);
        stars[1].SetImage(starsTexture[0]);
        stars[2].SetImage(starsTexture[0]);
        stars[3].SetImage(starsTexture[0]);
        stars[4].SetImage(starsTexture[0]);
    }

    public void TriggerMegastar()
    {
        stars[0].SetImage(starsTexture[1]);
        stars[1].SetImage(starsTexture[1]);
        stars[2].SetImage(starsTexture[1]);
        stars[3].SetImage(starsTexture[1]);
        stars[4].SetImage(starsTexture[1]);
    }
}

public enum Feedbacks
{
    goldmiss,
    miss,    
    ok,
    good,
    perfect,
    yeah
}
