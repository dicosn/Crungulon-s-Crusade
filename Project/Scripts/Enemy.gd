extends CharacterBody2D
var speed = Vector2(600,400)
var gravity = 3500
var player
@export var visible_on_screen_notifier_2d_screen_entered: VisibleOnScreenNotifier2D

func _physics_process(delta):
	var velocity = Vector2(0,0)
	var is_jump_interrupted = Input.is_key_pressed(KEY_SPACE) and velocity.y < 0.0
	var direction = Vector2(1,1)
#	calculate_move_velocity(direction, is_jump_interrupted)
#	velocity = move_and_slide()
	
	if not (visible_on_screen_notifier_2d_screen_entered.is_on_screen()):
		return
	else:
		calculate_move_velocity(direction, is_jump_interrupted)
		velocity = move_and_slide()				
	
func calculate_move_velocity(direction, is_jump_interrupted):
	var new_velo = velocity
	if is_on_wall():
		speed.x *= -1
	new_velo.x = speed.x * direction.x
	new_velo.y += gravity * get_physics_process_delta_time()
	if direction.y == -1:
		new_velo.y = speed.y * direction.y
	if is_jump_interrupted:
		new_velo.y = 0.0
	velocity = new_velo

func die():
	queue_free()

func _on_player_detector_area_entered(area):
	pass # Replace with function body.


func is_on_screen():
	print("enemy is seen!") 
