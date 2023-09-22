using Godot;
using System;

public partial class ButtonScript : Button
{
	private Label label;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
   		label = GetNode<Label>("../Label"); // Assuming the Label is a sibling node.
		Connect("pressed", this, "_OnButtonPressed", new Godot.Collections.Array());
	}


	// Called when the button is pressed.
	private void _OnButtonPressed()
	{
		label.Text = "Hello, Godot C#!";
	}
}
