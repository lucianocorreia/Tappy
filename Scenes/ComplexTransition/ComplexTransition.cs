using Godot;
using System;

public partial class ComplexTransition : CanvasLayer
{
    [Export] private AnimationPlayer _animationPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        _animationPlayer.AnimationFinished += OnAnimationFinished;
	}

    private void OnAnimationFinished(StringName animName)
    {
        QueueFree();
    }

    private void SwitchScene()
    {
        GetTree().ChangeSceneToPacked(GameManager.Instance.GetNextScene());
    }
}
