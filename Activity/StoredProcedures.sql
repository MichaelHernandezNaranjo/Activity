
USE [Activity]
go

create procedure SP_Login
@CompanyId int,
@Email varchar(100),
@Password varchar(max)
as
begin
select t1.CompanyId, t1.UserId, t1.UserName, t2.Email, t1.RoleId , t3.RoleName
from [User] t1 with (nolock)
inner join [UserEmail] t2 with (nolock) on (t2.CompanyId = t1.CompanyId and t2.UserId = t1.UserId)
inner join [Role] t3 with (nolock) on (t3.RoleId = t1.RoleId)
where t1.Active = 1 and t2.Active = 1 and t2.Verification = 1 and  t1.CompanyId = @CompanyId and t2.Email = @Email and t1.Password = @Password;
end
go

exec SP_Login 1