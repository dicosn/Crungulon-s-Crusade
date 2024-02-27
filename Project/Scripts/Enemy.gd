extends CharacterBody2D
var speed = Vector2(150,400)
var gravity = 1000

var player
	
func _physics_process(delta):
	var velocity = Vector2()
	var is_jump_interrupted = Input.is_key_pressed(KEY_SPACE) and velocity.y < 0.0
	var direction = Vector2(1,1)
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
	print(velocity)
func die():
	queue_free()
	
func OnPlayerDetectorBodyEntered(body):
	body.die
	print("DIE")

#func OnPlayerDetectorBodyExited(body):
#	if body.name == "Player":
#		print("player exited")
#		chase = false
