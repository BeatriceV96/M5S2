﻿select ShipCountry, count(*) as TotalOrdersByCountry from Orders group by ShipCountry