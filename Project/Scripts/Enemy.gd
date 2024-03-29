extends CharacterBody2D
var speed = Vector2(600,400)
var gravity = 3500
var player
var max_collisions = 3
var collision_count = 0

func _physics_process(delta):
	var velocity = Vector2(0,0)
#	for i in get_slide_collision_count():
#		var collision = get_slide_collision(i)
#		if (collision.get_collider().has_method("on_hit")):
#			print("hit2")
#			collision.get_collider().call("on_hit")
	
	var collision = move_and_collide(velocity*delta)
	print(collision)
	while(collision and get_slide_collision_count() < max_collisions):
		var collider = collision.get_collider()
		if collider is CharacterBody2D:
			collider.hit(1)
			break
		else:
			var normal = collision.get_normal()
			var remainder = collision.get_remainder()
			velocity = velocity.bounce(normal)
			remainder = remainder.bounce(normal)
			collision_count += 1
			collision = move_and_collide(remainder)
	
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

func OnPlayerDetectorBodyEntered(body):
	pass

#func OnPlayerDetectorBodyExited(body):
#if body.name == "Player":
#print("player exited")
#chase = false
