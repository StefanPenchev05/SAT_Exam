-- Search for users from this country with where
select first_name 
from Users
where Country = 'Germany';

-- Search for users that are male
select first_name 
from Users
where gender = 'Male';

-- Select the users that are not male
-- Two ways: <> or !=
select first_name, gender 
from Users
where gender <> 'Male';

-- Search the users that are from Brazil and have more than 100 points
select first_name, Country, points, (points - 20) / 10 + 23 as 'calculated points'
from Users
where Country = 'Brazil' and points > 100;

-- Search the users that are from Brazil or have more than 100 points and are from China
select first_name, Country, points, (points - 20) / 10 + 23 as 'calculated points'
from Users
where Country = 'Brazil' or 
		(points > 100 and Country = "China");

-- Search the users that are not from Brazil or and the points are not more than 99
select first_name, Country, points, (points - 20) / 10 + 23 as 'calculated points'
from Users
where not Country = 'Brazil' and not points >= 100;

-- So when you want to list users from many countries you can just made it with IN operator
select first_name, Country
from Users
where Country in ("China", "Brazil", "United States");

-- Or just can exclude those countries 
select first_name, Country
from Users
where not Country in ("China", "Brazil", "United States");

-- Instead of using points > 200 and points <= 310, use between
select first_name, points
from Users
where points between 200 and 310;


