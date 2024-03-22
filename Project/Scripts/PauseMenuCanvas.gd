extends CanvasLayer

signal resume_game
signal menu
signal exit_game


func _ready():
	hide()
	process_mode = Node.PROCESS_MODE_PAUSABLE

func _process(delta):
	if Input.is_action_pressed("key_exit"):
		show()
		print("bring up menu")
		get_tree().paused = true

func _on_resume_button_pressed():
	resume_game.emit()
	get_tree().paused = false
	print("resume game")
	hide()

func _on_menu_button_pressed():
	menu.emit()
	get_tree().paused = false
	get_tree().change_scene_to_file("res://Scenes/HUD.tscn")

func _on_exit_button_pressed():
	exit_game.emit()
	get_tree().quit()
