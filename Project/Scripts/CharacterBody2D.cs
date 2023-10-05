using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{
	public float gravity = 3000;   //ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public int wspeed { get; set; } = 800;
	public int jumpvelocity { get; set; } = 1200;
	
	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
		
		if (!IsOnFloor())
			{ velocity.Y += (float)delta * gravity; }
		
		if (Input.IsKeyPressed(Key.Space) && IsOnFloor())
			{ velocity.Y = -jumpvelocity; }
		
		if (Input.IsActionPressed("move_right"))
			{ velocity.X = wspeed; }
			
		else if (Input.IsActionPressed("move_left"))
			{ velocity.X = -wspeed; }		
		
		else 
			{ velocity.X = 0; }
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
