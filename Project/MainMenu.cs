using Godot;

public partial class HUD : CanvasLayer
{
	[Signal]
	public delegate void StartGameEventHandler();
	
private void OnStartPressed()
 {

	EmitSignal(SignalName.StartGame);
 }
}






