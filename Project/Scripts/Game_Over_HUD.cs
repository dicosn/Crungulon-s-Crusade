using Godot;
using System;

public partial class Game_Over_HUD : CanvasLayer
{
	private void _on_restart_button_pressed(){
		GetTree().ChangeSceneToFile("res://Scenes/Main_Test.tscn");
	}

	private void _on_quit_button_pressed(){
		GetTree().Quit();
	}
}
