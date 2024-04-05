extends CharacterBody2D

#horizontal movement stuff
@export var topspeed = 1000
@export var accel = 50

#gravity
@export var gravity = 7500
var gcap = 1500

@export var jumpvelocity = 1000

@export var air_time = 0.0
@export var ct_thresh = 0.067
var stopped_jumping = false
var pause_gravity = false

#jump time vars
var jump_time = 0.0
var jt_thresh = 0.3

var _leftSprite: Sprite2D
var _jumpSprite: Sprite2D
var _idleSprite: Sprite2D
var _rightSprite: Sprite2D
var health = 5

func h_input():
	#more affects the turnaround time
	var more = 1
	if(Input.is_action_pressed("move_right")):
		if(velocity.x < 0):
			more = 2
		velocity.x = min(velocity.x + accel*more, topspeed)
	elif(Input.is_action_pressed("move_left")):
		if(velocity.x > 0):
			more = 2
		velocity.x = max(velocity.x - accel*more, -topspeed)
	else:
		if(velocity.x > 0):
			velocity.x = max(0, velocity.x - accel)
		else:
			velocity.x = min(0, velocity.x + accel)
	

# Called when the node enters the scene tree for the first time.
func _ready():
	_idleSprite = get_node("IdleSprite")
	_rightSprite = get_node("RightSprite")
	_jumpSprite = get_node("JumpSprite")

func hit(value: float):
	health -= value
	print(health)
	if(health <= 0):
		print("you are dead")
#		queue_free()

# Remnant of collision from C
func on_hit():
	print(health)
	health -= 1
	if (health <= 0):
		print("You are Dead womp womp")

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	h_input()
	# If jump button pressed
	if Input.is_key_pressed(KEY_SPACE):
		# And on the floor
		if is_on_floor():
			# Then you can jump
			velocity.y = -jumpvelocity
			stopped_jumping = false
		elif air_time < ct_thresh and stopped_jumping:
			velocity.y = -jumpvelocity
			air_time = ct_thresh
			jump_time = 0
			stopped_jumping = false

# If holding down jump
	if Input.is_key_pressed(KEY_SPACE) and not stopped_jumping:
		# And threshold not reached
		if jump_time < jt_thresh:
			# Keep jumping
			velocity.y = -jumpvelocity * 1.25
			jump_time += delta

	if not Input.is_key_pressed(KEY_SPACE):
		jump_time = jt_thresh
		stopped_jumping = true

	if is_on_floor():
		air_time = 0
		jump_time = 0
	else:
		if air_time >= ct_thresh:
			velocity.y += min(gcap, delta * gravity)
		air_time += delta

	move_and_slide()


func _on_hurtbox_body_entered(body: Node2D):
	if(body.is_in_group("Enemy")):
		print("enemy entered")
	
