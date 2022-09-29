foo = function (x) return 2 * x end

v = foo(5);

print(v);

network = {

}

--[[s
local t = {10, 20, 30};
iter = values(t);
while true do
	local element = iter();
	if element == nil then break end
	print (element);
end
--]]
function dofile (filename)
	local f = assert (loadfile (filename))
	return f ()
end

