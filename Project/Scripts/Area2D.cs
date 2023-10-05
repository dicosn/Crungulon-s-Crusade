using Godot;
using System;

public partial class Area2D : Godot.Area2D

{
	[Signal]
	public delegate void HitEventHandler();
	private void _on_body_entered(Node2D body)
{
	Hide();
}
	private void _on_body_exited(Node2D body)
{
	Show();
}
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).
	//public int Gravity { get; set; } = 4000; // How fast the player will fall
	// get gravity from project settings (keep everything synced)
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public Vector2 ScreenSize; // Size of the game window.
	
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		
		 	Vector2 velocity = new Vector2(); // The player's movement vector.
		
		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 40;
		}

		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 40;
		}		
		//velocity.Y += Gravity;
		
		//MoveAndSlide();
		//MoveAndCollide(new Vector2(0, 1));
		
		


//		if (Input.IsActionPressed("move_down"))
//		{
//			velocity.Y += 1;
//		}
//
//		if (Input.IsActionPressed("move_up"))
//		{
//			velocity.Y -= 1;
//		}
//		if (velocity.Length() > 0)
//   		{
//		velocity = velocity.Normalized() * Speed;
//		}	
//		Position += velocity * (float)delta;
//		Position = new Vector2(
//			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
//			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
//		);
	
}

}

