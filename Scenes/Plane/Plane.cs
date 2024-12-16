using Godot;
using System;

public partial class Plane : CharacterBody2D
{
    const float GRAVITY = 1200.0f;
    const float POWER = -400.0f;

    [Export] private AnimationPlayer _animationPlayer;
    [Export] private AnimatedSprite2D _planeSprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("Plane Ready");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        velocity.Y += GRAVITY * (float)delta;

        if(Input.IsActionJustPressed("fly"))
        {
            velocity.Y = POWER;
            _animationPlayer.Play("power");
        }

        Velocity = velocity;
        MoveAndSlide();

        if(IsOnFloor())
        {
            Die();
        }
    }

    public void Die()
    {
        SetPhysicsProcess(false);
        _planeSprite.Stop();
        // EmitSignal(SignalName.OnPlaneDied);
        SignalManager.EmitOnPlaneDied();
    }
}
