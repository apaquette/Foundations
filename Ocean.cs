using Godot;
using System;
using System.Diagnostics.Tracing;

public partial class Ocean : Node2D
{
	[Export] private Sprite2D _planeSprite;
	[Export] private Sprite2D _helicoperSprite;

	private event Action<Vector2> PlaneMovedEvent;

	private Vector2 _moveDir = Vector2.Zero;
	private const float PLANESPEED = 50.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello from Ocean.cs!");
		PlaneMovedEvent += OnPlaneMoved;
	}

    public override void _UnhandledInput(InputEvent @event)
    {
        if(@event.IsActionPressed("ui_right"))
			_moveDir.X = 1;
		else if(@event.IsActionReleased("ui_right") && _moveDir.X == 1)
			_moveDir.X = 0;
		
		if(@event.IsActionPressed("ui_down"))
			_moveDir.Y = 1;
		else if(@event.IsActionReleased("ui_down") && _moveDir.Y == 1)
			_moveDir.Y = 0;
		
		if(@event.IsActionPressed("ui_left"))
			_moveDir.X = -1;
		else if(@event.IsActionReleased("ui_left") && _moveDir.X == -1)
			_moveDir.X = 0;
		
		if(@event.IsActionPressed("ui_up"))
			_moveDir.Y = -1;
		else if(@event.IsActionReleased("ui_up") && _moveDir.Y == -1)
			_moveDir.Y = 0;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		PlaneMovedEvent?.Invoke(_moveDir * PLANESPEED * (float)delta);
	}

	private void OnPlaneMoved(Vector2 movement)
	{
		MoveSprite(_planeSprite, movement);
	}

	private static void MoveSprite(Sprite2D sprite, Vector2 movement)
	{
		sprite.GlobalPosition += movement;
	}
}
