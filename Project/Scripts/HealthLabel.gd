extends Label

func _process(_float):
	#@export var player: CharacterBody2D
	var canvas = get_owner()	#Main Test
	var node = canvas.get_child(0)	#CharacterNode2D
	var player = node.get_child(0)	#CharacterBody2D
	var health = player.health
	text = "Health: " + str(health)
