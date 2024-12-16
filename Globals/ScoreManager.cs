using Godot;
using System;

public partial class ScoreManager : Node
{
    public static ScoreManager Instance { get; private set; }

    private const string ScoreFile= "user://tappy.save";

    private uint _score = 0;
    private uint _highScore = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Instance = this;
        LoadScoreFromFile();
    }

    public override void _ExitTree()
    {
        SaveScoreToFile();
        base._ExitTree();
    }

    public static uint GetScore()
    {
        return Instance._score;
    }

    public static uint GetHighScore()
    {
        return Instance._highScore;
    }

    public static void SetScore(uint score)
    {
        Instance._score = score;
        if (Instance._score > Instance._highScore)
        {
            Instance._highScore = Instance._score;
        }

        GD.Print($"Score: {Instance._score}, High Score: {Instance._highScore}");
        SignalManager.EmitOnScored();

    }

    public static void ResetScore()
    {
        SetScore(0);
    }

    public static void IncrementScore()
    {
        SetScore(GetScore() + 1);
    }

    private void SaveScoreToFile()
    {
        using FileAccess file = FileAccess.Open(ScoreFile, FileAccess.ModeFlags.Write);
        if(file != null)
        {
            file.Store32(_highScore);
        }
    }

    private void LoadScoreFromFile()
    {
        using FileAccess file = FileAccess.Open(ScoreFile, FileAccess.ModeFlags.Read);
        if(file != null)
        {
            _highScore = file.Get32();
        }
    }
}
