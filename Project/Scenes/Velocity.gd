extends Label

var player = CharacterBody2D
var Velocity = player.get("velocity.X")
	

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_float):
	text = "Velocity:" + str(Velocity)
