using Godot;
using System;

public partial class Game : Node2D
{
    [Export] private Marker2D _spawnUpper;
    [Export] private Marker2D _spawnLower;
    [Export] private Node2D _pipesHolder;
    [Export] private Timer _spawnTimer;
    [Export] private PackedScene _pipesScene;
    [Export] private Plane _plane;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _spawnTimer.Timeout += OnSpawnTimerTimeout;
        _plane.OnPlaneDied += OnPlaneDied;

        OnSpawnTimerTimeout();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void StopPipes()
    {
        _spawnTimer.Stop();
        foreach(Pipes p in _pipesHolder.GetChildren())
        {
            p.SetProcess(false);
        }

    }

    private void OnPlaneDied()
    {
        GD.Print("Game Over");
        StopPipes();
    }

    public float GetSpawnY()
    {
        return (float)GD.RandRange(_spawnUpper.Position.Y, _spawnLower.Position.Y);
    }

    private void OnSpawnTimerTimeout()
    {
        Pipes np = _pipesScene.Instantiate<Pipes>();
        _pipesHolder.AddChild(np);

        np.Position = new Vector2(_spawnLower.Position.X, GetSpawnY());
    }

}
