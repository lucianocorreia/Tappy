using Godot;
using System;

public partial class Pipes : Node2D
{
    const float SCROLL_SPEED = 120.0f;

    [Export] private VisibleOnScreenNotifier2D _visibleOnScreenNotifier2D;
    [Export] private Area2D _upperPipe;
    [Export] private Area2D _lowerPipe;
    [Export] private Area2D _layser;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _visibleOnScreenNotifier2D.ScreenExited += OnScreenExited;
        _lowerPipe.BodyEntered += OnBodyEntered;
        _upperPipe.BodyEntered += OnBodyEntered;

        _layser.BodyEntered += OnLayserBodyEntered;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position -= new Vector2(SCROLL_SPEED * (float)delta, 0.0f);
    }

    private void OnLayserBodyEntered(Node2D body)
    {
        GD.Print("Layser entered");
    }

    private void OnScreenExited()
    {
        GD.Print("Pipes exited the screen");
        QueueFree();
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is Plane plane)
        {
            plane.Die();
        }

        // if (body.IsInGroup("plane"))
        // {
        //     (body as Plane).Die();
        // }
    }
}
