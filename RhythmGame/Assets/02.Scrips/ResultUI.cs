using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _coolCount;
    [SerializeField] private TMP_Text _greatCount;
    [SerializeField] private TMP_Text _goodCount;
    [SerializeField] private TMP_Text _missCount;
    [SerializeField] private TMP_Text _badCount;
    [SerializeField] private TMP_Text _rankCount;
    [SerializeField] private Button _lobby;
    [SerializeField] private Button _replay;


    private void OnEnable()
    {
        MusicPlayManager musicPlayManger = MusicPlayManager.instance;
        _score.text = musicPlayManger.score.ToString();
        _coolCount.text = musicPlayManger.coolCount.ToString();
        _greatCount.text = musicPlayManger.greatCount.ToString();
        _goodCount.text = musicPlayManger.goodCount.ToString();
        _missCount.text = musicPlayManger.missCount.ToString();
        _badCount.text = musicPlayManger.badCount.ToString();
        _rankCount.text = musicPlayManger.rank;
    }

    private void Awake()
    {
        _lobby.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SongSelect");
            GameManager.Instance.state = GameManager.State.idle;
        });
        _replay.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            GameManager.Instance.state = GameManager.State.StartPlay;
        });
    }
}
