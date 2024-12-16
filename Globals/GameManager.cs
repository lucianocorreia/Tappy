using Godot;
using System;

public partial class GameManager : Node
{
    public static GameManager Instance { get; private set; }

    private PackedScene _mainScene = GD.Load<PackedScene>("res://Scenes/Main/Main.tscn");
    private PackedScene _gameScene = GD.Load<PackedScene>("res://Scenes/Game/Game.tscn");


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Instance = this;
    }

    public static void LoadMain()
    {
        Instance.GetTree().ChangeSceneToPacked(Instance._mainScene);
    }

    public static void LoadGame()
    {
        Instance.GetTree().ChangeSceneToPacked(Instance._gameScene);
    }

}
