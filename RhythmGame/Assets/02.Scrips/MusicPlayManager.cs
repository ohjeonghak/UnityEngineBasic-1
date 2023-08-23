using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.Linq;// Collection의 다양한 질의(Query) 기능들을 포함하는 네임스페이스

[RequireComponent(typeof(VideoPlayer))]
public class MusicPlayManager : MonoBehaviour
{
   public static MusicPlayManager instance;

    public float noteFallingDistance => _spawnerCenter.position.y - _hitterCenter.position.y;
    public float noteFallingTime => noteFallingDistance / speedGain;
   public float speedGain = 1.0f;

   public bool isPlaying;
   private VideoPlayer _videoPlayer;
   private Queue<NoteData> _queue;
   private float _timeMark;

   private Dictionary<KeyCode, NoteSpawners> _spawners;
    [SerializeField] private List<NoteSpawners> _spawnerList;
    [SerializeField] private Transform _spawnerCenter;
    [SerializeField] private Transform _hitterCenter;

    public const int POINT_COOL = 500;
    public const int POINT_GREAT = 300;
    public const int POINT_GOOD = 100;
    public const int POINT_MISS = 0;
    public const int POINT_BAD = -100;
    public int point
    {
        get => _point;
        set
        {
            _point = value;
            _scoringText.score = value;
        }
    }
    private int _point;
    [SerializeField] private ScoringText _scoringText;

    public int combo
    {
        get => _combo;
        set
        {
            if (highestCombo < value)
                highestCombo = value;
            
            _combo = value;
            _popUpTextManager.PopUpComboText(value);
        }
    }
    private int _combo;
    public int highestCombo;
    public int coolCount
    {
        get => _coolCount;
        set
        {
            point += (value - _coolCount) * POINT_COOL;
            combo += (value - _coolCount);
            _popUpTextManager.PopUpHitJudgeText(HitJudge.Cool);
        }
    }
    public int greatCount
    {
        get => _greatCount;
        set
        {
            point += (value - _greatCount) * POINT_GREAT;
            combo += (value - _greatCount);
            _popUpTextManager.PopUpHitJudgeText(HitJudge.Great);
        }
    }
    public int goodCount
    {
        get => _goodCount;
        set
        {
            point += (value - _goodCount) * POINT_GOOD;
            combo += (value - _goodCount);
            _popUpTextManager.PopUpHitJudgeText(HitJudge.Good);
        }
    }
    public int missCount
    {
        get => _missCount;
        set
        {
            point += (value - _missCount) * POINT_MISS;
            combo = 0;
            _popUpTextManager.PopUpHitJudgeText(HitJudge.Miss);
        }
    }
 public int badCount
    {
        get => _badCount;
        set
        {
            point += (value - _badCount) * POINT_BAD;
            combo = 0;
            _popUpTextManager.PopUpHitJudgeText(HitJudge.Bad);
        }
    }
    private int _coolCount;
    private int _greatCount;
    private int _goodCount;
    private int _missCount;
    private int _badCount;


    [SerializeField] private PopUpTextManager _popUpTextManager;
    private void Awake()
   {
       instance = this;
       _videoPlayer = GetComponent<VideoPlayer>();
       _spawners = new Dictionary<KeyCode, NoteSpawners>();
        foreach (var spawner in _spawnerList)
        {
            _spawners.Add(spawner.key, spawner);
        }
       
   }

    public void StartMusicPlay()
    {
        _queue = new Queue<NoteData>(SongDataLoader.dataLoaded.noteDatum.OrderBy(x => x.time));
        _videoPlayer.clip = SongDataLoader.clipLoaded;
        Invoke("PlayVideo", noteFallingTime);
        _timeMark = Time.time;
        isPlaying = true;
        Debug.Log("Play Music!");
    }
    private void Update()
    {
        if (isPlaying == false)
            return;

        while (_queue.Count > 0)
        {

            if (_queue.Peek().time <= Time.time - _timeMark)
            {
                _spawners[_queue.Dequeue().key].Spawn();
            }
            else
            {
                break;
            }
        }
        if (_queue.Count <= 0 )
        {
            isPlaying = false;
        }
        
    }

    private void PlayVideo()
    {
        _videoPlayer.Play();
    }
        }
