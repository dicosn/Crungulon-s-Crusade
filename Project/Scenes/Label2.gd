extends Label
func _process(_float):
	var can = get_owner()
	var node = can.get_child(0)
	var player = node.get_child(0)
	var pos = player.position
	text = "position:" + str(pos)
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
