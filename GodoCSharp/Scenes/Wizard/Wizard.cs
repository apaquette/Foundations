using Godot;
using System;

public partial class Wizard : Node2D
{
	[Export] private Timer _timer;
	[Signal] public delegate void CastSpellEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer.Timeout += Attack;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private void Attack()
	{
		GD.Print("Attack");
		EmitSignal(SignalName.CastSpell);
	}
}
