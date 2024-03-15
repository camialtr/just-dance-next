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
    readonly List<GameObject> pictoObjects = new();

    int atualPicto = 0;
    int atualBeat = 0;

    public void ApplyPictobarColor()
    {
        arrowUIBlock.Color = accentColor;
        dots00.Color = accentColor;
        dots01.Color = accentColor;
    }

    public async Task LoadPictoAssets(string mapName, string path)
    {
        for (int i = 0; i < timeline.pictos.Count; i++)
        {
            Texture2D texture;
            if (songDesc.numCoach == 1)
            {
                texture = new(256, 256, TextureFormat.RGBA32, false);
            }
            else
            {
                texture = new(384, 256, TextureFormat.RGBA32, false);
            }
            texture.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapName, "pictos", timeline.pictos[i].name + ".png")));
            pictos.Add(texture);
            pictoObjects.Add(Instantiate(pictoPrefab));
            pictoObjects[atualPicto].transform.SetParent(transform, false);
            pictoObjects[atualPicto].name = timeline.pictos[atualPicto].name;

            if (songDesc.numCoach > 1)
            {
                pictoObjects[atualPicto].GetComponent<Picto>().picto.Size.X = 384f;
                pictoObjects[atualPicto].GetComponent<Picto>().shadow.Size.X = 384f;
            }

            Picto picto = pictoObjects[atualPicto].GetComponent<Picto>();

            picto.picto.SetImage(pictos[atualPicto]);
            picto.shadow.SetImage(pictos[atualPicto]);

            pictoObjects[atualPicto].SetActive(false);

            atualPicto++;
        }
        atualPicto = 0;
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
            //pictoObjects[atualPicto].GetComponent<Picto>().picto.SetImage(pictos[atualPicto]);
            //pictoObjects[atualPicto].GetComponent<Picto>().shadow.SetImage(pictos[atualPicto]);

            pictoObjects[atualPicto].SetActive(true);

            atualPicto++;
        }
    }

    void Filler()
    {
        Picto picto = Instantiate(pictoPrefab).GetComponent<Picto>();
        picto.gameObject.transform.SetParent(transform, false);
        picto.name = timeline.pictos[atualPicto].name;

        if (songDesc.numCoach > 1)
        {
            picto.picto.Size.X = 384f;
            picto.shadow.Size.X = 384f;
        }

        picto.picto.SetImage(pictos[atualPicto]);
        picto.shadow.SetImage(pictos[atualPicto]);

        atualPicto++;
    }
}
