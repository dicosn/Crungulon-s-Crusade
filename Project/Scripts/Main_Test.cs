using Godot;
using System;

public partial class Main_Test : Node
{
	[Signal]
	public delegate void GameEventHandler();
	
	public override void _Ready()
	{
		GD.Print("Main_Test is ready!");

	}

	public void NewGame() {

		var player = GetNode<CharacterBody2D>("Character/CharacterBody2D");
		var startPosition = GetNode<Marker2D>("PlayerStartPosition");
		player.Position = startPosition.Position;

		GetNode<Timer>("StartTimer").Start();
		GetNode<Timer>("MobTimer").Start();
		

	}
	// These three functions are not used at the time but are placeholders for later		
	public void _on_mob_timer_timeout() {}
	public void _on_start_timer_ready() {
		GetNode<Timer>("MobTimer").Start();
		//GetNode<Timer>("ScoreTimer").Start();	
	}
	public void GameOver() {
		GD.Print("Game Over!");
		//GetNode<Timer>("MobTimer").Stop();
		//GetTree().CallGroup("mobs", Node.MethodName.QueueFree);
	}

}

