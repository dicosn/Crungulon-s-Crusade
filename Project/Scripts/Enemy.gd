extends CharacterBody2D
var speed = Vector2(600,400)
var gravity = 3500
var counter = 0

func _physics_process(delta):
	var velocity = Vector2(0,0)

#	Collision attempt 1
#	var collision = move_and_collide(velocity*delta)
#	if(collision):
#		if (collision.get_collider().has_method("on_hit")):
#			collision.get_collider().call("on_hit")
#
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

func die():
	queue_free()

# Remnant of collision from C
#func OnPlayerDetectorBodyExited(body):
#if body.name == "Player":
#print("player exited")
#chase = false

func _on_player_detector_area_entered(area):
	counter += 1
	print("area entered ", counter)
