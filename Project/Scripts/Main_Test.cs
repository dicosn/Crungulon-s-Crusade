using Godot;
using System;

public partial class Main_Test : Node
{
	[Export]
	public PackedScene enemy_level { get; set; }
	[Export]
	public PackedScene Character { get; set; }
		

public override void _Ready()
{
	NewGame();
}

	public void NewGame() {

		var player = GetNode<CharacterBody2D>("Character/CharacterBody2D");
		var startPosition = GetNode<Marker2D>("PlayerStartPosition");
		player.Position = startPosition.Position;
		
		GetNode<Timer>("StartTimer").Start();
}

private void _on_mob_timer_timeout()
{

	// Choose a random location on Path2D.
	var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
	var mobEndLocation = GetNode<PathFollow2D>("MobPath/MobEndLocation");
	//mobSpawnLocation.ProgressRatio = GD.Randf();
	
	Vector2 startingPosition = mobSpawnLocation.GlobalPosition;
	Vector2 endingPosition = mobEndLocation.GlobalPosition;
	
	GD.Print("start location",startingPosition);
	GD.Print("stop location",endingPosition);
	
	Mob mob = enemy_level.Instantiate<Mob>();
	
	
	//mobSpawnLocation.ProgressRatio = GD.Randf();
			//GD.Print("mob's initial position", mob.GlobalPosition);

	Vector2 direction = (endingPosition - startingPosition).Normalized();
			GD.Print("direction", direction);
	mob.GlobalPosition = startingPosition;
	
	float distance = startingPosition.DistanceTo(endingPosition);
			GD.Print("distance",distance);

	float timeToCoverDistance = 30.0f; // Adjust as needed
	float speed = distance / timeToCoverDistance;
			GD.Print("speed",speed);
	
	Vector2 velocity = direction * speed;
	//var velocity = new Vector2(direction*speed, 0);
	
	mob.Velocity += velocity;
	//mob.LinearVelocity = velocity.Rotated(direction);
			GD.Print("velocity", velocity);
			GD.Print("mob's position after setting velocity", mob.GlobalPosition);
	
	// Spawn the mob by adding it to the Main scene.
	AddChild(mob);	
	
}

public void _on_start_timer_timeout()
{
	GetNode<Timer>("MobTimer").Start();
	//GetNode<Timer>("ScoreTimer").Start();
}

public void gameOver()
{
	GetNode<Timer>("MobTimer").Stop();
	GetTree().CallGroup("mobs", Node.MethodName.QueueFree);
}
}
