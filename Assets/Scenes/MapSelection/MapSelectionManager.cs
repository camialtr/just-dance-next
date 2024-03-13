using Nova;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;
using UnityEngine.Video;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UIElements;

public class MapSelectionManager : MonoBehaviour
{
    [SerializeField] ClipMask mapSelectionClipMask;

    VideoPlayer previewPlayer;

    [SerializeField] AudioSource selectAudio;
    [SerializeField] AudioSource togglePositiveAudio;
    [SerializeField] AudioSource toggleNegativeAudio;

    [SerializeField] BackgroundManager background;
    [SerializeField] UIBlock coverCluster;
    [SerializeField] UIBlock2D[] covers;
    [SerializeField] UIBlock2D titleUIBlock;
    [SerializeField] TextBlock titleTextBlock;
    [SerializeField] TextBlock artist;
    [SerializeField] Texture2D[] difficulties;
    [SerializeField] UIBlock2D difficultiesUIBlock;
    [SerializeField] TextBlock difficultiesTextBlock;

    [SerializeField] GameObject gameUI;

    Playlists playlists;
    SongDesc songDesc;

    bool canInteract = false;
    int selectedMap = 0;

    bool titleIsText = false;

    private async void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundManager>();
        previewPlayer = GameObject.Find("Video-Preview").GetComponent<VideoPlayer>();

        string path = Application.persistentDataPath;

