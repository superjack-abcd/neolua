StringBuilder = luanet.import_type("System.Text.StringBuilder");



path = luanet.import_type("System.IO.Path");


Console = luanet.import_type("System.Console");


local p = path.GetTempPath();

--Console.WriteLine(p);

local sb = StringBuilder(1000);

for i = 0,1000,1 do
	sb:Append(".");
end;


return sb:ToString();



