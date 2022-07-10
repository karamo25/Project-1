create table teams 
(
	teamId int primary key identity(1,1),
	teamName varchar(40) unique ,
	country varchar(30),
	teamFlag varchar(4000),
	teamJersey varchar(4000)
)

create table Players
(
	playerId int primary key identity(1,1),
	playerName varchar(40),
	playerPosition varchar(40),
	playerTeam varchar(40),
	playerImage varchar(4000),
	playerTeamId int foreign key references teams(teamId)
)

select country,teamId from teams;

select * from players ;

select  teams.teamId,teams.teamName,teams.country, players.playerId,players.playerName,players.playerPosition
from players
inner join teams 
on players.playerTeamId = teams.teamId
where teams.country = 'mexico'

select * from teams;

select count(playerId) from players

select count(teamId) from teams;
