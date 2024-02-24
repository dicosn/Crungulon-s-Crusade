extends CharacterBody2D
var speed = Vector2(150,400)
var gravity = 3500

var player
	
func _physics_process(delta):
	var velocity = Vector2(0,0)
	var is_jump_interrupted = Input.is_key_pressed(KEY_SPACE) and velocity.y < 0.0
	var direction = Vector2(0,0)
	calculate_move_velocity(direction, is_jump_interrupted)
	velocity = move_and_slide()
	set_flip()

func set_flip():
	if velocity.x == 0:
		return
	$Sprite.flip_h = true if velocity.x < 0 else false
func calculate_move_velocity(direction, is_jump_interrupted):
	var new_velo = velocity
	new_velo.x = speed.x * direction.x
	new_velo.y += gravity * get_physics_process_delta_time()
	if direction.y == -1:
		new_velo.y = speed.y * direction.y
	if is_jump_interrupted:
		new_velo.y = 0.0
	
	velocity = new_velo

func die():
	queue_free()
	
func OnPlayerDetectorBodyEntered(body):
	pass

#func OnPlayerDetectorBodyExited(body):
#	if body.name == "Player":
#		print("player exited")
#		chase = false
