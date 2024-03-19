using Nova;
using UnityEngine;

public class FeedbackElements : MonoBehaviour
{
    public int DancerID;

    public Texture2D[] dancersAvatars;
    public Texture2D[] feedbacks;

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
