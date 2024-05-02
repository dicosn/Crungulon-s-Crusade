extends CharacterBody2D
#var speed = Vector2(600,400)
var speed = 300
#@export var collision: CollisionShape2D
@export var horizontal = true
@export var vertical = false

func _physics_process(delta):
	var velocity = Vector2(0,0)
	var collision = move_and_collide(velocity * delta)
	var direction_h = Vector2(1,0)
	var direction_v = Vector2(0,1)
	#velocity = move_and_slide()
	var vel_h = direction_h * speed
	var vel_v = direction_v * speed
	if horizontal == true:
		collision = move_and_collide(vel_h*delta)
		if collision:
			speed *= -1
			#velocity = velocity.bounce(collision.get_normal())
	if vertical == true:
		collision = move_and_collide(vel_v*delta)
		if collision:
			speed *= -1
			#velocity = velocity.bounce(collision.get_normal())
#func _on_hurtbox_body_entered(body):
#	if(body.is_in_group("Player")):
#		on_hit()	
	

