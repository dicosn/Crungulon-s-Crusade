using Godot;
using System;

public partial class Main_Test : Node
{
	[Export]
	public PackedScene enemy_level { get; set; }
	[Export]
	public PackedScene Character { get; set; }
	//private float _t = 0.0f;	

private void _Ready()
{
   	NewGame();
}

	public void NewGame() {

		var player = GetNode<CharacterBody2D>("Character/CharacterBody2D");
		var startPosition = GetNode<Marker2D>("PlayerStartPosition");
		player.Position = startPosition.Position;
		
		GetNode<Timer>("StartTimer").Start();
		GetNode<Timer>("MobTimer").Start();
}
			
public void _on_mob_timer_timeout()
{
	
	// Choose a random location on Path2D.
	//var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
	//var mobEndLocation = GetNode<PathFollow2D>("MobPath/MobEndLocation");
//	//mobSpawnLocation.ProgressRatio = GD.Randf();
//
	//Vector2 startingPosition = mobSpawnLocation.GlobalPosition;
	//Vector2 endingPosition = mobEndLocation.GlobalPosition;
//
//	//GD.Print("start location",startingPosition);
//	//GD.Print("stop location",endingPosition);
//
	//Mob mob = enemy_level.Instantiate<Mob>();
//
//
//			//mobSpawnLocation.ProgressRatio = GD.Randf();
//			//GD.Print("mob's initial position", mob.GlobalPosition);
//
//	Vector2 direction = (endingPosition - startingPosition).Normalized();
////			GD.Print("direction", direction);
	//mob.GlobalPosition = startingPosition;
////
//	float distance = startingPosition.DistanceTo(endingPosition);
////			GD.Print("distance",distance);
////
//	float timeToCoverDistance = 30.0f; // Adjust as needed
//	float speed = distance / timeToCoverDistance;
////			GD.Print("speed",speed);
////
//	Vector2 velocity = direction * speed;
////	//var velocity = new Vector2(direction*speed, 0);
////
//	mob.Velocity = velocity;
//	//mob.LinearVelocity = velocity.Rotated(direction);
//			GD.Print("velocity", velocity);
//			GD.Print("mob's position after setting velocity", mob.GlobalPosition);
	
	// Spawn the mob by adding it to the Main scene.
	//AddChild(mob);
		
	
	
}
	//public void _PhysicsProcess(double delta){
			
			//KinematicCollision2D collision = MoveAndCollide(_velocity * (float)delta);
//			_on_mob_timer_timeout();
//			_t += (float)delta * 0.4f;
//			//var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
//			//var mobEndLocation = GetNode<PathFollow2D>("MobPath/MobEndLocation");
//   			PathFollow2D a = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
//			PathFollow2D b = GetNode<PathFollow2D>("MobPath/MobEndLocation");
//			RigidBody2D mob = GetNode<RigidBody2D>("Mob");
//			GD.Print("a&b",a,b);
//			mob.Position = a.Position.Lerp(b.Position, _t);
//}
			
public void _on_start_timer_ready()
{
	GetNode<Timer>("MobTimer").Start();
	//GetNode<Timer>("ScoreTimer").Start();
}

public void gameOver()
{
	//GetNode<Timer>("MobTimer").Stop();
	//GetTree().CallGroup("mobs", Node.MethodName.QueueFree);
}
}






