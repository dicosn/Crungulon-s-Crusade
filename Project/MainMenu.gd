extends CanvasLayer

# Notifies `Main` node that the button has been pressed
signal start_game
signal quit


func _on_start_pressed():
	$Start.hide()
	start_game.emit()
	$Creds.hide()
	$Quit.hide()
	$Crungy.hide()
	$"Crungulon Title".hide()



func _on_quit_pressed():
	quit.emit()
