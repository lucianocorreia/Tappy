using Godot;
using System;

public partial class Main : Control
{
    [Export] private Label _hightScoreLabel;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _hightScoreLabel.Text = $"{ScoreManager.GetHighScore():0000}";
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("fly"))
        {
            GameManager.LoadGame();
        }
    }
}
