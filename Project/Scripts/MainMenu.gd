# In GD right now but will be converted to C#
extends CanvasLayer

# Notifies `Main` node that the button has been pressed
signal start_game
signal Quit_Button

var _start_sound = AudioStreamPlayer

#func _on_start_button_pressed():
#	$"Start Button".hide()
#	start_game.emit()
#	$"Credit Button".hide()
#	$"Quit Button".hide()
#	$"Crungulon Sprite2D".hide()
#	$TitleLabel.hide()
#	$"GrayBoxSprite2D".hide()
func _ready():
	_start_sound = get_node("Play Button")

func _on_start_button_pressed():
	_start_sound.play()
	start_game.emit()
#	$"Credit Button".hide()
#	$"Quit Button".hide()
#	$"Crungulon Sprite2D".hide()
#	$TitleLabel.hide()
#	$"GrayBoxSprite2D".hide()
	await get_tree().create_timer(0.8).timeout
	get_tree().change_scene_to_file("res://Scenes/Level1.tscn")
	
func _on_quit_button_pressed():
	_start_sound.play()
	Quit_Button.emit()
	
	get_tree().quit()
