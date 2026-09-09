extends Node

@export var n : DummyNode

func _ready() -> void:
	var s = Summator.new()
	var f = FixedSharp.new()
	s.Add(10)
	s.Add(20)
	s.Add(30)
	print(s.GetTotal())
	s.Add(Summator.Dummy())
	print(s.GetTotal())
	s.Reset()
