using Godot;
using System;

public partial class Hobbit : Node2D
{
	[Signal] public delegate void KillWizardEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Rotate((float)delta * Mathf.Pi);
		if(Input.IsActionJustPressed("ui_up"))
		{
			EmitSignal(SignalName.KillWizard);
		}
	}
}
