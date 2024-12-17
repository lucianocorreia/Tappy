using Godot;
using System;

public partial class ParallaxImage : Parallax2D
{
    [Export] private Texture2D _srcTexture;
    [Export] private Sprite2D _sprite;
    [Export] private float _speedScale;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Autoscroll = new Vector2(-_speedScale * 120.0f, 0);
        float scaleFactor = GetViewportRect().Size.Y / _srcTexture.GetHeight();

        _sprite.Texture = _srcTexture;
        _sprite.Scale = new Vector2(scaleFactor, scaleFactor);

        RepeatSize = new Vector2(_srcTexture.GetWidth() * scaleFactor, 0);
	}

}
