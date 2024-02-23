extends CharacterBody2D

#horizontal movement stuff
@export var speed = 1000
@export var accel = 50

@export var gravity = 7500

var _leftSprite: Sprite2D
var _jumpSprite: Sprite2D
var _idleSprite: Sprite2D
var _rightSprite: Sprite2D

func h_input():
	if(Input.is_action_pressed("move_right")):
		velocity.x = min(velocity.x + accel, speed)
	elif(Input.is_action_pressed("move_left")):
		velocity.x = max(velocity.x - accel, -speed)
	else:
		velocity.x = 0
	

# Called when the node enters the scene tree for the first time.
func _ready():
	_idleSprite = get_node("IdleSprite")
	_rightSprite = get_node("RightSprite")
	_jumpSprite = get_node("JumpSprite")


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
