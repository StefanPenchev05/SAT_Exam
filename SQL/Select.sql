-- Select All The Users
select * from Users;

-- Select By Country
select *
from Users 
Where Country = "China";

-- Order by name(from a-z)
select *
from Users
order by first_name;
