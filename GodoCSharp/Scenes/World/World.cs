using Godot;
using System;

public partial class World : Node2D
{
	[Export] private Wizard _wizard;
	[Export] private Hobbit _hobbit;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//_wizard.CastSpell += DamageHobbit;
		_hobbit.KillWizard += DamageWizard;
	}

	private void DamageHobbit()
	{
		_hobbit.SetProcess(false);
		_hobbit.Scale = new Vector2(0.3f, 0.3f);
	}

	private void DamageWizard()
	{
		_wizard.Scale = new Vector2(0.3f, 0.3f);
	}
}
