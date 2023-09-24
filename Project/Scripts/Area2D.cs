using Godot;
using System;

public partial class Area2D : Godot.Area2D

{
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).

	public Vector2 ScreenSize; // Size of the game window.
	
	public override void _Ready()
{
	ScreenSize = GetViewportRect().Size;
}
	
	
	
	public override void _Process(double delta)
{
	
	var velocity = Vector2.Zero; // The player's movement vector.

	if (Input.IsActionPressed("move_right"))
	{
		velocity.X += 1;
	}

	if (Input.IsActionPressed("move_left"))
	{
		velocity.X -= 1;
	}

	if (Input.IsActionPressed("move_down"))
	{
		velocity.Y += 1;
	}

	if (Input.IsActionPressed("move_up"))
	{
		velocity.Y -= 1;
	}

	
}

}

