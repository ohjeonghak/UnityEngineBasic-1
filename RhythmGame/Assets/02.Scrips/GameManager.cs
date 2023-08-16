using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
  public enum State
    {
        idle,
        LoadSongData,
        WaitUntilSongDataLoaded,
        StartPlay,
        WaitUntilPlayFinished,
        DisplayScore,
        WaitForUser,
    }
    public State state;


    private void Awake()
    {
        if (Instance != null)  // 이미 GameManager 가 존재하면
        {
            Destroy(gameObject); // 새로 눈뜬애는 파괴
            return;
        }

        Instance = this;  // GameManager 없으면 싱글톤 등록
        DontDestroyOnLoad(gameObject); // 씬 전환되도 파괴안되게 설정
    }

    private void Update()
    {
        switch (state)
        {
            case State.idle:
                break;
            case State.LoadSongData:
                break;
            case State.WaitUntilSongDataLoaded:
                break;
            case State.StartPlay:
                break;
            case State.WaitUntilPlayFinished:
                break;
            case State.DisplayScore:
                break;
            case State.WaitForUser:
                break;
            default:
                break;
        }
    }
}
