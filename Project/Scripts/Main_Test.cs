using Godot;
using System;

public partial class Main_Test : Node
{
	[Export]
	public PackedScene enemy_level { get; set; }
	[Export]
	public PackedScene Character { get; set; }
	
	public void NewGame() {

		var player = GetNode<CharacterBody2D>("Character");
		var startPosition = GetNode<Marker2D>("PlayerStartPosition");
		player.Position = startPosition.Position;

		//GetNode<Timer>("StartTimer").Start();
}
	public void OnMobTimerTimeout()
{
	// Note: Normally it is best to use explicit types rather than the `var`
	// keyword. However, var is acceptable to use here because the types are
	// obviously Mob and PathFollow2D, since they appear later on the line.

	// Create a new instance of the Mob scene.
	Mob mob = enemy_level.Instantiate<Mob>();

	// Choose a random location on Path2D.
	var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
	//mobSpawnLocation.ProgressRatio = GD.Randf();

	// Set the mob's direction perpendicular to the path direction.
	float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;

	// Set the mob's position to a random location.
	mob.Position = mobSpawnLocation.Position;

	// Choose the velocity.
	var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
	//mob.LinearVelocity = velocity.Rotated(direction);

	// Spawn the mob by adding it to the Main scene.
	AddChild(mob);
}
private void gameOver()
{
	// Replace with function body.
}
}



