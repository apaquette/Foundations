using Godot;

public partial class Ocean : Node2D
{
	[Export] private Sprite2D _planeSprite;
	[Export] private Sprite2D _helicoperSprite;

	private float _rotationDir = 0.0f;
	private const float PLANESPEED = 100.0f;

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
			
		// rotate right
		_rotationDir = 0;
		if (Input.IsActionPressed("ui_right"))
			_rotationDir = 1;
		// rotate left
		if(Input.IsActionPressed("ui_left"))
			_rotationDir = -1;

		_planeSprite.GlobalRotation += _rotationDir * 5f * (float)delta;
	}
}
