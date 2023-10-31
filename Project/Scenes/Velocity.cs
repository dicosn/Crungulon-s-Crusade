using Godot;
using System;

public partial class Velocity : Label
{   public node hoorah;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
 	 	hoorah = GetNode<CharacterBody2D>("Node2D/CharacterBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = String.Format("Velocity:" + hoorah.velocity);
	}
}
