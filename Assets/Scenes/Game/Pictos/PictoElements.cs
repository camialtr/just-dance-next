using Nova;
using System.IO;
using UnityEngine;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

public class PictoElements : MonoBehaviour
{
    [SerializeField] GameObject pictoPrefab;
    [SerializeField] UIBlock2D arrowUIBlock;
    [SerializeField] Animator arrowAnimator;
    [SerializeField] UIBlock2D dots00;
    [SerializeField] UIBlock2D dots01;

    [HideInInspector] public SongDesc songDesc;
    [HideInInspector] public MusicTrack musicTrack;
    [HideInInspector] public Color accentColor;
    [HideInInspector] public Timeline timeline;
    [HideInInspector] public Stopwatch timeManager;
    [HideInInspector] public bool isLoaded = false;

    readonly List<Texture2D> pictos = new();

    int atualPicto = 0;
    int atualBeat = 0;

    public async Task LoadPictoAssets(string mapName, string path)
    {
        arrowUIBlock.Color = accentColor;
        dots00.Color = accentColor;
        dots01.Color = accentColor;
        for (int i = 0; i < timeline.pictos.Count; i++)
        {
            Texture2D texture;
            if (songDesc.numCoach == 1)
            {
                texture = new(256, 256);
            }
            else
            {
                texture = new(384, 256);
            }
            texture.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapName, "pictos", timeline.pictos[i].name + ".png")));
            pictos.Add(texture);
        }
        isLoaded = true;
    }

    private void Update()
    {
        if (timeManager == null) { return; }

        if (atualBeat < musicTrack.beats.Count && timeManager.ElapsedMilliseconds / 1000f >= musicTrack.beats[atualBeat])
        {
            arrowAnimator.Play("Beat");
            atualBeat++;
        }
        
        if (atualPicto == timeline.pictos.Count) { return; }

        if (timeManager.ElapsedMilliseconds / 1000f >= timeline.pictos[atualPicto].time + musicTrack.beats[musicTrack.startBeat] - 1.7999f)
        {
            Picto picto = Instantiate(pictoPrefab).GetComponent<Picto>();
            picto.gameObject.transform.SetParent(transform, false);
            picto.name = timeline.pictos[atualPicto].name;

            if (songDesc.numCoach > 1)
            {
                picto.picto.Size.X = (384f);
                picto.shadow.Size.X = (384f);
            }

            picto.picto.SetImage(pictos[atualPicto]);
            picto.shadow.SetImage(pictos[atualPicto]);

            atualPicto++;
        }
    }
}