        playlists = await Task.Run(async () => JsonConvert.DeserializeObject<Playlists>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", "playlists.json"))));

        UpdateMenu();

        if (titleIsText)
        {
            LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
            {
                titleTextBlock.Color = new(1f, 1f, 1f, value);
            });
        }
        else
        {
            LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
            {
                titleUIBlock.Color = new(1f, 1f, 1f, value);
            });
        }

        background.StopMenuAudio();

        LeanTween.value(0f, 1f, 0.5f).setOnUpdate((float value) =>
        {
            mapSelectionClipMask.Tint = new(1f, 1f, 1f, value);
        }).setOnComplete(() =>
        {
            canInteract = true;
        });
    }

    private async void Update()
    {
        if (canInteract)
        {
            if (InputManager.Select() && InputManager.source == InputManager.controller | InputManager.source == InputSource.Local)
            {
                canInteract = false;

                selectAudio.Play();

                LeanTween.value(1f, 0f, 0.5f).setOnUpdate((float value) =>
                {
                    mapSelectionClipMask.Tint = new(1f, 1f, 1f, value);
                }).setOnComplete(async () =>
                {
                    await Task.Delay(100);
                    gameUI.GetComponent<GameManager>().mapName = playlists.playlistCluster[0].maps[selectedMap].name;
                    GameObject.FindGameObjectWithTag("Background").SetActive(false);
                    Instantiate(gameUI);
                    previewPlayer.Pause();
                    gameObject.SetActive(false);
                });
            }
            else if (InputManager.Undo() && InputManager.source == InputManager.controller | InputManager.source == InputSource.Local)
            {
                Debug.Log("Back to Connection Screen");
            }
            else if (InputManager.Left() && InputManager.source == InputManager.controller | InputManager.source == InputSource.Local)
            {
                canInteract = false;

                LeanTween.cancelAll();

                togglePositiveAudio.Play();

                if (selectedMap - 1 < 0)
                {
                    selectedMap = playlists.playlistCluster[0].maps.Length - 1;
                }
                else
                {
                    selectedMap--;
                }

                if (titleIsText)
                {
                    titleTextBlock.Color = new(1f, 1f, 1f, 0f);
                }
                else
                {
                    titleUIBlock.Color = new(1f, 1f, 1f, 0f);
                }

                artist.Color = new(1f, 1f, 1f, 0f);
                difficultiesUIBlock.Color = new(1f, 1f, 1f, 0f);
                difficultiesTextBlock.Color = new(1f, 1f, 1f, 0f);

                UpdateMenu();

                LeanTween.value(-378f, 0f, 0.2f).setOnUpdate((float value) =>
                {
                    coverCluster.Position.X = value;
                }).setEaseInOutCirc().setOnComplete(async () =>
                {
                    await Task.Delay(25);
                    if (titleIsText)
                    {
                        LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                        {
                            titleTextBlock.Color = new(1f, 1f, 1f, value);
                        });
                    }
                    else
                    {
                        LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                        {
                            titleUIBlock.Color = new(1f, 1f, 1f, value);
                        });
                    }

                    LeanTween.value(-7f, -2f, 0.2f).setOnUpdate((float value) =>
                    {
                        artist.Position.Y = value;
                    });
                    LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                    {
                        artist.Color = new(1f, 1f, 1f, value);
                    });

                    LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                    {
                        difficultiesUIBlock.Color = new(1f, 1f, 1f, value);
                    });
                    LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                    {
                        difficultiesTextBlock.Color = new(1f, 1f, 1f, value);
                    });

                    canInteract = true;
                });
            }
            else if (InputManager.Right() && InputManager.source == InputManager.controller | InputManager.source == InputSource.Local)
            {
                canInteract = false;

                LeanTween.cancelAll();

                toggleNegativeAudio.Play();

                if (selectedMap + 1 >= playlists.playlistCluster[0].maps.Length)
                {
                    selectedMap = 0;
                }
                else
                {
                    selectedMap++;
                }

                if (titleIsText)
                {
                    LeanTween.value(1f, 0f, 0.2f).setOnUpdate((float value) =>
                    {
                        titleTextBlock.Color = new(1f, 1f, 1f, value);
                    }).setEaseInOutCirc();
                }
                else
                {
                    LeanTween.value(1f, 0f, 0.2f).setOnUpdate((float value) =>
                    {
                        titleUIBlock.Color = new(1f, 1f, 1f, value);
                    }).setEaseInOutCirc();
                }

                LeanTween.value(-2f, 3f, 0.2f).setOnUpdate((float value) =>
                {
                    artist.Position.Y = value;
                });
                LeanTween.value(1f, 0f, 0.2f).setOnUpdate((float value) =>
                {
                    artist.Color = new(1f, 1f, 1f, value);
                });

                LeanTween.value(1f, 0f, 0.2f).setOnUpdate((float value) =>
                {
                    difficultiesUIBlock.Color = new(1f, 1f, 1f, value);
                });
                LeanTween.value(1f, 0f, 0.2f).setOnUpdate((float value) =>
                {
                    difficultiesTextBlock.Color = new(1f, 1f, 1f, value);
                });

                LeanTween.value(0f, -378f, 0.2f).setOnUpdate((float value) =>
                {
                    coverCluster.Position.X = value;
                }).setEaseInOutCirc().setOnComplete(async () =>
                {
                    await Task.Delay(25);
                    UpdateMenu();
                    coverCluster.Position.X = 0f;
                    await Task.Delay(25);
                    if (titleIsText)
                    {
                        LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                        {
                            titleTextBlock.Color = new(1f, 1f, 1f, value);
                        });
                    }
                    else
                    {
                        LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                        {
                            titleUIBlock.Color = new(1f, 1f, 1f, value);
                        });
                    }

                    LeanTween.value(-7f, -2f, 0.2f).setOnUpdate((float value) =>
                    {
                        artist.Position.Y = value;
                    });
                    LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                    {
                        artist.Color = new(1f, 1f, 1f, value);
                    });

                    LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                    {
                        difficultiesUIBlock.Color = new(1f, 1f, 1f, value);
                    });
                    LeanTween.value(0f, 1f, 0.2f).setOnUpdate((float value) =>
                    {
                        difficultiesTextBlock.Color = new(1f, 1f, 1f, value);
                    });

                    canInteract = true;
                });
            }
        }
    }

    void UpdateMenu()
    {
        string path = Application.persistentDataPath;

        songDesc = JsonConvert.DeserializeObject<SongDesc>(File.ReadAllText(Path.Combine(path, "Maps", playlists.playlistCluster[0].maps[selectedMap].name, "songdesc.json")));

        for (int i = 0; i < covers.Length; i++)
        {
            if (i != 0)
            {
                int iSelectedMap;
                if (selectedMap + i >= playlists.playlistCluster[0].maps.Length)
                {
                    iSelectedMap = selectedMap + i - playlists.playlistCluster[0].maps.Length;
                }
                else
                {
                    iSelectedMap = selectedMap + i;
                }
                Texture2D texture = new(1024, 512);
                texture.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", playlists.playlistCluster[0].maps[iSelectedMap].name, "cover.png")));
                covers[i].SetImage(texture);
            }            
        }

        if (File.Exists(Path.Combine(path, "Maps", playlists.playlistCluster[0].maps[selectedMap].name, "title.png")))
        {
            Texture2D texture = new(1004, 502);
            texture.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", playlists.playlistCluster[0].maps[selectedMap].name, "title.png")));
            titleUIBlock.SetImage(texture);
            titleIsText = false;
        }
        else
        {
            titleTextBlock.Text = songDesc.title;
            titleIsText = true;
        }

        artist.Text = songDesc.artist;

        difficultiesUIBlock.SetImage(difficulties[songDesc.difficulty - 1]);
        switch (songDesc.difficulty)
        {
            case 1:
                difficultiesTextBlock.Text = "Difficulty: Easy";
                break;
            case 2:
                difficultiesTextBlock.Text = "Difficulty: Medium";
                break;
            case 3:
                difficultiesTextBlock.Text = "Difficulty: Hard";
                break;
            case 4:
                difficultiesTextBlock.Text = "Difficulty: Extreme";
                break;
        }

        previewPlayer.url = "file://" + Path.Combine(Application.persistentDataPath, "Maps", playlists.playlistCluster[0].maps[selectedMap].name, "preview.mp4"); ;
        previewPlayer.Play();
        Resources.UnloadUnusedAssets();
    }
}

public struct Playlists
{
    public PlaylistCluster[] playlistCluster;

    public struct PlaylistCluster
    {
        public string name;
        public Maps[] maps;
    }

    public struct Maps
    {
        public string name;
    }
}
