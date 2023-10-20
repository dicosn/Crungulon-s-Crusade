extends Label




# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_float):
	var node = get_owner()
	var player = node.get_child(1)
	var pos = player.position
	text = "position:" + str(pos)
