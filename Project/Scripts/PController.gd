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
var can_jump = false
var pause_gravity = false
var uphill_run = false

#jump time vars
var jump_time = 0.0
var jt_thresh = 0.3

var _leftSprite: Sprite2D
var _jumpSprite: Sprite2D
var _idleSprite: Sprite2D
var _rightSprite: Sprite2D
var _stream_player = AudioStreamPlayer
@export var health = 4


func h_input():
	#more affects the turnaround time
	var more = 1
	if(Input.is_action_pressed("move_right")):
		_idleSprite.flip_h = false
		if(velocity.x < 0):
			more = 2
		velocity.x = min(velocity.x + accel*more, topspeed)
	elif(Input.is_action_just_pressed("move_left")):
		_idleSprite.flip_h = true
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
	_stream_player = get_node("JumpSound")

func on_hit():
	health -= 1
	_change_color()
	print(health)

	if (health <= 0):
		print("You are Dead womp womp")
		get_tree().change_scene_to_file("res://Scenes/hud.tscn")

func _change_color():
	modulate = Color(1,0,0)
	await get_tree().create_timer(0.1).timeout
	modulate = Color(1,1,1)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	h_input()
	# If jump button pressed
	if Input.is_action_just_pressed("ui_accept"):
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
	if Input.is_action_pressed("ui_accept") and not stopped_jumping:
		# And threshold not reached
		if jump_time < jt_thresh and not is_on_floor():
			# Keep jumping
			velocity.y = -jumpvelocity * 1.25
			jump_time += delta
			_stream_player.play()
	
	if not Input.is_action_pressed("ui_accept"):
		jump_time = jt_thresh
		stopped_jumping = true
		
	if is_on_ceiling():
		stopped_jumping = true	
		
	if is_on_floor():
		air_time = 0
		jump_time = 0
		floor_snap_length = 30
		floor_max_angle = 1.5
	else:
		floor_snap_length = 1
		floor_max_angle = 0.785398
		if air_time >= ct_thresh:
			velocity.y += min(gcap, delta * gravity)
		air_time += delta
#Keeping player on the slope 	
	if get_floor_angle() > 0:
		if abs(get_position_delta().x) < 16:
			topspeed = 1500
		elif abs(get_position_delta().x) > 18:
			topspeed = 800
	else:
		topspeed = 1000

	#print(get_position_delta().x)
	apply_floor_snap()
	move_and_slide()

func _on_hurtbox_body_entered(body):
	if(body.is_in_group("Enemy")):
		on_hit()

func _on_hurtbox_area_entered(area):
		if(area.is_in_group("Health")):
			gain_health()
			
func gain_health():
	if (health < 5): 
		health += 1
		print("gained health")

func uphillCheck():
	var horizontal_movement = false
	var floorCheck = false
	var upCheck = false
	if Input.is_key_pressed(KEY_LEFT) || Input.is_key_pressed(KEY_RIGHT):
		horizontal_movement = true
		#print ("moving horizontal")
	if is_on_floor():
		floorCheck = true
		#print ("on floor")
	if velocity.y > 0:
		#print ("going up")
		upCheck = true
	if horizontal_movement && floorCheck && upCheck:
		return true
	else:
		return false



