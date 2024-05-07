
-- Select only the first and last name and the email of the users
select 
    first_name, 
    last_name, 
    email
from Users;

-- You can do operations on a fild, without changing the real state
select 
    first_name, 
    ip_address, 
    ip_address / 10
from Users;

-- You can use more serious math equations
select 
    first_name, 
    ip_address, 
    (ip_address + 123 ) / (10 * 3)
from Users;

-- You can give the equation column a name with keyword - AS
select 
    first_name, 
    ip_address, (ip_address + 123 ) / (10 * 3) as changed_ip_adress
from Users;

-- You can get states that are not duplicated, for example cities or countries using distinct
select distinct City from Users;
select distinct Country from Users;