extends Area2D

func _on_pickup_area_area_entered(area):
	pass # Replace with function body.


func _on_body_entered(body):
	if(body.is_in_group("Player")):
		queue_free()
