namespace API.Entities; // This is used to acsses the funtion in the project using Entities this is folder name 

public class AppUser
{
    public int Id { get; set; } // if we decleare Id in this format is automatically recognized as primary key
    public string UserName {get; set;}
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

}
