using Godot;
using System;

public partial class Ocean : Node2D
{
	[Export] private Sprite2D _planeSprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello from Ocean.cs!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
