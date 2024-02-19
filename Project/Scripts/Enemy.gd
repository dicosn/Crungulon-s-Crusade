extends CharacterBody2D
var speed = 200
var gravity = 3500
var player
var chase = false
func _physics_process(delta):
	#Gravity for Frog
	velocity.y += gravity * delta
	if chase == true:
		player = get_node("../../Player/Player")
		var direction = (player.position - self.position).normalized()
		if direction.x > 0:
			get_node("Sprite2D").flip_h = true
		else:
			get_node("Sprite2D").flip_h = false
		velocity.x = direction.x * speed
	else:
		velocity.x = 0
	move_and_slide()

func OnPlayerDetectorBodyEntered(body):
	if body.name == "Player":
		chase = true

func OnPlayerDetectorBodyExited(body):
	if body.name == "Player":
		chase = false
