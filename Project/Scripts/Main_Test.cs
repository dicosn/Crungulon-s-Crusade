using Godot;
using System;

public partial class Main_Test : Node
{
	//[Export]
	//public PackedScene enemy_level { get; set; }
	[Export]
	public PackedScene Character { get; set; }
	
	public void NewGame() {

		var player = GetNode<CharacterBody2D>("Character");
		var startPosition = GetNode<Marker2D>("PlayerStartPosition");
		player.Position = startPosition.Position;

		//GetNode<Timer>("StartTimer").Start();
}
	
}
