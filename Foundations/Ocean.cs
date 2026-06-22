using Godot;

public partial class Ocean : Node2D
{
	[Export] private Sprite2D _planeSprite;
	[Export] private Sprite2D _helicoperSprite;
	private const float PLANESPEED = 100.0f;
	private const float PLANEROTATIONSPEED = 3.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello from Ocean.cs!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionPressed("ui_up"))
			_planeSprite.MoveLocalX(PLANESPEED * (float)delta);


		_planeSprite.GlobalRotation += GetPlayerRotarionDirection() * PLANEROTATIONSPEED * (float)delta;
	}

	private static float GetPlayerRotarionDirection()
	{
		if (Input.IsActionPressed("ui_right"))
			return 1;
		if(Input.IsActionPressed("ui_left"))
			return -1;

		return 0;
	}
}
