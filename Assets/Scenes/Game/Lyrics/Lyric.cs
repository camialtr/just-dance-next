using Nova;
using Nova.TMP;
using UnityEngine;
using System.Diagnostics;
using System.Collections.Generic;

public class Lyric : MonoBehaviour
{
    [SerializeField] TextMeshProTextBlock text;
    [SerializeField] TextMeshProTextBlock coloredText;
    [SerializeField] UIBlock textMask;

    [HideInInspector] public MusicTrack musicTrack;
    [HideInInspector] public Color lyricColor;
    [HideInInspector] public Stopwatch timeManager;
    [HideInInspector] public bool hided = false;
    [HideInInspector] public bool destroy = false;

    bool released = false;
    bool animate = true;

    readonly List<Progression> progression = new();    
    readonly List<LTDescr> animations = new();
    int progressionIndex = 0;    

    private void Update()
    {
        if (released)
        {
            if (animate && timeManager.ElapsedMilliseconds / 1000f >= progression[progressionIndex].startTime + musicTrack.beats[musicTrack.startBeat])
            {
                if (progression.Count - 1 != progressionIndex)
                {
                    if (progressionIndex > 0)
                    {
                        LeanTween.pause(animations[progressionIndex - 1].uniqueId);
                        animations.Add(LeanTween.value(progression[progressionIndex].lastWidth, progression[progressionIndex].nextWidth, progression[progressionIndex].duration).setOnUpdate(UpdateSize));
                    }
                    else
                    {
                        animations.Add(LeanTween.value(progression[progressionIndex].lastWidth, progression[progressionIndex].nextWidth, progression[progressionIndex].duration).setOnUpdate(UpdateSize));
                    }
                }
                else
                {
                    animate = false;
                    animations.Add(LeanTween.value(progression[progressionIndex].lastWidth, progression[progressionIndex].nextWidth, progression[progressionIndex].duration).setOnUpdate(UpdateSize).setOnComplete(() =>
                    {
                        if (!hided)
                        {
                            Hide();
                        }
                    }));
                }
                progressionIndex++;
            }
        }

        if (destroy)
        {
            gameObject.SetActive(false);
        }
    }

    public void AddContent(string textValue, float startValue, float durationValue)
    {
        text.text += textValue;
        coloredText.text += textValue;
        text.ForceMeshUpdate();
        if (progressionIndex == 0)
        {
            progression.Add(new Progression() { lastWidth = 0f, nextWidth = text.renderedWidth, startTime = startValue, duration = durationValue });
            progressionIndex++;
        }
        else
        {
            progression.Add(new Progression() { lastWidth = progression[progressionIndex - 1].nextWidth, nextWidth = text.renderedWidth, startTime = startValue, duration = durationValue });
            progressionIndex++;
        }
    }

    public void Show()
    {
        coloredText.color = lyricColor;
        LeanTween.value(0f, 1f, 0.2f).setOnUpdate(UpdateAlpha);
        LeanTween.value(0f, 1f, 0.2f).setOnUpdate(UpdateAlpha);
        LeanTween.moveLocalY(gameObject, 48f, 0.2f).setOnComplete(() =>
        {
            gameObject.GetComponent<ClipMask>().Tint = new Color(1f, 1f, 1f, 1f);
        });
    }

    public void Release()
    {
        progressionIndex = 0;
        LeanTween.moveLocalY(gameObject, 88f, 0.2f).setOnComplete(() =>
        {
            released = true;
        });
    }

    public void Hide()
    {
        hided = true;
        text.color = lyricColor;
        LeanTween.value(1f, 0f, 0.1f).setOnUpdate(UpdateAlpha);
        LeanTween.moveLocalY(gameObject, 128f, 0.2f);
    }

    void UpdateAlpha(float value)
    {
        gameObject.GetComponent<ClipMask>().Tint = new Color(1f, 1f, 1f, value);
    }

    void UpdateSize(float value)
    {
        textMask.GetComponent<UIBlock>().Size.X = new Length(value, LengthType.Value);
    }

    struct Progression
    {
        public float lastWidth;
        public float nextWidth;
        public float startTime;
        public float duration;
    }
}