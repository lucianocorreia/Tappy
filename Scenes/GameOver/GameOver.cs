using Godot;
using System;

public partial class GameOver : Control
{
    [Export] private Label _gameOverLabel;
    [Export] private Label _spaceLabel;
    [Export] private AudioStreamPlayer _gameOverSound;
    [Export] private Timer _timer;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SignalManager.Instance.OnPlaneDied += OnPlaneDied;
        _timer.Timeout += OnTimerTimeout;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("fly") && _spaceLabel.Visible)
        {
            GameManager.LoadMain();
        }
    }

    public override void _ExitTree()
    {
        SignalManager.Instance.OnPlaneDied -= OnPlaneDied;
        base._ExitTree();
    }

    private void OnPlaneDied()
    {
        _timer.Start();
        Show();
        _gameOverSound.Play();
    }

    private void OnTimerTimeout()
    {
        _gameOverLabel.Hide();
        _spaceLabel.Show();
    }
}
