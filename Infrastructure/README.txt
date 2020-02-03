Remember that the "user-secrets" needs to be initialized!
And they can only be used in Development mode.
For Production they should be set as enviorment variables
on the server machine.

dotnet user-secrets init -p .\API\
dotnet user-secrets set "TokenKey" "super secret key" -p .\API\

dotnet user-secrets list -p .\API\ - to see the keys

REMEMBER to change the TokenKey value when closer to finished!